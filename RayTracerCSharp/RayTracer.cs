using System.Linq;
using System;
using System.Collections.Generic;
using System.Windows.Media.Media3D;

namespace RayTracer {
    public class RayTracer {

        private int screenWidth;
        private int screenHeight;
        private const int MaxDepth = 5;

        public Action<int, int, System.Drawing.Color> setPixel;

        public RayTracer(int screenWidth, int screenHeight, Action<int,int, System.Drawing.Color> setPixel) {
            this.screenWidth = screenWidth;
            this.screenHeight = screenHeight;
            this.setPixel = setPixel;
        }

        private IEnumerable<Intersection> Intersections(Ray ray, Scene scene)
        {
            return scene.Things
                        .Select(obj => obj.Intersect(ray))
                        .Where(inter => inter != null)
                        .OrderBy(inter => inter.Dist);
        }

        private double TestRay(Ray ray, Scene scene) {
            var isects = Intersections(ray, scene);
            Intersection isect = isects.FirstOrDefault();
            if (isect == null)
                return 0;
            return isect.Dist;
        }

        private Color TraceRay(Ray ray, Scene scene, int depth) {
            var isects = Intersections(ray, scene);
            Intersection isect = isects.FirstOrDefault();
            if (isect == null)
                return Color.Background;
            return Shade(isect, scene, depth);
        }

        private Color GetNaturalColor(SceneObject thing, Vector3D pos, Vector3D norm, Vector3D rd, Scene scene) {
            Color ret = Color.Make(0, 0, 0);
            foreach (Light light in scene.Lights) {
                Vector3D ldis = light.Pos- pos;
                Vector3D livec = ldis;
                livec.Normalize();
                double neatIsect = TestRay(new Ray() { Start = pos, Dir = livec }, scene);
                bool isInShadow = !((neatIsect > ldis.Length) || (neatIsect == 0));
                if (!isInShadow) {
                    double illum = Vector3D.DotProduct(livec, norm);
                    Color lcolor = illum > 0 ? Color.Times(illum, light.Color) : Color.Make(0, 0, 0);
                    rd.Normalize();
                    double specular = Vector3D.DotProduct(livec, rd);
                    Color scolor = specular > 0 ? Color.Times(Math.Pow(specular, thing.Surface.Roughness), light.Color) : Color.Make(0, 0, 0);
                    ret = Color.Plus(ret, Color.Plus(Color.Times(thing.Surface.Diffuse(pos), lcolor),
                                                     Color.Times(thing.Surface.Specular(pos), scolor)));
                }
            }
            return ret;
        }

        private Color GetReflectionColor(SceneObject thing, Vector3D pos, Vector3D norm, Vector3D rd, Scene scene, int depth) {
            return Color.Times(thing.Surface.Reflect(pos), TraceRay(new Ray() { Start = pos, Dir = rd }, scene, depth + 1));
        }

        private Color Shade(Intersection isect, Scene scene, int depth) {
            var d = isect.Ray.Dir;
            var pos = isect.Dist * isect.Ray.Dir +  isect.Ray.Start;
            var normal = isect.Thing.Normal(pos);
            var reflectDir = d - 2 * Vector3D.DotProduct(normal, d) * normal;
            Color ret = Color.DefaultColor;
            ret = Color.Plus(ret, GetNaturalColor(isect.Thing, pos, normal, reflectDir, scene));
            if (depth >= MaxDepth) {
                return Color.Plus(ret, Color.Make(.5, .5, .5));
            }
            return Color.Plus(ret, GetReflectionColor(isect.Thing, pos + (.001 * reflectDir), normal, reflectDir, scene, depth));
        }

        private double RecenterX(double x) {
            return (x - (screenWidth / 2.0)) / (2.0 * screenWidth);
        }
        private double RecenterY(double y) {
            return -(y - (screenHeight / 2.0)) / (2.0 * screenHeight);
        }

        private Vector3D GetPoint(double x, double y, Camera camera) {
            var result = camera.Forward + RecenterX(x)*camera.Right + RecenterY(y)* camera.Up;
            result.Normalize();
            return result;
        }

        internal void Render(Scene scene) {
            for (int y = 0; y < screenHeight; y++)
            {
                for (int x = 0; x < screenWidth; x++)
                {
                    Color color = TraceRay(new Ray() { Start = scene.Camera.Pos, Dir = GetPoint(x, y, scene.Camera) }, scene, 0);
                    setPixel(x, y, color.ToDrawingColor());
                }
            }
        }

        internal readonly Scene DefaultScene =
            new Scene() {
                    Things = new SceneObject[] { 
                                new Plane() {
                                    Norm = new Vector3D(0,1,0),
                                    Offset = 0,
                                    Surface = Surfaces.CheckerBoard
                                },
                                new Sphere() {
                                    Center = new Vector3D(0,1,0),
                                    Radius = 1,
                                    Surface = Surfaces.Shiny
                                },
                                new Sphere() {
                                    Center = new Vector3D(-1,.5,1.5),
                                    Radius = .5,
                                    Surface = Surfaces.Shiny
                                }},
                    Lights = new Light[] { 
                                new Light() {
                                    Pos = new Vector3D(-2,2.5,0),
                                    Color = Color.Make(.49,.07,.07)
                                },
                                new Light() {
                                    Pos = new Vector3D(1.5,2.5,1.5),
                                    Color = Color.Make(.07,.07,.49)
                                },
                                new Light() {
                                    Pos = new Vector3D(1.5,2.5,-1.5),
                                    Color = Color.Make(.07,.49,.071)
                                },
                                new Light() {
                                    Pos = new Vector3D(0,3.5,0),
                                    Color = Color.Make(.21,.21,.35)
                                }},
                    Camera = new Camera(new Vector3D(3,2,4), new Vector3D(-1,.5,0))
                };
    }

    public delegate void Action<T,U,V>(T t, U u, V v);

 
}

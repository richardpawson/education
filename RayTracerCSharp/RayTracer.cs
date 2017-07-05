using System.Linq;
using System;
using System.Collections.Generic;
using System.Windows.Media.Media3D;
using System.Diagnostics;

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
                        .Select(obj => obj.CalculateIntersection(ray))
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

        private Color GetNaturalColor(IThing thing, Vector3D pos, Vector3D norm, Vector3D rd, Scene scene) {
            Color ret = new Color(0, 0, 0);
            foreach (LightSource light in scene.Lights) {
                Vector3D ldis = light.Pos- pos;
                Vector3D livec = ldis;
                livec.Normalize();
                double neatIsect = TestRay(new Ray(pos, livec), scene);
                bool isInShadow = !((neatIsect > ldis.Length) || (neatIsect == 0));
                if (!isInShadow) {
                    double illum = Vector3D.DotProduct(livec, norm);
                    Color lcolor = illum > 0 ? illum * light.Color : new Color(0, 0, 0);
                    rd.Normalize();
                    double specular = Vector3D.DotProduct(livec, rd);
                    Color scolor = specular > 0 ? Math.Pow(specular, thing.Surface.Roughness) * light.Color : new Color(0, 0, 0);
                    ret = ret +  (thing.Surface.Diffuse(pos) * lcolor) + (thing.Surface.Specular(pos) * scolor);
                }
            }
            return ret;
        }

        private Color GetReflectionColor(IThing thing, Vector3D pos, Vector3D norm, Vector3D rd, Scene scene, int depth) {
            return thing.Surface.Reflect(pos) * TraceRay(new Ray( pos,  rd ), scene, depth + 1);
        }

        private Color Shade(Intersection isect, Scene scene, int depth) {
            var d = isect.Ray.Dir;
            var pos = isect.Dist * isect.Ray.Dir +  isect.Ray.Start;
            var normal = isect.Thing.CalculateNormal(pos);
            var reflectDir = d - 2 * Vector3D.DotProduct(normal, d) * normal;
            Color ret = Color.DefaultColor;
            ret = ret + GetNaturalColor(isect.Thing, pos, normal, reflectDir, scene);
            if (depth >= MaxDepth) {
                return ret + new Color(.5, .5, .5);
            }
            return ret + GetReflectionColor(isect.Thing, pos + (.001 * reflectDir), normal, reflectDir, scene, depth);
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

        public void Render(Scene scene) {
            for (int y = 0; y < screenHeight; y++)
            {
                for (int x = 0; x < screenWidth; x++)
                {
                    //if (x == 300 && y == 300) Debugger.Break();
                    Color color = TraceRay(new Ray(scene.Camera.Pos,GetPoint(x, y, scene.Camera) ), scene, 0);
                    setPixel(x, y, color.ToDrawingColor());
                }
            }
        }
    }

    public delegate void Action<T,U,V>(T t, U u, V v);
}

using System.Drawing;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

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
                Vector3D ldis = Vector3D.Minus(light.Pos, pos);
                Vector3D livec = Vector3D.Norm(ldis);
                double neatIsect = TestRay(new Ray() { Start = pos, Dir = livec }, scene);
                bool isInShadow = !((neatIsect > Vector3D.Mag(ldis)) || (neatIsect == 0));
                if (!isInShadow) {
                    double illum = Vector3D.Dot(livec, norm);
                    Color lcolor = illum > 0 ? Color.Times(illum, light.Color) : Color.Make(0, 0, 0);
                    double specular = Vector3D.Dot(livec, Vector3D.Norm(rd));
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
            var pos = Vector3D.Plus(Vector3D.Times(isect.Dist, isect.Ray.Dir), isect.Ray.Start);
            var normal = isect.Thing.Normal(pos);
            var reflectDir = Vector3D.Minus(d, Vector3D.Times(2 * Vector3D.Dot(normal, d), normal));
            Color ret = Color.DefaultColor;
            ret = Color.Plus(ret, GetNaturalColor(isect.Thing, pos, normal, reflectDir, scene));
            if (depth >= MaxDepth) {
                return Color.Plus(ret, Color.Make(.5, .5, .5));
            }
            return Color.Plus(ret, GetReflectionColor(isect.Thing, Vector3D.Plus(pos, Vector3D.Times(.001, reflectDir)), normal, reflectDir, scene, depth));
        }

        private double RecenterX(double x) {
            return (x - (screenWidth / 2.0)) / (2.0 * screenWidth);
        }
        private double RecenterY(double y) {
            return -(y - (screenHeight / 2.0)) / (2.0 * screenHeight);
        }

        private Vector3D GetPoint(double x, double y, Camera camera) {
            return Vector3D.Norm(Vector3D.Plus(camera.Forward, Vector3D.Plus(Vector3D.Times(RecenterX(x), camera.Right),
                                                                       Vector3D.Times(RecenterY(y), camera.Up))));
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
                                    Norm = Vector3D.Make(0,1,0),
                                    Offset = 0,
                                    Surface = Surfaces.CheckerBoard
                                },
                                new Sphere() {
                                    Center = Vector3D.Make(0,1,0),
                                    Radius = 1,
                                    Surface = Surfaces.Shiny
                                },
                                new Sphere() {
                                    Center = Vector3D.Make(-1,.5,1.5),
                                    Radius = .5,
                                    Surface = Surfaces.Shiny
                                }},
                    Lights = new Light[] { 
                                new Light() {
                                    Pos = Vector3D.Make(-2,2.5,0),
                                    Color = Color.Make(.49,.07,.07)
                                },
                                new Light() {
                                    Pos = Vector3D.Make(1.5,2.5,1.5),
                                    Color = Color.Make(.07,.07,.49)
                                },
                                new Light() {
                                    Pos = Vector3D.Make(1.5,2.5,-1.5),
                                    Color = Color.Make(.07,.49,.071)
                                },
                                new Light() {
                                    Pos = Vector3D.Make(0,3.5,0),
                                    Color = Color.Make(.21,.21,.35)
                                }},
                    Camera = Camera.Create(Vector3D.Make(3,2,4), Vector3D.Make(-1,.5,0))
                };
    }

    public delegate void Action<T,U,V>(T t, U u, V v);

    public partial class RayTracerForm : Form
    {
        Bitmap bitmap;
        PictureBox pictureBox;
        const int width = 600;
        const int height = 600;

        public RayTracerForm()
        {
            bitmap = new Bitmap(width,height);

            pictureBox = new PictureBox();
            pictureBox.Dock = DockStyle.Fill;
            pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox.Image = bitmap;

            ClientSize = new System.Drawing.Size(width, height + 24);
            Controls.Add(pictureBox);
            Text = "Ray Tracer";
            Load += RayTracerForm_Load;

            Show();
        }

        private void RayTracerForm_Load(object sender, EventArgs e)
        {
            this.Show();
            RayTracer rayTracer = new RayTracer(width, height, (int x, int y, System.Drawing.Color color) =>
                                                               {
                                                                   bitmap.SetPixel(x, y, color);
                                                                   if (x == 0) pictureBox.Refresh();
                                                               });
            rayTracer.Render(rayTracer.DefaultScene);
            pictureBox.Invalidate();

        }
        
        [STAThread]
        static void Main() {
            Application.EnableVisualStyles();

            Application.Run(new RayTracerForm());
        }
    }
}

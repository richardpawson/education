
using System.Windows.Media.Media3D;

namespace RayTracer
{
    public static class StandardScenes
    {
        public static readonly Scene DefaultScene =
            new Scene(
                    new PhysicalObject[] {
                                new Plane(new Vector3D(0,1,0),0, StandardSurfaces.CheckerBoard),
                                new Sphere(new Vector3D(0,1,0),1,StandardSurfaces.Shiny),
                                new Sphere(new Vector3D(-1,.5,1.5),.5,StandardSurfaces.Shiny)
                                },
                     new Light[] {
                                new Light(new Vector3D(-2,2.5,0), new Color(.49,.07,.07)),
                                new Light(new Vector3D(1.5,2.5,1.5),new Color(.07,.07,.49)),
                                new Light(new Vector3D(1.5,2.5,-1.5),new Color(.07,.49,.071)),
                                new Light(new Vector3D(0,3.5,0),new Color(.21,.21,.35))
                    },
                     new Camera(new Vector3D(3, 2, 4), new Vector3D(-1, .5, 0))
                );
    }
}

using System.Collections.Generic;
using System.Linq;

namespace RayTracer
{
    public class Scene
    {
        public IThing[] Things { get; private set; }
        public LightSource[] Lights { get; private set; }
        public Camera Camera { get; private set; }

        public Scene(IThing[] things, LightSource[] lights, Camera camera)
        {
            Things = things;
            Lights = lights;
            Camera = camera;
        }

        public IEnumerable<Intersection> Intersect(Ray r)
        {
            return from thing in Things
                   select thing.CalculateIntersection(r);  //LINQ
        }
    }
}
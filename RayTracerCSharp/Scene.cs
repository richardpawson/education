using System;
using System.Collections.Generic;
using System.Linq;

namespace RayTracer
{
    class Scene
    {
        public SceneObject[] Things;
        public Light[] Lights;
        public Camera Camera;

        public IEnumerable<Intersection> Intersect(Ray r)
        {
            return from thing in Things
                   select thing.Intersect(r);
        }
    }
}

﻿using System.Collections.Generic;
using System.Linq;

namespace RayTracer
{
    public class Scene
    {
        public PhysicalObject[] Things { get; private set; }
        public Light[] Lights { get; private set; }
        public Camera Camera { get; private set; }

        public Scene(PhysicalObject[] things, Light[] lights, Camera camera)
        {
            Things = things;
            Lights = lights;
            Camera = camera;
        }

        public IEnumerable<Intersection> Intersect(Ray r)
        {
            return from thing in Things
                   select thing.Intersect(r);  //LINQ
        }
    }
}
using System;
using System.Windows.Media.Media3D;

namespace RayTracer
{

    public abstract class PhysicalObject
    {
        public Surface Surface { get; private set; }
        public abstract Intersection Intersect(Ray ray);
        public abstract Vector3D Normal(Vector3D pos);

        public PhysicalObject(Surface surface)
        {
            Surface = surface;
        }
    }
}

using System;
using System.Windows.Media.Media3D;

namespace RayTracer
{
    public class Sphere : PhysicalObject
    {
        public Vector3D Centre { get; private set; }
        public double Radius { get; private set; }

        public Sphere(Vector3D centre, double radius, Surface surface) : base(surface)
        {
            Centre = centre;
            Radius = radius;
        }

        public override Intersection Intersect(Ray ray)
        {
            Vector3D eo = Centre - ray.Start;
            double v = Vector3D.DotProduct(eo, ray.Dir);
            double dist;
            if (v < 0)
            {
                dist = 0;
            }
            else
            {
                double disc = Math.Pow(Radius, 2) - (Vector3D.DotProduct(eo, eo) - Math.Pow(v, 2));
                dist = disc < 0 ? 0 : v - Math.Sqrt(disc);
            }
            if (dist == 0) return null;
            return new Intersection(this, ray, dist);
        }

        public override Vector3D Normal(Vector3D pos)
        {
            Vector3D normal = pos - Centre;
            normal.Normalize();
            return normal;
        }
    }

}

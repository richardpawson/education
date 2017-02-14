using System;
using System.Windows.Media.Media3D;

namespace RayTracer
{
    public class Sphere : IThing
    {
        public SurfaceTexture Surface { get; private set; }
        public Vector3D Centre { get; private set; }
        public double Radius { get; private set; }

        public Sphere(Vector3D centre, double radius, SurfaceTexture surface) 
        {
            Centre = centre;
            Radius = radius;
            Surface = surface;
        }

        public Intersection CalculateIntersection(Ray withRay)
        {
            Vector3D eo = Centre - withRay.Start;
            double v = Vector3D.DotProduct(eo, withRay.Dir);
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
            return new Intersection(this, withRay, dist);
        }

        public Vector3D CalculateNormal(Vector3D surfacePosition)
        {
            Vector3D normal = surfacePosition - Centre;
            normal.Normalize();
            return normal;
        }
    }
}

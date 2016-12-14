using System;
using System.Windows.Media.Media3D;

namespace RayTracer
{

    abstract class SceneObject
    {
        public Surface Surface;
        public abstract Intersection Intersect(Ray ray);
        public abstract Vector3D Normal(Vector3D pos);
    }

    class Sphere : SceneObject
    {
        public Vector3D Center;
        public double Radius;

        public override Intersection Intersect(Ray ray)
        {
            Vector3D eo = Center - ray.Start;
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
            return new Intersection()
            {
                Thing = this,
                Ray = ray,
                Dist = dist
            };
        }

        public override Vector3D Normal(Vector3D pos)
        {
            Vector3D normal =  pos - Center;
            normal.Normalize();
            return normal;
        }
    }

    class Plane : SceneObject
    {
        public Vector3D Norm;
        public double Offset;

        public override Intersection Intersect(Ray ray)
        {
            double denom = Vector3D.DotProduct(Norm, ray.Dir);
            if (denom > 0) return null;
            return new Intersection()
            {
                Thing = this,
                Ray = ray,
                Dist = (Vector3D.DotProduct(Norm, ray.Start) + Offset) / (-denom)
            };
        }

        public override Vector3D Normal(Vector3D pos)
        {
            return Norm;
        }
    }

}

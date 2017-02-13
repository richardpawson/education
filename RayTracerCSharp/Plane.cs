

using System.Windows.Media.Media3D;

namespace RayTracer
{
    public class Plane : PhysicalObject
    {
        public Vector3D Norm { get; private set; }
        public double Offset { get; private set; }

        public Plane(Vector3D norm, double offset, Surface surface) : base(surface)
        {
            Norm = norm;
            Offset = offset;
        }

        public override Intersection Intersect(Ray ray)
        {
            double denom = Vector3D.DotProduct(Norm, ray.Dir);
            if (denom > 0) return null;
            return new Intersection(this, ray, (Vector3D.DotProduct(Norm, ray.Start) + Offset) / (-denom));
        }

        public override Vector3D Normal(Vector3D pos)
        {
            return Norm;
        }
    }

}

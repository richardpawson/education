using System.Windows.Media.Media3D;

namespace RayTracer
{
    public class Plane : IThing
    {
        public SurfaceTexture Surface { get; private set; }
        public Vector3D Norm { get; private set; }
        public double Offset { get; private set; }

        public Plane(Vector3D norm, double offset, SurfaceTexture surface)
        {
            Norm = norm;
            Offset = offset;
            Surface = surface;
        }

        public  Intersection CalculateIntersection(Ray withRay)
        {
            double denom = Vector3D.DotProduct(Norm, withRay.Dir);
            if (denom > 0) return null;
            return new Intersection(this, withRay, (Vector3D.DotProduct(Norm, withRay.Start) + Offset) / (-denom));
        }

        public  Vector3D CalculateNormal(Vector3D surfacePosition)
        {
            return Norm;
        }
    }
}

using System.Windows.Media.Media3D;

namespace RayTracer
{
    public interface IThing
    {
          SurfaceTexture Surface { get; }
          Intersection CalculateIntersection(Ray withRay);
          Vector3D CalculateNormal(Vector3D toSurfacePosition);
    }
}

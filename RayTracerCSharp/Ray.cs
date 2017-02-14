using System.Windows.Media.Media3D;

namespace RayTracer
{
    public class Ray
    {
        public Vector3D Start { get; private set; }
        public Vector3D Dir { get; private set; }
        public Ray(Vector3D start, Vector3D dir)
        {
            Start = start;
            Dir = dir;
        }
    }
}

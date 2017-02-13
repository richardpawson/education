using System.Windows.Media.Media3D;

namespace RayTracer
{
    //This is a light-weight immutable class. It could be a struct
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

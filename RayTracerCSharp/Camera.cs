using System.Windows.Media.Media3D;

namespace RayTracer
{
    public class Camera
    {
        public Vector3D Pos;
        public Vector3D Forward;
        public Vector3D Up;
        public Vector3D Right;

        public Camera(Vector3D pos, Vector3D lookAt)
        {
            Forward = lookAt - pos;
            Forward.Normalize();
            var down = new Vector3D(0, -1, 0);
            Right = Vector3D.CrossProduct(Forward, down);
            Right.Normalize();
            Right *= 1.5;
            Up = Vector3D.CrossProduct(Forward, Right);
            Up.Normalize();
            Up *= 1.5;
            Pos = pos;
        }
    }
}

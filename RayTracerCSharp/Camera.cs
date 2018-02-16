using System.Windows.Media.Media3D;

namespace RayTracer
{
    public class Camera
    {
        public Vector3D Pos { get; private set; }
        public Vector3D Forward { get; private set; }
        public Vector3D Up { get; private set; }
        public Vector3D Right { get; private set; }

        public Camera(Vector3D pos, Vector3D lookAt)
        {
            var forward = lookAt - pos;
            forward.Normalize();
            var down = new Vector3D(0, -1, 0);
            var right = Vector3D.CrossProduct(forward, down);
            right.Normalize();
            right *= 1.5;
            var up = Vector3D.CrossProduct(forward, right);
            up.Normalize();
            up *= 1.5;
            Pos = pos;
            Forward = forward;
            Up = up;
            Right = right;
        }
    }
}

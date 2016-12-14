using System.Windows.Media.Media3D;

namespace RayTracer
{
    class Camera
    {
        public Vector3D Pos;
        public Vector3D Forward;
        public Vector3D Up;
        public Vector3D Right;

        public static Camera Create(Vector3D pos, Vector3D lookAt)
        {
            Vector3D forward = lookAt - pos;
            forward.Normalize();
            Vector3D down = new Vector3D(0, -1, 0);
            Vector3D right = Vector3D.CrossProduct(forward, down);
            right.Normalize();
            right *= 1.5;
            Vector3D up = Vector3D.CrossProduct(forward, right);
            up.Normalize();
            up *= 1.5;

            return new Camera() { Pos = pos, Forward = forward, Up = up, Right = right };
        }
    }
}

using System.Windows.Media.Media3D;

namespace RayTracer
{
    class Camera
    {
        public Vector3D Pos;
        public Vector3D Forward;
        public Vector3D Up;
        public Vector3D Right;

        public  Camera(Vector3D pos, Vector3D lookAt)
        {
            Pos = pos;
            Forward = lookAt - pos;
            Forward.Normalize();
            Vector3D Down = new Vector3D(0, -1, 0);
            Right = Vector3D.CrossProduct(Forward, Down);
            Right.Normalize();
            Right *= 1.5;
            Up = Vector3D.CrossProduct(Forward, Right);
            Up.Normalize();
            Up *= 1.5;
        }
    }
}

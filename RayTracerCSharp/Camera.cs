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
            Vector3D forward = Vector3D.Norm(Vector3D.Minus(lookAt, pos));
            Vector3D down = new Vector3D(0, -1, 0);
            Vector3D right = Vector3D.Times(1.5, Vector3D.Norm(Vector3D.Cross(forward, down)));
            Vector3D up = Vector3D.Times(1.5, Vector3D.Norm(Vector3D.Cross(forward, right)));

            return new Camera() { Pos = pos, Forward = forward, Up = up, Right = right };
        }
    }
}

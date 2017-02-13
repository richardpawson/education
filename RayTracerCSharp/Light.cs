using System.Windows.Media.Media3D;

namespace RayTracer
{
    //This is a light-weight (pardon the pun!) immutable class. It could be a struct
    public class Light
    {
        public Vector3D Pos { get; private set; }
        public Color Color { get; private set; }

        public Light(Vector3D pos, Color color)
        {
            Pos = pos;
            Color = color;
        }
    }
}

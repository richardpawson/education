using System.Windows.Media.Media3D;

namespace RayTracer
{
    public class LightSource
    {
        public Vector3D Pos { get; private set; }
        public Color Color { get; private set; }

        public LightSource(Vector3D pos, Color color)
        {
            Pos = pos;
            Color = color;
        }
    }
}

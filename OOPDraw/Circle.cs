using System.Drawing;

namespace OOPDraw
{
    public class Circle
    {
        //Properties
        public float PositionX { get; set; }
        public float PositionY { get; set; }
        public Color LineColor { get; set; }
        public float Radius { get; set; }

        //The 'Constructor
        public Circle(float x, float y, Color lineColor, float radius)
        {
            LineColor = lineColor;
            PositionX = x;
            PositionY = y;
            Radius = radius;
        }
    }
}

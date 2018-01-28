using System.Drawing;

namespace OOPDraw
{
    public class Square
    {
        //Properties
        public float PositionX { get; set; }
        public float PositionY { get; set; }
        public Color LineColor { get; set; }
        public float SideLength { get; set; }

        //The 'Constructor
        public Square(float x, float y, Color lineColor, float sideLength)
        {
            LineColor = lineColor;
            PositionX = x;
            PositionY = y;
            SideLength = sideLength;
        }
    }
}

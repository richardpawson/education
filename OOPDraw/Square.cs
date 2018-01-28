using Nakov.TurtleGraphics;
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

        public void Draw()
        {
            Turtle.X = PositionX;
            Turtle.Y = PositionY;
            Turtle.PenColor = LineColor;
            for (int i = 0; i < 4; i++)
            {
                Turtle.Forward(SideLength);
                Turtle.Rotate(90);
            }
        }
    }
}

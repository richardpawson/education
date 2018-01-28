using System.Drawing;
using Nakov.TurtleGraphics;
using System;

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

        public void Draw()
        {
            Turtle.X = PositionX;
            Turtle.Y = PositionY;
            Turtle.PenColor = LineColor;
            for (int i = 0; i < 360; i++)
            {
                Turtle.Forward((float)(2 * Math.PI * Radius / 360));
                Turtle.Rotate(1);
            }
        }
    }
}

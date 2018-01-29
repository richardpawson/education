using System.Drawing;
using Nakov.TurtleGraphics;
using System;

namespace OOPDraw
{
    public class Circle : Shape
    {
        //Properties
        public float Radius { get; set; }

        //The 'Constructor
        public Circle(float centreX, float centreY, Color lineColor, float radius)
        {
            LineColor = lineColor;
            CentreX = centreX;
            CentreY = centreY;
            Radius = radius;
        }

        public override void Draw()
        {
            Turtle.Angle = 0;
            Turtle.X = CentreX - Radius;
            Turtle.Y = CentreY;
            Turtle.PenColor = LineColor;
            for (int i = 0; i < 360; i++)
            {
                Turtle.Forward((float)(2 * Math.PI * Radius / 360));
                Turtle.Rotate(1);
            }
        }

        public override void GrowBy(float factor)
        {
            CentreX *= factor;
            CentreY *= factor;
            Radius *= factor;
        }
    }
}

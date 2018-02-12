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
        public Circle(float centreX, float centreY, Color lineColor, float radius) : base(centreX, centreY, lineColor)
        {
            Radius = radius;
        }

        public Circle() : base()
        {
            Radius = 20;
        }

        public override void Draw()
        {
            ResetTurtle();
            Turtle.X -= Radius; 
            for (int i = 0; i < 360; i++)
            {
                Turtle.Forward((float)(2 * Math.PI * Radius / 360));
                Turtle.Rotate(1);
            }
        }

        public override void Resize(float x, float y)
        {
            Radius = (float) Math.Sqrt(Math.Pow(x - CentreX, 2) + Math.Pow(y - CentreY,2));
        }
    }
}

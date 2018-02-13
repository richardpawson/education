using Nakov.TurtleGraphics;
using System.Drawing;
using System;

namespace OOPDraw
{
    public class Rectangle : Shape
    {
        //Properties
        public float Width { get; set; }
        public float Height { get; set; }

        //The 'Constructor
        public Rectangle(float centreX, float centreY, float width, float height) : base(centreX, centreY)
        {
            Width  = width;
            Height = height;
        }

        public override void Draw()
        {
            ResetTurtle();
            for (int i = 0; i < 2; i++)
            {
                Turtle.Forward(Height);
                Turtle.Rotate(90);
                Turtle.Forward(Width);
                Turtle.Rotate(90);
            }
        }

        public override void Resize(float x, float y)
        {
            Width = Math.Abs(x);
            Height = Math.Abs(y);
        }
    }
}

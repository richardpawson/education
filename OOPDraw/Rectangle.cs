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
        public Rectangle(float centreX, float centreY, Color lineColor, float width, float height) : base(centreX, centreY, lineColor)
        {
            Width  = width;
            Height = height;
        }

        public Rectangle() : base()
        {
            Width = 100;
            Height = 50;
        }

        public override void Draw()
        {
            ResetTurtle();
            Turtle.X -= Width/2; //To ensure shape is centred correctly
            Turtle.Y -= Height/2;
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
            Width = Math.Abs(x - CentreX) * 2;
            Height = Math.Abs(y - CentreY) * 2;
        }
    }
}

using Nakov.TurtleGraphics;
using System;
using System.Drawing;

namespace OOPDraw
{
    public class Triangle : Shape
    {
        //Properties
        public float Base { get; set; }
        public float Height { get; set; }

        //The 'Constructor
        public Triangle() : base()
        {
            Base = 100;
            Height = 50;
        }
        public override void Draw()
        {
            ResetTurtle();
            Turtle.Angle = -90;
            double baseAngleRad =  Math.Atan(Height / (Base / 2));
            float baseAngleDeg = (float) (baseAngleRad * 180 / Math.PI);
            float side = Height / (float) Math.Sin(baseAngleRad);
            Turtle.Backward(Base / 2);
            Turtle.Forward(Base); 
            Turtle.Rotate(180 - baseAngleDeg);
            Turtle.Forward(side);
            Turtle.Rotate(baseAngleDeg * 2);
            Turtle.Forward(side);
        }

        public override void Resize(float x, float y)
        {
            Base = (x - CentreX) * 2;
            Height = y - CentreY;
        }
    }
}

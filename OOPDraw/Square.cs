using Nakov.TurtleGraphics;
using System.Drawing;
using System;

namespace OOPDraw
{
    public class Square : Shape
    {
        //Properties
        public float CentreX { get; set; }
        public float CentreY { get; set; }
        public Color LineColor { get; set; }
        public float SideLength { get; set; }

        //The 'Constructor
        public Square(float centreX, float centreY, Color lineColor, float sideLength)
        {
            LineColor = lineColor;
            CentreX = centreX;
            CentreY = centreY;
            SideLength = sideLength;
        }

        public override void Draw()
        {
            Turtle.Angle = 0;
            Turtle.X = CentreX-SideLength/2; //To ensure shape is centred correctly
            Turtle.Y = CentreY-SideLength/2;
            Turtle.PenColor = LineColor;
            for (int i = 0; i < 4; i++)
            {
                Turtle.Forward(SideLength);
                Turtle.Rotate(90);
            }
        }

        public override void GrowBy(float factor)
        {
            CentreX *= factor;
            CentreY *= factor;
            SideLength *= factor;
        }
    }
}

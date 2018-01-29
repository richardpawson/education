using Nakov.TurtleGraphics;
using System;
using System.Drawing;

namespace OOPDraw
{
    public class EquilateralTriangle : Shape
    {
        //Properties
        public float SideLength { get; set; }

        //The 'Constructor
        public EquilateralTriangle(float centreX, float centreY, Color lineColor, float sideLength)
        {
            LineColor = lineColor;
            CentreX = centreX;
            CentreY = centreY;
            SideLength = sideLength;
        }

        public override void Draw()
        {
            Turtle.Angle = -90;
            Turtle.X = CentreX - SideLength / 2; //To ensure shape is centred correctly
            Turtle.Y = CentreY - (float) (SideLength * Math.Sin(60) /3); //Centre is at a third of the height
            Turtle.PenColor = LineColor;
            for (int i = 0; i < 3; i++)
            {
                Turtle.Forward(SideLength);
                Turtle.Rotate(120);
            }
        }

        public override void GrowBy(float factor)
        {
            SideLength *= factor;
        }
    }
}

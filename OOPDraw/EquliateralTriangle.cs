using Nakov.TurtleGraphics;
using System;
using System.Drawing;

namespace OOPDraw
{
    public class EquliateralTriangle : Shape
    {
        //Properties
        public float Side { get; set; }

        //The 'Constructor
        public EquliateralTriangle(float originX, float originY, float side) : base(originX, originY)
        {
            Side = side;
        }

        public override void Draw()
        {
            ResetTurtle();
            Turtle.Rotate(30);
            for (int i = 0; i < 3; i++)
            {
                Turtle.Forward(Side);
                Turtle.Rotate(120);
            }
        }

        public override void Resize(float x, float y)
        {
            //Ignore Y
            Side = x;
        }
    }
}

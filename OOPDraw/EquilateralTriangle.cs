using Nakov.TurtleGraphics;

namespace OOPDraw
{
    public class EquilateralTriangle : Shape
    {
        //Properties
        private float SideLength { get; set; }

        //The 'Constructor'
        public EquilateralTriangle(float xOrigin, float yOrigin, float sideLength) : base(xOrigin, yOrigin)
        {
            SideLength = sideLength;
        }

        public override void Draw()
        {
            ResetTurtle();
            Turtle.Rotate(30);
            for (int i = 0; i < 3; i++)
            {
                Turtle.Forward(SideLength);
                Turtle.Rotate(120);
            }
        }

        public override void Resize(float x, float y)
        {
            //Ignore Y
            SideLength = x;
        }
    }
}

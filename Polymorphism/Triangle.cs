namespace Polymorphism
{
    public class Triangle : Shape
    {

        public bool pointDownWards = false;
        public Triangle(int x, int y, int width, int height) : base(x, y, width, height) { }

        public override void Draw()
        {
            //logic to draw the triangle on a canvas
        }
    }
}

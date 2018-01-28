using System.Drawing;

namespace OOPDraw
{
    public class MyDrawing
    {
        public static void Draw()
        {
            var body = new Square(0,0,Color.Blue, 100);
            body.Draw();
            var cab = new Square(100, 0, Color.Red, 50);
            cab.Draw();
            var frontWheel = new Circle(125, -10, Color.Black, 10);
            frontWheel.Draw();
            var rearWheel = new Circle(25, -10, Color.Black, 10);
            rearWheel.Draw();
        }
    }
}

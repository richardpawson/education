using System.Collections.Generic;
using System.Drawing;

namespace OOPDraw
{
    public class MyDrawing
    {
        public static void Execute()
        {
            var list = new List<Shape>();
            var body = new Square(50, 50, Color.Blue, 100);
            list.Add(body);
            var cab = new Square(125, 25, Color.Red, 50);
            list.Add(cab);
            var frontWheel = new Circle(125, -10, Color.Black, 10);
            list.Add(frontWheel);
            var rearWheel = new Circle(25, -10, Color.Black, 10);
            list.Add(rearWheel);

            foreach (var item in list)
            {
                item.GrowBy(2);
                item.Draw();
            }
        }
    }
}

using Nakov.TurtleGraphics;
using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace OOPDraw
{
    public class MyDrawing
    {
        public static void Draw()
        {
            var walls = new Square(0, 0, 100, Color.Blue);
            var circ = new Circle(0, 0, 50, Color.Red);
            walls.Draw();
            Program.RefreshDisplay();
            Program.WaitASecond();
            Program.ClearDisplay();
            walls.PositionX = 50;
            circ.Draw();
            walls.Draw();

        }

    }
}

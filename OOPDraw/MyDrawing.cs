using Nakov.TurtleGraphics;
using System;
using System.Drawing;

namespace OOPDraw
{
    public class MyDrawing
    {
        public static void Draw()
        {
            var body = new Square(0,0,Color.Blue, 100);
            DrawSquare(body);
            var cab = new Square(100, 0, Color.Red, 50);
            DrawSquare(cab);
            var frontWheel = new Circle(125, -10, Color.Black, 10);
            DrawCircle(frontWheel);
            var rearWheel = new Circle(25, -10, Color.Black, 10);
            DrawCircle(rearWheel);
        }

        private static void DrawSquare(Square sq)
        {
            Turtle.X = sq.PositionX;
            Turtle.Y = sq.PositionY;
            Turtle.PenColor = sq.LineColor;
            for (int i = 0; i < 4; i++)
            {
                Turtle.Forward(sq.SideLength);
                Turtle.Rotate(90);
            }
        }

        private static void DrawCircle(Circle c)
        {
            Turtle.X =c.PositionX;
            Turtle.Y = c.PositionY;
            Turtle.PenColor = c.LineColor;
            for (int i = 0; i < 360; i++)
            {
                Turtle.Forward((float) (2 * Math.PI * c.Radius /360));
                Turtle.Rotate(1);
            }
        }
    }
}

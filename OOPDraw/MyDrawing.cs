using Nakov.TurtleGraphics;
using System;
using System.Drawing;

namespace OOPDraw
{
    public class MyDrawing
    {
        public static void Draw()
        {
            Square(0,0,Color.Blue, 100);
            Square(100, 0, Color.Red, 50);
            Circle(125, -10, Color.Black, 10);
            Circle(25, -10, Color.Black, 10);
        }

        private static void Square(float positionX, float positionY, Color color, float sideLength)
        {
            Turtle.X = positionX;
            Turtle.Y = positionY;
            Turtle.PenColor = color;
            for (int i = 0; i < 4; i++)
            {
                Turtle.Forward(sideLength);
                Turtle.Rotate(90);
            }
        }

        private static void Circle(float positionX, float positionY, Color color, float radius)
        {
            Turtle.X = positionX;
            Turtle.Y = positionY;
            Turtle.PenColor = color;
            for (int i = 0; i < 360; i++)
            {
                Turtle.Forward((float) (2 * Math.PI * radius /360));
                Turtle.Rotate(1);
            }
        }
    }
}

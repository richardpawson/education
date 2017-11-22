using Nakov.TurtleGraphics;

namespace TurtleGraphics
{
    public static class SnowFlake
    {
        public static void Draw(int size, int level)
        {
            Turtle.PenSize = 1;
            for (int n = 1; n <= 3; n++)
            {
                DrawSide(size, level);
                Turtle.Rotate(-120);
            }
        }

        private static void DrawSide(int lineLength, int level)
        {
            if (level <= 1)
            {
                Turtle.Forward(lineLength);
            }
            else
            {
                int aThird = lineLength / 3;
                DrawSide(aThird, level - 1);
                Turtle.Rotate(60);
                DrawSide(aThird, level - 1);
                Turtle.Rotate(-120);
                DrawSide(aThird, level - 1);
                Turtle.Rotate(60);
                DrawSide(aThird, level - 1);
            }
        }
    }
}

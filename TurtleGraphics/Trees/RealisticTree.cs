using Nakov.TurtleGraphics;
using System;

namespace Trees
{
    public class RealisticTree
    {
        float size;
        float branchMin;
        float branchMax;
        int angleMin;
        int angleMax;
        Random rand;
        float maxLevel;

        public RealisticTree(float size, float branchMin, float branchMax, int angleMin, int angleMax, float level)
        {
            this.size = size;
            this.branchMin = branchMin/100;
            this.branchMax = branchMax/100;
            this.angleMin = angleMin;
            this.angleMax = angleMax;
            this.maxLevel = level;
            rand = new Random();
            Turtle.PenColor = System.Drawing.Color.Brown;
            Turtle.PenSize = 1;
            Draw(size, maxLevel);
        }


        public void Draw(float length, float level)
        {

            if (level <= 0)
            {
                return;
            }
            else
            {
                int minLength = Convert.ToInt32(length * branchMin);
                int maxLength = Convert.ToInt32(length * branchMax);
                float trunk = Random(minLength, maxLength);
                float girth = size/20 * (level/maxLevel);
                Turtle.PenSize = girth;
                float shoot = length - trunk;
                Turtle.Forward(trunk);
                float angle = Random(angleMin, angleMax);
                Turtle.Rotate(angle);
                Draw(shoot, level - 1);
                Turtle.Rotate(-angle);
                angle = Random(angleMin, angleMax);
                Turtle.Rotate(-angle);
                Draw(shoot, level - 1);
                Turtle.Rotate(angle);
                Turtle.Backward(trunk);
            }
        }


        private int Random(int min, int max)
        {
            return rand.Next(min, max);
        }
    }
}

using Nakov.TurtleGraphics;


namespace Trees
{
    public class RegularTree
    {
        int branchRatio;
        int angle;

        public RegularTree(int branchRatio, int angle)
        {
            this.branchRatio = branchRatio;
            this.angle = angle;
            Turtle.PenColor = System.Drawing.Color.Black;
            Turtle.PenSize = 1;
        }

        public void Draw(int length, int level)
        {
            
            if (level <=0)
            {
                return;
            } else
            {
                int trunk = length / branchRatio;
                int shoot = length - trunk;
                Turtle.Forward(trunk);
                Turtle.Rotate(angle);
                Draw(shoot, level -1);
                Turtle.Rotate(-angle);
                Turtle.Rotate(-angle);
                Draw(shoot, level-1);
                Turtle.Rotate(angle);
                Turtle.Backward(trunk);
            }
        }
    }
}

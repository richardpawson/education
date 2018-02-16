using System;
using Nakov.TurtleGraphics;

namespace OOPDraw
{
    public abstract class Shape
    {
        protected float XOrigin { get; set; }
        protected float YOrigin { get; set; }
        private float LineWidth { get; set; }

        //The 'Constructor'
        public Shape(float xOrigin, float yOrigin)
        {
            XOrigin = xOrigin;
            YOrigin = yOrigin;
        }

        //Abstract methods
        public abstract void Draw();

        //Concrete methods
        public virtual void MoveTo(float x, float y)
        {
            XOrigin = x;
            YOrigin = y;
        }

        public virtual void MoveBy(float x, float y)
        {
            XOrigin += x;
            YOrigin += y;
        }
        public void ResizeAbsolute(float turtleX, float turtleY)
        {
            Resize(Math.Abs(turtleX - XOrigin), Math.Abs(turtleY - YOrigin));
        }

        public abstract void Resize(float x, float y);

        public virtual void Select()
        {
            LineWidth = 4;
        }

        public virtual void Unselect()
        {
            LineWidth = 2;
        }

        protected void ResetTurtle()
        {
            Turtle.ShowTurtle = false;
            Turtle.PenSize = LineWidth;
            Turtle.Angle = 0;  //Always start from North
            Turtle.X = XOrigin;
            Turtle.Y = YOrigin;
        }

    }
}

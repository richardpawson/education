using Nakov.TurtleGraphics;
using System.Drawing;
using System;

namespace OOPDraw
{
    public abstract class Shape
    {
        //Properties
        public float OriginX { get;  set; }
        public float OriginY { get;  set; }
        public float LineWidth { get; private set; }

        public Shape(float centreX, float centreY)
        {
            OriginX = centreX;
            OriginY = centreY;
        }

        //Abstract methods -  to be implemeted in sub-types
        public abstract void Draw();

        public void ResizeTo(int x, int y)
        {
            Resize(Math.Abs(x - OriginX), Math.Abs(y - OriginY));
        }

        public abstract void Resize(float x, float y);

        //Concrete methods
        public virtual void MoveTo(float x, float y)
        {
            OriginX = x;
            OriginY = y;
        }

        public virtual void MoveBy(float x, float y)
        {
            OriginX += x;
            OriginY += y;
        }

        public virtual void Select()
        {
            LineWidth = 4;
        }

        public virtual void Unselect()
        {
            LineWidth = 2;
        }

        /// <summary>
        /// Reset's the position, angle, pen size and colour to the specified properties for this shape
        /// </summary>
        protected void ResetTurtle()
        {
            Turtle.Angle = 0;
            Turtle.PenColor = Color.Black;
            Turtle.PenSize = LineWidth;
            Turtle.X = OriginX;
            Turtle.Y = OriginY;
        }
    }
}

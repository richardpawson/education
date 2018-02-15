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
        public bool Selected { get; private set; }

        public Shape(float centreX, float centreY)
        {
            OriginX = centreX;
            OriginY = centreY;
            LineWidth = 2;
            Selected = true;
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

        /// <summary>
        /// Reset's the position, angle, pen size and colour to the specified properties for this shape
        /// </summary>
        protected void ResetTurtle()
        {
            Turtle.Angle = 0;
            Turtle.PenColor = Color.Black;
            Turtle.PenSize = Selected ? LineWidth*2 : LineWidth;
            Turtle.X = OriginX;
            Turtle.Y = OriginY;
        }


        public virtual void Select()
        {
            Selected = true; 
        }
        public virtual void Unselect()
        {
            Selected = false;
        }
    }
}

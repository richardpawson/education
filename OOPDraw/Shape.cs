using Nakov.TurtleGraphics;
using System.Drawing;

namespace OOPDraw
{
    public abstract class Shape
    {
        //Properties
        public float CentreX { get;  set; }
        public float CentreY { get;  set; }
        public Color LineColor { get; private set; }
        public float LineWidth { get; private set; }
        public bool Selected { get; private set; }

        public Shape(float centreX, float centreY, Color lineColor) : this()
        {
            LineColor = lineColor;
            CentreX = centreX;
            CentreY = centreY;
        }

        //Default constructor
        public Shape()
        {
            LineColor = Color.Black;
            CentreX = 0;
            CentreY = 0;
            LineWidth = 2;
            Selected = true;
        }

        //Abstract methods -  to be implemeted in sub-types
        public abstract void Draw();

        public abstract void Resize(float x, float y);

        //Concrete methods
        public virtual void MoveTo(float x, float y)
        {
            CentreX = x;
            CentreY = y;
        }

        public virtual void MoveBy(float x, float y)
        {
            CentreX += x;
            CentreY += y;
        }

        /// <summary>
        /// Reset's the position, angle, pen size and colour to the specified properties for this shape
        /// </summary>
        protected void ResetTurtle()
        {
            Turtle.Angle = 0;
            Turtle.PenColor = LineColor;
            Turtle.PenSize = Selected ? LineWidth*2 : LineWidth;
            Turtle.X = CentreX;
            Turtle.Y = CentreY;
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

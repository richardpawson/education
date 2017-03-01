using System;
using System.Drawing;
using System.Text;

namespace Drawing.Model
{
    public abstract class Shape
    {
        public Shape(int originX, int originY)
        {
            OriginX = originX;
            OriginY = originY;
        }

        protected int OriginX { get; set; }
        protected int OriginY { get; set; }

        #region Concrete methods
        public void MoveTo(int x, int y)
        {
            OriginX = x;
            OriginY = y;
        }

        public void MoveBy(int x, int y)
        {
            OriginX += x;
            OriginY += y;
        }

        protected string PositionSummary()
        {
            return " @ coordinates " + OriginX + "," + OriginY;
        }
        #endregion

        #region Abstract methods
        public abstract string Summary();
        public abstract void GrowBy(double percent);
        #endregion

        #region Static methods 
        public static string SummariseMultiple(Shape[] shapes)
        {
            var sb = new StringBuilder();
            foreach (var shape in shapes)
            {
                sb.AppendLine(shape.Summary());
            }
            return sb.ToString();
        }

        public static void GrowMultiple(Shape[] shapes, int percent)
        {
            // iterate (loop) over array and delegate to equivalent method on each
            foreach (var shape in shapes)
            {
                shape.GrowBy(percent);
            }
        }

        
        #endregion
    }
}

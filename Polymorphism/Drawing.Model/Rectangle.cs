using System;

namespace Drawing.Model
{
    public class Rectangle : Shape
    {
        public double Height { get; protected set; }
        public double Width { get; protected set; }
        
        //Constructor
        public Rectangle(int originX, int originY, double height, double width) : base(originX, originY)
        {
            Height = height;
            Width = width;
        }
        // Provides a string representation of the object
        public override string Summary()
        {
            //... and we use self to access properties or other methods
            return "Rectangle, H " + Height + " W " + Width + PositionSummary();
        }
        public override void GrowBy(double percent)
        {
            Height = Height * (1 + percent / 100);
            Width = Width * (1 + percent / 100);
        }
    }
}


using System;

namespace Drawing.Model
{
    // Provides same methods as Rectangle, but different implementations
    public class Circle : Shape
    {
        protected double Radius { get; set; }

        public Circle(int originX, int originY, double radius) : base(originX,  originY)
        {
            this.Radius = radius;
        }
        public override void GrowBy(double percent)
        {
            Radius = Radius * (1 + percent / 100);
        }
        public override string Summary()
        {
            return "Circle, radius " + Radius + PositionSummary();
        }
    }
}

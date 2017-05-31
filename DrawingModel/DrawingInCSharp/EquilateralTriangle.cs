using System;

namespace DrawingCSharp
{
    public class EquilateralTriangle : IShape, IRotatable
    {
        double side = 0;
        double orientation = 0;

        public EquilateralTriangle(double side)
        {
            this.side = side;
        }

        public void GrowBy(double percent)
        {
            side = side * (1 + percent / 100);
        }

        public string Summary()
        {
            return "Equilateral Triangle, side: " + side + " orientation:" + orientation;
        }

        public void RotateBy(int degrees)
        {
            orientation = (orientation + degrees) % 360;
        }

        public byte[] DrawAsBitMap()
        {
            throw new NotImplementedException();
        }
    }
}

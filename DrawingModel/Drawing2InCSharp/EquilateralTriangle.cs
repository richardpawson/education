using System;

namespace Drawing2CSharp
{
    public class EquilateralTriangle : Shape, IRotatable
    {
        double side = 0;
        double orientation = 0;

        public EquilateralTriangle(double side)
        {
            this.side = side;
        }

        public override void GrowBy(double percent)
        {
            side = side * (1 + percent / 100);
        }

        public override string Summary()
        {
            return "Equilateral Triangle, side: " + side + " orientation:" + orientation;
        }

        public void RotateBy(int degrees)
        {
            orientation = (orientation + degrees) % 360;
        }

        public override byte[] DrawAsBitMap()
        {
            throw new NotImplementedException();
        }
    }
}

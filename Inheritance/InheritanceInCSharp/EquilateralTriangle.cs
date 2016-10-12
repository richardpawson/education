namespace InheritanceInCSharp
{
    public class EquilateralTriangle : RotatableShape
    {
        double side = 0;

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


    }
}

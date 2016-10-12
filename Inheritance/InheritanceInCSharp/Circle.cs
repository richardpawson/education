namespace InheritanceInCSharp
{
    public class Circle : BaseShape
    {
        double radius = 0;
        public Circle(double r)
        {
            radius = r;
        }
        public override void GrowBy(double percent)
        {
            radius = radius * (1 + percent / 100);
        }
        public override string Summary()
        {
            return "Circle, radius: " + radius;
        }
    }

}

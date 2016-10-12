namespace InheritanceInCSharp
{
    public class Circle : IShape
    {
        double radius = 0;
        public Circle(double r)
        {
            radius = r;
        }
        public void GrowBy(double percent)
        {
            radius = radius * (1 + percent / 100);
        }
        public string Summary()
        {
            return "Circle, radius: " + radius;
        }
    }

}

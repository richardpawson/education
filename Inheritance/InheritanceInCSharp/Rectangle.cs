namespace InheritanceInCSharp
{

    public class Rectangle : RotatableShape
    {
        double height = 0;
        double width = 0;

        //Constructor
        public Rectangle(double h, double w)
        {
            height = h;
            width = w;
        }
        // Provides a string representation of the object
        public override string Summary()
        {
            //... and we use self to access properties or other methods
            return "Rectangle, H: " + height + " W: " + width + " orientation:" + orientation;
        }
        public override void GrowBy(double percent)
        {
            height = height * (1 + percent / 100);
            width = width * (1 + percent / 100);
        }

    }

}

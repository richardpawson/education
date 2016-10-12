namespace InheritanceInCSharp
{

    public class Rectangle : IRotatable, IShape
    {
        double height = 0;
        double width = 0;
        double orientation = 0;

        //Constructor
        public Rectangle(double h, double w)
        {
            height = h;
            width = w;
        }
        // Provides a string representation of the object
        public string Summary()
        {
            //... and we use self to access properties or other methods
            return "Rectangle, H: " + height + " W: " + width + " orientation:" + orientation;
        }
        public void GrowBy(double percent)
        {
            height = height * (1 + percent / 100);
            width = width * (1 + percent / 100);
        }

        public void RotateBy(int degrees)
        {
            orientation = (orientation + degrees) % 360;
        }
    }

}

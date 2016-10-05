using System;
public class Rectangle
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
    public string Summary()
    {
        //... and we use self to access properties or other methods
        return "Rectangle, H: " + height + " W: " + width;
    }
    public void GrowBy(double percent)
    {
        height = height * (1 + percent / 100);
        width = width * (1 + percent / 100);
    }
}

// Provides same methods as Rectangle, but different implementations
public class Circle
{
    double radius = 0;
    public Circle(double r)
    {
        radius = r;
    }
    public void growBy(double percent)
    {
        radius = radius * (1 + percent / 100);
    }
    public string summary()
    {
        return "Circle, radius: " + radius;
    }
}

public class Program {

    private static Circle[] drawing1 = 
        new Circle[] { new Circle(3), new Circle(4), new Circle(10) };

    static void growAll(Circle[] shapes, int percent) {
        // iterate (loop) over array and delegate to equivalent method on each
        foreach (var shape in shapes) {
            shape.growBy(percent);
        }
    }

    static void summariseAll(Circle[] shapes)
    {
        foreach (var shape in shapes)
        {
            Console.WriteLine(shape.summary());
        }
    }

// Main program here...
    public static void Main() {
        summariseAll(drawing1);
        growAll(drawing1, 50);
        summariseAll(drawing1);
        //To keep console open
        Console.ReadKey();
    }
}
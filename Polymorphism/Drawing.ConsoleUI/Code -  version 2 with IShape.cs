using System;

public interface IShape
{
    string Summary();
    void GrowBy(double percent);
}

public class Rectangle : IShape
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

public class Program {

    private static IShape[] drawing1 = 
        new IShape[] { new Circle(3), new Circle(4), new Rectangle(2, 7), new Circle(10) };

    static void GrowAll(IShape[] shapes, int percent) {
        // iterate (loop) over array and delegate to equivalent method on each
        foreach (var shape in shapes) {
            shape.GrowBy(percent);
        }
    }

    static void SummariseAll(IShape[] shapes)
    {
        foreach (var shape in shapes)
        {
            Console.WriteLine(shape.Summary());
        }
    }

// Main program here...
    public static void Main() {
        Console.WriteLine("Polymorphism in C#");
        SummariseAll(drawing1);
        GrowAll(drawing1, 50);
        Console.WriteLine();
        Console.WriteLine("After growing all by 50%:");
        SummariseAll(drawing1);

        //To keep console open
        Console.WriteLine("Press any key to continue . . .");
        Console.ReadKey();
    }
}
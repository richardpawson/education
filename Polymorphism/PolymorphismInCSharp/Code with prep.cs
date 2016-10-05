using System;
using System.Linq;

public interface IShape
{
    string Summary();
    void GrowBy(double percent);
}

public interface IRotatable
{

    void RotateBy(int degrees);
}

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
        return "Equilateral Triangle, side: " + side + " orientation:"+orientation;
    }

    public void RotateBy(int degrees)
    {
        orientation = (orientation + degrees) % 360;
    }
}
public class Program {

    private static IShape[] drawing1 = 
        new IShape[] { new Circle(3), new Circle(4), new Rectangle(2, 7), new Circle(10), new EquilateralTriangle(8) };

    static void GrowAll(IShape[] shapes, int percent) {
        // iterate (loop) over array and delegate to equivalent method on each
        foreach (var shape in shapes) {
            shape.GrowBy(percent);
        }
    }

    static void RotateAllRotatable(IShape[] shapes, int degrees)
    {
        //You will need to add 'using System.Linq;' at the top of the file
        foreach (var rotatableObject in shapes.OfType<IRotatable>())
        {
            rotatableObject.RotateBy(degrees);
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

        RotateAllRotatable(drawing1, 90);
        Console.WriteLine("After rotating all by 90:");
        SummariseAll(drawing1);


    
        //To keep console open
        Console.WriteLine("Press any key to continue . . .");
        Console.ReadKey();
    }
}
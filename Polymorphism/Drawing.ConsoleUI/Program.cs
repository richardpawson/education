using Drawing.DataFixture;
using Drawing.Model;
using System;

namespace Drawing.ConsoleUI {

    public class Program
    {
        public static void Main()
        {
            Console.WriteLine(Shape.SummariseMultiple(Examples.Drawing1));
            Shape.GrowMultiple(Examples.Drawing1, 50);
            Console.WriteLine();
            Console.WriteLine("After growing all by 50%:");
            Console.Write(Shape.SummariseMultiple(Examples.Drawing1));

            //To keep console open
            Console.WriteLine();
            Console.WriteLine("Press any key to continue . . .");
            Console.ReadKey();
        }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Calculate the Hypotenuse (side A), given sides B & C.");
            Console.Write("Specify side B. ");
            double b = InputDouble();
            Console.Write("Specify side C. ");
            double c = InputDouble();
            Console.Write("Side A is: ");
            Console.WriteLine(Pythagoras(b, c));

            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }

        static int InputInteger()
        {
            bool success = false;
            int result = 0;
            while (success == false)
            {
                Console.Write("Please enter a whole number: ");
                string userInput = Console.ReadLine();
                success = int.TryParse(userInput, out result);
            }
            return result;
        }

        static double InputDouble()
        {
            bool success = false;
            double result = 0;
            while (success == false)
            {
                Console.Write("Please enter a number: ");
                string userInput = Console.ReadLine();
                success = double.TryParse(userInput, out result);
            }
            return result;
        }

        static double Pythagoras(double b, double c)
        {
            return Math.Sqrt(b * b + c * c);
        }

        static double CircumferenceOfCircle(double radius)
        {
            return 2 * Math.PI * radius;
        }

        static double AreaOfCircle(double radius)
        {
            return Math.PI * radius * radius;
        }
    }
}

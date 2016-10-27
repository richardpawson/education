using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to C#");

            while (true) //Infinite loop
            {
                Console.WriteLine(); //Blank line
                Console.WriteLine("Enter a whole number between 1 and 10 (or 'x' to exit): ");
                string input = Console.ReadLine();
                if (input == "x") return; // return exits the Main program. No need for braces if only a single statement
                int value = int.Parse(input); //TODO: Really need to trap error if non-integer is added
                if (value > 10 || value < 1)  
                {
                    Console.WriteLine("Invalid input");
                }
                else
                {
                    Console.WriteLine("Factorial of " + value + " is " + Factorial(value));
                }
            }
        }
        public static int Factorial(int value) 
        {
            int result = 1;
            while (value > 1)
            {
                result = result * value;
                value -= 1;
            }
            return result;
        }
    }
}

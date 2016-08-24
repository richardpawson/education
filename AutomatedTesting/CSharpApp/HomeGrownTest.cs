using System;

namespace CSharpApp
{
    class HomeGrownTest
    {
        static void Main(string[] args)
        {
            TestConversion(1, Conversions.ToCelcius(68), 20);
            TestConversion(2, Conversions.ToCelcius(212), 100);
            TestConversion(3, Conversions.ToCelcius(32), 0);

            Console.ReadKey(); //Waits for a single key input before terminating.
        }

        static void TestConversion(int testNumber, decimal actual, decimal expected)
        {
            if (actual == expected)
            {
                Console.WriteLine("Test " + testNumber + " passed");
            }
            else
            {
                Console.WriteLine("Test " + testNumber + " failed, Expected: " + expected + ", was: " + actual);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PowersOf2CS
{
    public class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Write("Enter the power of 2 required: ");
                int power = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine(TwoToThePowerOf(power));
                Console.WriteLine();
            }
        }

        public static string TwoToThePowerOf(int power)
        {
            var d = new List<int> { 1 };
            for (int i = 0; i < power; i++)
            {
                d = MultiplyByTwo(d);
            }
            var builder = new StringBuilder();
            foreach (int digit in d)
            {
                builder.Append(digit);
            }
            return builder.ToString();
        }

        static List<int> MultiplyByTwo(List<int> digits, int carryIn = 0)
        {
            if (digits.Count == 0)
            {
                return digits;
            }
            else
            {
                //Double digit to get new digit and carry
                var lowestDigit = digits.Last();
                var doubledValue = lowestDigit * 2 + carryIn;
                int carry = doubledValue / 10;
                var newLowestDigit = doubledValue % 10;

                if (carry > 0 && digits.Count == 1) //Create a new higher digit
                {
                    return new List<int> { carry, newLowestDigit };
                }
                else
                {
                    var higherDigits = digits.Take(digits.Count - 1).ToList(); //All but lowest digit
                    var digitsDoubled = MultiplyByTwo(higherDigits, carry); //Recursive call
                    digitsDoubled.Add(newLowestDigit);
                    return digitsDoubled;
                }
            }
        }

        #region MkII  -  work directly with strings
        public static string TwoToThePowerOfMkII(int power)
        {
            var d = "1";
            for (int i = 0; i < power; i++)
            {
                d = MultiplyByTwoMkII(d);
            }
            return d;
        }
        static string MultiplyByTwoMkII(string digits, int carryIn = 0)
        {
            if (digits.Count() == 0)
            {
                return digits;
            }
            else
            {
                //Double digit to get new digit and carry
                int lowestDigit = Convert.ToInt32(digits.Last()) - 48; //ASCII 48 = '0'
                var doubledValue = lowestDigit * 2 + carryIn;
                int carry = doubledValue / 10;
                var newLowestDigit = doubledValue % 10;

                if (carry > 0 && digits.Count() == 1) //Create a new higher digit
                {
                    return carry.ToString() + newLowestDigit;
                }
                else
                {
                    var higherDigits = digits.Substring(0, digits.Count() - 1); //All but lowest digit
                    var digitsDoubled = MultiplyByTwoMkII(higherDigits, carry); //Recursive call
                    digitsDoubled += newLowestDigit;
                    return digitsDoubled;
                }
            }
        }
        #endregion
    }
}

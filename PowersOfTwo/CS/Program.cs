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

        #region MkI - use int arrays
        public static string TwoToThePowerOfMkI(int power)
        {
            var d = new List<int> { 1 };
            for (int i = 0; i < power; i++)
            {
                d = MultiplyByTwoMkI(d);
            }
            var builder = new StringBuilder();
            foreach (int digit in d)
            {
                builder.Append(digit);
            }
            return builder.ToString();
        }

        static List<int> MultiplyByTwoMkI(List<int> digits, int carryIn = 0)
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
                    var digitsDoubled = MultiplyByTwoMkI(higherDigits, carry); //Recursive call
                    digitsDoubled.Add(newLowestDigit);
                    return digitsDoubled;
                }
            }
        }
        #endregion

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

        #region No recursion
        public static string TwoToThePowerOf(int power)
        {
            string number = "1";
            for (int i = 0; i < power; i++)
            {
                number = MultiplyByTwo(number);
            }
            return number;
        }
        private static string MultiplyByTwo(string digits)
        {
            StringBuilder builder = new StringBuilder(digits.Length + 1); //Initialising to maximum length is more efficient
            int carry = 0;
            for (int i = digits.Length-1; i >=0; i--) //Least significant digit first
            {
                //Double the digit:
                int digit = Convert.ToInt32(digits[i]) - 48; //ASCII 48 = '0'
                int doubledValue = digit * 2 + carry; //Carry is 'carry-in' here
                carry = doubledValue / 10; //Carry is now 'carry-out'
                int newDigit = doubledValue % 10;
                //Add to front of new string:
                builder.Insert(0, newDigit);
            }
            if (carry > 0) //Add final new digit up front
            {
                builder.Insert(0, carry);
            }
            return builder.ToString();
        }
        #endregion
    }
}

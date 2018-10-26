using System.Collections.Generic;

namespace CSharpRomanNumerals
{
    public static class Convertor
    {
        private static readonly int[] values = new int[] { 1000, 900, 500, 400, 100, 90, 50, 40, 10, 9, 5, 4, 1 };
        private static readonly string[] symbols = new string[] { "M", "CM", "D", "CD", "C", "XC", "L", "XL", "X", "IX", "V", "IV", "I" };

        public static string Roman(int d)
        {
            var result = "";
            for (int i = 0; i < values.Length; i++)
            {
                var value = values[i];
                while (d >= value)
                {
                    result += symbols[i];
                    d -= value;
                }
            }
            return result;
        }
    }
}

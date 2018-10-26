using System.Collections.Generic;
using System.Text;

namespace CSharpRomanNumerals
{
    public static class Convertor
    {
        public static string Roman(int d)
        {
            var values = new int[] { 1000, 900, 500, 400, 100, 90, 50, 40, 10,9, 5, 4, 1 };
            var symbols = new string[] { "M", "CM", "D", "CD", "C", "XC", "L", "XL", "X", "IX", "V", "IV", "I" };
            var result = new StringBuilder();
            for (int i = 0; i < values.Length; i++)
            {
                var value = values[i];
                while (d >= value)
                {
                    result.Append(symbols[i]);
                    d -= value;
                }
            }
            return result.ToString();
        }
    }
}

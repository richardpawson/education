using System.Collections.Generic;
using System.Linq;

namespace CSharpRomanNumerals
{
    public static class Convertor
    {

        private static readonly int[] values = new int[] { 1000, 900, 500, 400, 100, 90, 50, 40, 10, 9, 5, 4, 1 };
        private static readonly string[] symbols = new string[] { "M", "CM", "D", "CD", "C", "XC", "L", "XL", "X", "IX", "V", "IV", "I" };

        public static string Roman(int d, int symbolNo = 0)
        {
            if (symbolNo > 12)
            {
                return "";
            }
            var value = values[symbolNo];
            var symbol = symbols[symbolNo];
            if (d >= value)
            {
                return symbol + Roman(d - value);
            } else
            {
                return Roman(d, symbolNo + 1);
            }
        }
    }
}

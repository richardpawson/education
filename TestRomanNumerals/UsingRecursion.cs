using System.Linq;

namespace CSharpRomanNumerals
{
    public static class Convertor
    {
        public static string AsRomanNumeral(int number, int[] values, string[] symbols)
        {
            return number >= values[0] ?
                symbols[0] + AsRomanNumeral(number - values[0], values, symbols):
                   values.Skip(1).Count() == 0? "": AsRomanNumeral(number, values.Skip(1).ToArray(), symbols.Skip(1).ToArray());
        }

        public static string AsRomanNumeral(int number)
        {
            return AsRomanNumeral(number,
                new int[] { 1000, 900, 500, 400, 100, 90, 50, 40, 10, 9, 5, 4, 1 },
                new string[] { "M", "CM", "D", "CD", "C", "XC", "L", "XL", "X", "IX", "V", "IV", "I" });
        }
    }
}

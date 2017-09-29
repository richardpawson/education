using System.Collections.Generic;
using System.Text;

namespace CSharpRomanNumerals
{
    public static class Convertor
    {
        private static Dictionary<int, string> symbols = new Dictionary<int, string>
            {
                {1000, "M"},{900, "CM"},{500, "D"},{400, "CD"},{100, "C"},{90, "XC"},
                { 50, "L"},{ 40, "XL"},{10, "X"},{9, "IX"},{5, "V"},{4, "IV"},{1, "I"}
            };
        public static string AsRomanNumeral(int number)
        {
            var result = new StringBuilder();
            foreach (int value in symbols.Keys)
            {
                while (number >= value)
                {
                    result.Append(symbols[value]);
                    number -= value;
                }
            }
            return result.ToString();
        }
    }
}

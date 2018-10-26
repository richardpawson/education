using System.Collections.Generic;

namespace CSharpRomanNumerals
{
    public static class Convertor
    {
        private static readonly Dictionary<int, string> symbols = new Dictionary<int, string>
            {
                {1000, "M"},{900, "CM"},{500, "D"},{400, "CD"},{100, "C"},{90, "XC"},
                { 50, "L"},{ 40, "XL"},{10, "X"},{9, "IX"},{5, "V"},{4, "IV"},{1, "I"}
            };

        public static string Roman(int d)
        {
            var result = "";
            foreach (int value in symbols.Keys)
            {
                while (d >= value)
                {
                    result += symbols[value];
                    d -= value;
                }
            }
            return result;
        }
    }
}

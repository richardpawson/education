using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpRomanNumerals
{
    public static class Convertor
    {
        /// <summary>
        /// Converts an Arabic integer number to a (string) Roman numeral form. 
        /// </summary>
        /// <param name="number">The (Arabic) number you wish to convert</param>
        /// <returns></returns>
        public static string AsRomanNumeral(int number)
        {
            string[] symbols = { "M", "CM", "D", "CD", "C", "XC", "L", "XL", "X", "IX", "V", "IV", "I" };
            int[] values = { 1000, 900, 500, 400, 100, 90, 50, 40, 10, 9, 5, 4, 1 };
            var roman = ""; //Better: var roman = new StringBuilder;
            for (int i = 0; i < symbols.Length; i++)
            {
                while (number >= values[i])
                {
                    number -= values[i];
                    roman += symbols[i]; //roman.Append(symbols[i]);
                }
            }
            return roman; //return roman.ToString();
        }
    }
}

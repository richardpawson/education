using System.Collections.Generic;
using System.Text;

namespace CSharpRomanNumerals
{
    public static class Convertor
    {


        public static string Roman(int d)
        {
            string result = "";
            ProcessSymbol(1000, "M", ref d, ref result);
            ProcessSymbol(900, "CM", ref d, ref result);
            ProcessSymbol(500, "D", ref d, ref result);
            ProcessSymbol(400, "CD", ref d, ref result);
            ProcessSymbol(100, "C", ref d, ref result);
            ProcessSymbol(90, "XC", ref d, ref result);
            ProcessSymbol(50, "L", ref d, ref result);
            ProcessSymbol(40, "XL", ref d, ref result);
            ProcessSymbol(10, "X", ref d, ref result);
            ProcessSymbol(9, "IX", ref d, ref result);
            ProcessSymbol(5, "V", ref d, ref result);
            ProcessSymbol(4, "IV", ref d, ref result);
            ProcessSymbol(1, "I", ref d, ref result);
            return result;
        }

        private static void ProcessSymbol(int n, string x,ref int d, ref string result)
        {
            while (d >= n)
            {
                d -= n;
                result += x;
            }
        }
    }
}

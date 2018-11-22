using Quadrivia.FunctionalLibrary;
using System;

namespace CSharpRomanNumerals
{
    public static class Convertor
    {
        public static string Roman(int n)
        {
            var units = FList.New(U("M", 1000), U("CM", 900), U("D", 500), U("CD", 400), U("C", 100), U("XC", 90), U("L", 50), U("XL", 40), U("X", 10), U("IX", 9), U("V", 5), U("IV", 4), U("I", 1));
            var usable = FList.Filter(u => u.Item2 <= n,units);
            return n == 0 ? "" : FList.Head(usable).Item1 + Roman(n - FList.Head(usable).Item2);          
        }

        private static Tuple<string, int> U(string s, int n)
        {
            return Tuple.Create(s, n);
        }
    }
}

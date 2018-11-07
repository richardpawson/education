using FunctionalLibrary;

namespace CSharpRomanNumerals
{
    public static class Convertor
    {


        public static string Roman(int d)
        {
            return RomanUsingSymbols(d,
                FList.Cons<int>(1000, 900, 500, 400, 100, 90, 50, 40, 10, 9, 5, 4, 1),
                FList.Cons<string>("M", "CM", "D", "CD", "C", "XC", "L", "XL", "X", "IX", "V", "IV", "I"));
        }

        private static string RomanUsingSymbols(int d, FList<int> ns, FList<string> xs)
        {
            return ns.IsEmpty ?
                 "" :
                 d >= ns.Head ?
                   xs.Head + RomanUsingSymbols(d - ns.Head, ns, xs) :
                   RomanUsingSymbols(d, ns.Tail, xs.Tail);
        }
    }
}

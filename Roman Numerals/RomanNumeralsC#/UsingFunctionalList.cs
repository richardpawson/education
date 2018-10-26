using FunctionalLibrary;

namespace CSharpRomanNumerals
{
    public static class Convertor
    {
        private static string RomanFrom(int d, FList<int> ns, FList<string> xs)
        {
            return ns.IsEmpty ?
                 "" :
                 d >= ns.Head ?
                   xs.Head + RomanFrom(d - ns.Head, ns, xs) :
                   RomanFrom(d, ns.Tail, xs.Tail);
        }

        public static string Roman(int d)
        {
            return RomanFrom(d,
                FList.Cons<int>(1000, 900, 500, 400, 100, 90, 50, 40, 10, 9, 5, 4, 1),
                FList.Cons<string>("M", "CM", "D", "CD", "C", "XC", "L", "XL", "X", "IX", "V", "IV", "I"));
        }
    }
}

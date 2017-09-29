using FunctionalLibrary;

namespace CSharpRomanNumerals
{
    public static class Convertor
    {
        public static string AsRomanNumeral(int number, FList<int> values, FList<string> symbols)
        {
            return number >= values.Head ?
                symbols.Head + AsRomanNumeral(number - values.Head, values, symbols):
                   values.Tail.IsEmpty? "": AsRomanNumeral(number, values.Tail, symbols.Tail);
        }

        public static string AsRomanNumeral(int number)
        {
            return AsRomanNumeral(number,
                FList.Cons<int>(1000, 900, 500, 400, 100, 90, 50, 40, 10, 9, 5, 4, 1),
                FList.Cons<string>("M", "CM", "D", "CD", "C", "XC", "L", "XL", "X", "IX", "V", "IV", "I"));
        }
    }
}

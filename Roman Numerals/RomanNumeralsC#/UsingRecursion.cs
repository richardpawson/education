using System.Collections.Generic;
using System.Linq;

namespace CSharpRomanNumerals
{
    public static class Convertor
    {

public static string Roman(int d)
{
    return RomanFrom(d,
        new int[] { 1000, 900, 500, 400, 100, 90, 50, 40, 10, 9, 5, 4, 1 },
        new string[] { "M", "CM", "D", "CD", "C", "XC", "L", "XL", "X", "IX", "V", "IV", "I" });
}

private static string RomanFrom(int d, IEnumerable<int> ns, IEnumerable<string> xs)
{
    return ns.Count() == 0 ?
                "" :
                d >= ns.First() ?
                xs.First() + RomanFrom(d - ns.First(), ns, xs) :
                RomanFrom(d, ns.Skip(1), xs.Skip(1));
}
    }
}

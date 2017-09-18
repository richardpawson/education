using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    class Program
    {
        //NOTE: long has been used in place of int, to give greater range

        static void Main()
        {
            var set = NaturalNumbers();
            //var set = EvenMembersOf(NaturalNumbers());
            //var set = SquaresOf(NaturalNumbers());
            foreach (var n in set)
            {
                Console.WriteLine(n);
            }
            Console.ReadKey();
        }

        static IEnumerable<long> NaturalNumbers()
        {
            long n = 0;
            while (true)
            {
                yield return n;
                n++;
            }
        }

        static IEnumerable<long> EvenMembersOf(IEnumerable<long> set)
        {
            return set.Where(n => n % 2 == 0);
        }

        static IEnumerable<long> SquaresOf(IEnumerable<long> set)
        {
            return set.Select(n => n * n);
        }

    }
}

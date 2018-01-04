using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    class Program
    {
        private const int max = 100;
        static void Main()
        {
            var set = NaturalNumbers();
            //var set = EvenMembersOf(NaturalNumbers());
            //var set = SquaresOf(NaturalNumbers());
            foreach (var n in set.Take(10))
            {
                Console.WriteLine(n);
            }
            Console.ReadKey();
        }

        static IEnumerable<int> NaturalNumbers()
        {
            return Enumerable.Range(0, max);
        }

        //Alternatively: implement your own enumerable with 'yield'
        //static IEnumerable<long> NaturalNumbers()
        //{
        //    long n = 0;
        //    while (true)
        //    {
        //        yield return n;
        //        n++;
        //    }
        //}

        static IEnumerable<int> EvenMembersOf(IEnumerable<int> set)
        {
            return set.Where(n => n % 2 == 0);
        }

        static IEnumerable<int> SquaresOf(IEnumerable<int> set)
        {
            return set.Select(n => n * n);
        }

    }
}

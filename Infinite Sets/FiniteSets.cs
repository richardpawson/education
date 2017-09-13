using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
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

        static IEnumerable<int> NaturalNumbers()
        {
            return new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        }

        static IEnumerable<int> EvenMembersOf(IEnumerable<int> inputs)
        {
            var evens = new List<int>();
            foreach (var n in inputs)
            {
                if (n % 2 == 0) evens.Add(n);
            }
            return evens;
        }

        static IEnumerable<int> SquaresOf(IEnumerable<int> inputs)
        {
            var squares = new List<int>();
            foreach (var n in inputs)
            {
                squares.Add(n*n);
            }
            return squares;
        }

    }
}

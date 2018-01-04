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
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(set[i]);
            }
            Console.ReadKey();
        }

        static IEnumerable<int> NaturalNumbers()
        {
            const int max = 10;
            int[] array = new int[max];
            for (int i = 0; i < max; i++)
            {
                array[i] = i;
            }
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

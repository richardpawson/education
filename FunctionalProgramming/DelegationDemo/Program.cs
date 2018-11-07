using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunctionalProgramming
{
    class Program
    {
        static string[] text = { "xFoo", "Bar", "FooBar", "QuF", "Yon" };
        static void Main()
        {

            int i = FindFirst(StartsWith("o"));
            Console.WriteLine("Match: " + i);
            Console.ReadKey();
        }

        public static Match Exact(string arg)
        {
            return s => s == arg;
        }

        public static Match Contains(string arg)
        {
            return s => s.Contains(arg);
        }

        public static Match StartsWith(string arg)
        {
            return s => s.StartsWith(arg);
        }

        public static Match EndsWith(string arg)
        {
            return s => s.EndsWith(arg);
        }

        public delegate bool Match(string toBeMatched);

        static int FindFirst(Match match)
        {
            for (int i = 0; i < text.Count(); i++)
            {
                if (match(text[i])) return i;
            }
            return -1;
        }
    }
}

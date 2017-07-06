using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerOfHanoi
{
    class HanoiStack : Stack<int>
    {
        public string Name { get; set; }

        public HanoiStack(string name) : base()
        {
            Name = name;
        }
    }

    class Program
    {
        static HanoiStack A = new HanoiStack("A");
        static HanoiStack B = new HanoiStack("B");
        static HanoiStack C = new HanoiStack("C");

        static void Main(string[] args)
        {
            //B = new Stack<int>(Enumerable.Range(1, 6).Reverse()); Alternative 'Functional' approach!
            for (int disc = 6; disc > 0; disc--)
            {
                B.Push(disc);
            }
            PrintGame("Start");
            MoveTopNDiscs(6, B, C, A);
            PrintGame("Finish");
            Console.ReadKey();
        }

        static void MoveTopNDiscs(int n, HanoiStack source, HanoiStack target, HanoiStack spare)
        {
            if (n == 0)
            {
                return; //Nothing to do  -  start unwinding         
            }
            else
            {
                MoveTopNDiscs(n - 1, source, spare, target);
                int disc = source.Pop();
                Console.WriteLine(String.Format("Moving disc {0} from {1} to {2}", disc, source.Name, target.Name));
                target.Push(disc);
                MoveTopNDiscs(n - 1, spare, target, source);
            }
        }

        static void PrintGame(string stage)
        {
            Console.WriteLine(stage);
            PrintStack(A);
            PrintStack(B);
            PrintStack(C);
            Console.WriteLine();
        }

        static void PrintStack(HanoiStack stack)
        {
            Console.WriteLine(String.Format("{0}: Count: {1} Top disc: {2}", stack.Name, stack.Count, stack.Count > 0 ? stack.Peek().ToString() : null));
        }
    }
}

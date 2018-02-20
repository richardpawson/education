using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerOfHanoi
{
    class HanoiStack
    {
        public string Name { get; set; }

        public HanoiStack(string name, int size, bool fill = false) : base()
        {
            Name = name;
            Discs = new int?[size];
            Top = -1;
            if (fill)
            {
                for (int i = size; i > 0; i--)
                {
                    this.Push(i);
                }
                Top = size - 1;
            }
        }

        private int?[] Discs;

        public int Top { get; private set; }

        public int? Peek()
        {
            return Top >= 0 ? Discs[Top] : 0;
        }

        public int? Pop()
        {
            if (Top >= 0 )
            {
                var disc = Discs[Top];
                Discs[Top] = null;
                Top--;
                return disc;
            } else
            {
                throw new Exception("Stack is empty");
            }
        }

        public void Push(int? disc)
        {
            if (Top >= Discs.Length - 1)
            {
                throw new StackOverflowException();
            } else
            {
                Top++;
                Discs[Top] = disc;
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append(Name).Append(": ");
            foreach(var disc in Discs)
            {
                sb.Append(disc).Append(" ");
            }
            return sb.ToString();
        }
    }

    class Program
    {
        static HanoiStack A = new HanoiStack("A", 6);
        static HanoiStack B = new HanoiStack("B", 6, true);
        static HanoiStack C = new HanoiStack("C", 6);

        static void Main(string[] args)
        {
            
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
                MoveSingleDisc(source, target);
                MoveTopNDiscs(n - 1, spare, target, source);
            }
        }

        static bool CanMoveSingleDisc(HanoiStack source, HanoiStack target)
        {
            return source.Peek() < target.Peek();
        }

        static void MoveSingleDisc(HanoiStack source, HanoiStack target)
        {
            var disc = source.Pop();
            Console.WriteLine(String.Format("Moving disc {0} from {1} to {2}", disc, source.Name, target.Name));
            target.Push(disc);
        }

        static void PrintGame(string stage)
        {
            Console.WriteLine(stage);
            Console.WriteLine(A);
            Console.WriteLine(B);
            Console.WriteLine(C);
            Console.WriteLine();
        }


    }
}

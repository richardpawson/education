using System;

namespace ConsoleApplication16
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = FList.Cons("Flag", FList.Cons("Nest", FList.Cons("Cup", FList.Cons("Burg", FList.Cons("Yatch", FList.Cons("Next"))))));

            var result = mergeSort(list);

            Console.Write(result.ToString());

            Console.ReadKey();
        }


        public static FList<string> mergeSort(FList<string> list)
        {
            if (list.Count() < 2)
            {
                return list;
            }
            else
            {
                var half = list.Count() / 2;
                return Merge(mergeSort(list.Skip(half)), mergeSort(list.Take(half)));
            }
        }

        public static FList<string> Merge(FList<string> a, FList<string> b)
        {
            if (a.IsEmpty)
            {
                return b;
            }
            else if (b.IsEmpty)
            {
                return a;
            }
            else if (string.Compare(a.Head, b.Head) < 0)
            {
                return FList.Cons(a.Head, Merge(a.Tail, b));
            }
            else
            {
                return FList.Cons(b.Head, Merge(a, b.Tail));
            }
        }
    }

    public class FList<T>
    {
        // Creates a new list that is empty
        public FList()
        {
            IsEmpty = true;
        }
        // Creates a new list containe value and a reference to tail
        public FList(T head, FList<T> tail)
        {
            IsEmpty = false;
            Head = head;
            Tail = tail;
        }
        // Is the list empty?
        public bool IsEmpty { get; private set; }
        // Properties valid for a non-empty list
        public T Head { get; private set; }
        public FList<T> Tail { get; private set; }

        public int Count()
        {
            return IsEmpty ? 0 : 1 + Tail.Count();
        }

        public FList<T> Skip(int number)
        {
            if (number <= 0)
            {
                return this;
            }
            else if (number == 1)
            {
                return Tail;
            } else
            {
                return Tail.Skip(number - 1);
            }
        }

        public FList<T> Take(int number)
        {
            if (number <= 0)
            {
                return FList.Empty<T>();
            }
            else if (number == 1)
            {
                return FList.Cons(Head);
            }
            else
            {
                return FList.Cons(Head, Tail.Take(number - 1));
            }
        }

        public override string ToString()
        {
            if (IsEmpty)
            {
                return "";
            }
            else if (Tail.IsEmpty)
            {
                return Head.ToString();
            }
            else
            {
                return Head + ", " + Tail;
            }
        }
    }

    // Static class that provides nicer syntax for creating lists
    public static class FList
    {
        public static FList<T> Empty<T>()
        {
            return new FList<T>();
        }
        public static FList<T> Cons<T>
                (T head, FList<T> tail)
        {
            return new FList<T>(head, tail);
        }
        public static FList<T> Cons<T>
        (T head)
        {
            return new FList<T>(head, Empty<T>());
        }
    }
}

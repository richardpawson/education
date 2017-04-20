using System.Linq;

namespace FunctionalLibrary
{
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
            }
            else
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

        public override bool Equals(object obj)
        {
            if (!(obj is FList<T>))
            {
                return false;
            }
            else
            {
                var list = obj as FList<T>;
                return (this.IsEmpty && list.IsEmpty) ||
                    (Head.Equals(list.Head) && Tail.Equals(list.Tail));
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
        public static FList<T> Cons<T>(T head)
        {
            return new FList<T>(head, Empty<T>());
        }

        public static FList<T> Cons<T>(params T[] items)
        {
            if (items.Length == 0)
            {
                return Empty<T>();
            }
            else if (items.Length == 1)
            {
                return Cons<T>(items[0]);
            }
            else
            {
                return Cons(items[0], Cons(items.Skip(1).ToArray()));
            }
        }
    }
}

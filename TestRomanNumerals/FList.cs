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
        // Creates a new list containing value and a reference to tail
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
            return number <= 0 ?
                 this:
                 number == 1?
                    Tail:
                    Tail.Skip(number - 1);
        }

        public FList<T> Take(int number)
        {
            return number <= 0 ?
                FList.Empty<T>():
                number == 1 ?
                    FList.Cons(Head):
                    FList.Cons(Head, Tail.Take(number - 1));
        }

        public override string ToString()
        {
            return IsEmpty? "":
                Tail.IsEmpty?
                    Head.ToString():
                     Head + ", " + Tail;
        }

        public override bool Equals(object obj)
        {
            return !(obj is FList<T>)?
                false:
                (this.IsEmpty && (obj as FList<T>).IsEmpty) ||
                    (Head.Equals((obj as FList<T>).Head) && Tail.Equals((obj as FList<T>).Tail));
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
            return items.Length == 0 ?
                Empty<T>() :
                items.Length == 1 ?
                    Cons<T>(items[0]) :
                    Cons(items[0], Cons(items.Skip(1).ToArray()));
        }
    }
}

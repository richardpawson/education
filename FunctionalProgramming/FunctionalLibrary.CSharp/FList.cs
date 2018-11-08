using System;
using System.Linq;

namespace FunctionalLibrary
{
    public class FList<T>
    {
        // Creates a new list that is empty
        internal FList()
        {
            Empty = true;
        }
        // Creates a new list containing value and a reference to tail
        // Accessed only by FList functions.  Use FList.New in application code
        internal FList(T head, FList<T> tail)
        {
            Empty = false;
            Head = head;
            Tail = tail;
        }
        internal bool Empty { get; private set; }
        internal T Head { get; private set; }
        internal FList<T> Tail { get; private set; }

        public override string ToString()
        {
            return Empty ? "" :
                Tail.Empty ?
                    Head.ToString() :
                     Head + ", " + Tail;
        }

        public override bool Equals(object obj)
        {
            return !(obj is FList<T>) ?
                false :
                (Empty && (obj as FList<T>).Empty) ||
                    (Head.Equals((obj as FList<T>).Head) && Tail.Equals((obj as FList<T>).Tail));
        }
        public override int GetHashCode()
        {
            return Head.GetHashCode() + Tail.GetHashCode();
        }
    }
}

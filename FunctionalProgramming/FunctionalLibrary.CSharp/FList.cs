using System;
using System.Linq;

namespace FunctionalLibrary
{
    public class FList<T>
    {
        // Creates a new list that is empty
        internal FList()
        {
            IsEmpty = true;
        }
        // Creates a new list containing value and a reference to tail
        // Accessed only by FList functions.  Use FList.Cons in application code
        internal FList(T head, FList<T> tail)
        {
            IsEmpty = false;
            Head = head;
            Tail = tail;
        }
        internal bool IsEmpty { get; private set; }
        internal T Head { get; private set; }
        internal FList<T> Tail { get; private set; }

        public override string ToString()
        {
            return IsEmpty ? "" :
                Tail.IsEmpty ?
                    Head.ToString() :
                     Head + ", " + Tail;
        }

        public override bool Equals(object obj)
        {
            return !(obj is FList<T>) ?
                false :
                (this.IsEmpty && (obj as FList<T>).IsEmpty) ||
                    (Head.Equals((obj as FList<T>).Head) && Tail.Equals((obj as FList<T>).Tail));
        }
        public override int GetHashCode()
        {
            return Head.GetHashCode() + Tail.GetHashCode();
        }
    }
}

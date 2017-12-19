using System;
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

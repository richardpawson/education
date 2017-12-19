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
    }

    // Static class that provides 
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

        public static FList<T> Add<T>(this FList<T> list, T item)
        {
            return Cons(item, list);
        }

        public static FList<T> Remove<T>(this FList<T> list, T item)
        {
            return list.IsEmpty ?
                list :
                    list.Head.Equals(item) ?
                    list.Tail :
                    Cons(list.Head, list.Tail.Remove(item));
        }

        public static int Count<T>(this FList<T> list)
        {
            return list.IsEmpty ? 0 : 1 + list.Tail.Count();
        }

        public static bool Contains<T>(this FList<T> list, T item)
        {
            return list.IsEmpty ?
                false :
                list.Head.Equals(item) ?
                    true :
                    list.Tail.Contains(item);
        }


        #region  LINQ-style functions
        public static FList<T> Skip<T>(this FList<T> list, int number)
        {
            return number <= 0 ?
                 list :
                 number == 1 ?
                    list.Tail :
                    list.Tail.Skip(number - 1);
        }

        public static FList<T> Take<T>(this FList<T> list, int number)
        {
            return number <= 0 ?
                FList.Empty<T>() :
                number == 1 ?
                    FList.Cons(list.Head) :
                    FList.Cons(list.Head, list.Tail.Take(number - 1));
        }
        public static bool Any<T>(this FList<T> list, Func<T, bool> func)
        {
            return list.IsEmpty?
                false :                
                func(list.Head) || list.Tail.Any(func);
        }

        public static FList<T> Where<T>(this FList<T> list, Func<T, bool> func)
        {
            return list.Tail.IsEmpty ?
                Cons(list.Head)
            : func(list.Head) ?
                    Cons(list.Head, list.Tail.Where(func)) :
                    list.Tail.Where(func);
         }        
                    
                   // 

        public static FList<U> Select<T, U>(this FList<T> list, Func<T, U> func)
        {
            return list.Tail.IsEmpty ?
                func(list.Head) != null ?
                    Cons<U>(func(list.Head)) :
                    FList.Empty<U>() :
                 func(list.Head) != null ?
                    Cons<U>(func(list.Head), list.Tail.Select(func)) :
                    list.Tail.Select(func);
        }

        public static  T Aggregate<T>(this FList<T> list, Func<T,T,T> func)
        {
            return list.IsEmpty ?
                default(T) :
                func(list.Head, list.Tail.Aggregate(func));
        }
        #endregion
    }
}

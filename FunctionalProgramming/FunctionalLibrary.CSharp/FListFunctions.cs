using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunctionalLibrary
{
    // Static class that provides functions relating to FLists
    public static class FList
    {
        #region Constructing lists
        /// <summary>
        /// Construct an empty list of specified type
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static FList<T> Empty<T>()
        {
            return new FList<T>();
        }
        /// <summary>
        /// Construct a list from a head and tail. If head param is null return the Tail only
        /// </summary>
        public static FList<T> Cons<T>(T head, FList<T> tail)
        {
            return head == null?
                tail
                :new FList<T>(head, tail);
        }
        public static FList<T> Cons<T>(T head)
        {
            return head == null ?
                Empty<T>()
                : new FList<T>(head, Empty<T>());
        }

        public static FList<T> Cons<T>(params T[] items)
        {
            return items.Length == 0 ?
                Empty<T>()
                : items.Length == 1 ?
                    Cons<T>(items[0]) :
                    Cons(items[0], Cons(items.Skip(1).ToArray()));
        }
        #endregion

        #region Query methods (don't return a list)
        public static int Count<T>(this FList<T> list)
        {
            return list.IsEmpty ? 0 : 1 + list.Tail.Count();
        }

        public static bool Contains<T>(this FList<T> list, T item)
        {
            return list.IsEmpty ?
                false
                : list.Head.Equals(item) ?
                    true
                    : list.Tail.Contains(item);
        }
        #endregion

        #region Simple functions to 'modify' a list (actually, make a new one)
        /// <summary>
        /// Adds new item, as the head of a new List
        /// </summary>
        public static FList<T> Prepend<T>(this FList<T> list, T item)
        {
            return new FList<T>(item, list);
        }

        /// <summary>
        /// Adds new item at the end of the list
        /// </summary>
        public static FList<T> Append<T>(this FList<T> list, T item)
        {
            return list.IsEmpty ?
                Cons(item)
                : Cons(list.Head, list.Tail.Append(item));
        }

        // Remove item from list, wherever it is located,  multiple times if necessary
        public static FList<T> Remove<T>(this FList<T> list, T item)
        {
            return list.IsEmpty ?
                list
                : list.Head.Equals(item) ?
                    list.Tail.Remove(item)
                    : Cons(list.Head, list.Tail.Remove(item));
        }

        public static FList<T> Skip<T>(this FList<T> list, int number)
        {
            return number <= 0 ?
                 list
                 : number == 1 ?
                    list.Tail
                    : list.Tail.Skip(number - 1);
        }

        public static FList<T> Take<T>(this FList<T> list, int number)
        {
            return number <= 0 ?
                FList.Empty<T>()
                : number == 1 ?
                    FList.Cons(list.Head)
                    : FList.Cons(list.Head, list.Tail.Take(number - 1));
        }
        #endregion

        #region Higher-order functions: Map, Filter, Reduce, Any
        public static bool Any<T>(this FList<T> list, Func<T, bool> func)
        {
            return !list.Filter(func).IsEmpty;
        }

        public static FList<T> Filter<T>(this FList<T> list, Func<T, bool> func)
        {
            return list.IsEmpty ?
                list
                : func(list.Head) ?
                        Cons(list.Head, list.Tail.Filter(func)) :
                        list.Tail.Filter(func);
        }

        public static FList<U> Map<T, U>(this FList<T> list, Func<T, U> func)
        {
            return list.Tail.IsEmpty ?
                func(list.Head) != null ?
                    Cons<U>(func(list.Head))
                    : FList.Empty<U>()
                : func(list.Head) != null ?
                    Cons<U>(func(list.Head), list.Tail.Map(func))
                    : list.Tail.Map(func);
        }

        public static T Reduce<T>(this FList<T> list, Func<T, T, T> func)
        {
            return list.IsEmpty ?
                default(T)
                : func(list.Head, list.Tail.Reduce(func));
        }
        #endregion
    }
}

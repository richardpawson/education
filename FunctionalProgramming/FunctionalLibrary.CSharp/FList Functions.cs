using System;
using System.Linq;

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
        /// Construct a list from a head and tail. If head param is null returns the Tail only
        /// </summary>
        public static FList<T> New<T>(T head, FList<T> tail)
        {
            return head == null?
                tail
                :new FList<T>(head, tail);
        }
        /// <summary>
        /// Construct a list from a head only
        /// </summary>
        public static FList<T> New<T>(T head)
        {
            return head == null ?
                Empty<T>()
                : new FList<T>(head, Empty<T>());
        }

        /// <summary>
        /// Construct a list from a set of values as separate arguments
        /// </summary>
        public static FList<T> New<T>(params T[] items)
        {
            return items.Length == 0 ?
                Empty<T>()
                : items.Length == 1 ?
                    New<T>(items[0]) :
                    New(items[0], New(items.Skip(1).ToArray()));
        }
        #endregion

        #region Head, Tail, Init, Last 

        public static bool IsEmpty<T>(FList<T> list)
        {
            return list.Empty;
        }

        public static int Length<T>(FList<T> list)
        {
            return list.Empty ?
                    0
                    : 1 + Length(Tail(list));
        }

        public static T Head<T>(FList<T> list)
        {
            return IsEmpty(list) ? throw new EmptyListException() : list.Head;
        }

        public static FList<T> Tail<T>(FList<T> list)
        {
            return IsEmpty(list) ?
                throw new EmptyListException()
                : list.Tail;
        }

        public static T Last<T>(FList<T> list)
        {
            return Length(list) == 1 ?
                     Head(list)
                     : Last(Tail(list));
        }

        //Returns the initial part of the list, i.e. all but the tail
        public static FList<T> Init<T>(FList<T> list)
        {
            return IsEmpty(Tail(list)) ?
                Empty<T>()
                : New(Head(list), Init(Tail(list)));
        }


        #endregion

        #region Query methods (don't return a list)
        //Returne true if the list contains an element equal to the first argument
        public static bool Elem<T>( T elem,  FList<T> list)
        {
            return list.Empty ?
                false
                : list.Head.Equals(elem) ?
                    true
                    : Elem(elem, Tail(list));
        }
        #endregion

        #region Simple functions to 'modify' a list (actually, make a new one)
        /// <summary>
        /// Adds new item, as the head of a new List
        /// </summary>
        public static FList<T> Prepend<T>(T item, FList<T> list)
        {
            return new FList<T>(item, list);
        }

        /// <summary>
        /// Adds new item at the end of the list
        /// </summary>
        public static FList<T> Append<T>(FList<T> inputList, FList<T> toAppend)
        {
            return inputList.Empty ?
                toAppend
                : New(inputList.Head, Append(Tail(inputList), toAppend));
        }

        // Remove first occurrence of item (if any) from list
        public static FList<T> RemoveFirst<T>(T item, FList<T> list)
        {
            return list.Empty ?
                list
                : Head(list).Equals(item) ?
                    Tail( list)
                    : New(Head(list), FList.RemoveFirst(item, Tail(list)));
        }

        //Remove all occurrences of item from list
        public static FList<T> RemoveAll<T>(T item, FList<T> list)
        {
            return list.Empty ?
                list
                : Head(list).Equals(item) ?
                    RemoveAll(item, Tail(list))
                    : New(Head(list), FList.RemoveAll(item, Tail(list)));
        }

        public static FList<T> Drop<T>(int number, FList<T> list)
        {
            return number <= 0 || IsEmpty(list)?
                 list
                 : number == 1 ?
                    Tail(list)
                    : Drop(number - 1, Tail(list));
        }

        public static FList<T> Take<T>(int n, FList<T> list)
        {
            return n <= 0 || IsEmpty(list) ?
                FList.Empty<T>()
                : n == 1 ?
                    FList.New(Head(list))
                    : FList.New(Head(list), Take(n - 1, Tail(list)));
        }

        public static FList<T> Reverse<T>( FList<T> list)
        {
            return IsEmpty(list) ?
                list
                : FList.New(Last(list), Reverse(Init(list)));
        }
        #endregion

        #region Higher-order functions: Map, Filter, Reduce, Any
        public static bool Any<T>(Func<T, bool> f, FList<T> list)
        {
            return !IsEmpty(Filter(f, list));
        }

        public static FList<T> Filter<T>(Func<T, bool> func, FList<T> list)
        {
            return list.Empty ?
                list
                : func(list.Head) ?
                        New(Head(list), Filter(func, Tail(list))) :
                        Filter(func, Tail(list));
        }

        public static FList<U> Map<T, U>(Func<T, U> f, FList<T> list)
        {
            return IsEmpty(list) ?
                      Empty<U>()               
                        :IsEmpty(Tail(list)) ?
                        f(list.Head) != null ?
                            New<U>(f(list.Head))
                            : Empty<U>()
                        : f(list.Head) != null ?
                            New<U>(f(list.Head), Map(f, list.Tail))
                            : Map(f, list.Tail);
        }

        public static T FoldL<T>( Func<T, T, T> f, T start, FList<T> list)
        {
            return IsEmpty(list) ?
                start
                : IsEmpty(Tail(list)) ?
                    f(start, Head(list))
                    : FoldL(f, f(start, Last(list)), Init(list));
        }

        public static T FoldR<T>( Func<T, T, T> f, T start, FList<T> list)
        {
            return list.Empty ?
                start
                : list.Tail.Empty ?
                    f(list.Head, start)
                    : FoldR(f, f(list.Head, start), list.Tail);
        }

        #endregion
    }
}

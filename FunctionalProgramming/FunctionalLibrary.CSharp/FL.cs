using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunctionalLibrary
{
    // Static class that provides functions relating to FLists
    public static class FL
    {
        #region Constructing lists
        /// <summary>
        /// Construct an empty list of specified type
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static FList<T> EmptyList<T>()
        {
            return new FList<T>();
        }
        /// <summary>
        /// Construct a list from a head and tail. If head param is null return the Tail only
        /// </summary>
        public static FList<T> NewFList<T>(T head, FList<T> tail)
        {
            return head == null?
                tail
                :new FList<T>(head, tail);
        }
        /// <summary>
        /// Construct a list from a head only
        /// </summary>
        public static FList<T> NewFList<T>(T head)
        {
            return head == null ?
                EmptyList<T>()
                : new FList<T>(head, EmptyList<T>());
        }

        /// <summary>
        /// Construct a list from a set of values as separate arguments
        /// </summary>
        public static FList<T> NewFList<T>(params T[] items)
        {
            return items.Length == 0 ?
                EmptyList<T>()
                : items.Length == 1 ?
                    NewFList<T>(items[0]) :
                    NewFList(items[0], NewFList(items.Skip(1).ToArray()));
        }
        #endregion

        #region Head, Tail, Init, Last 

        public static bool IsEmpty<T>(FList<T> list)
        {
            return list.IsEmpty;
        }

        public static int Length<T>(FList<T> list)
        {
            return list.IsEmpty ?
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
                EmptyList<T>()
                : NewFList(Head(list), Init(Tail(list)));
        }


        #endregion

        #region Query methods (don't return a list)
        //Returne true if the list contains an element equal to the first argument
        public static bool Elem<T>( T elem,  FList<T> list)
        {
            return list.IsEmpty ?
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
            return inputList.IsEmpty ?
                toAppend
                : NewFList(inputList.Head, Append(Tail(inputList), toAppend));
        }

        // Remove item from list, wherever it is located,  multiple times if necessary
        public static FList<T> RemoveFirst<T>(T item, FList<T> list)
        {
            return list.IsEmpty ?
                list
                : Head(list).Equals(item) ?
                    Tail( list)
                    : NewFList(Head(list), FL.RemoveFirst(item, Tail(list)));
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
                FL.EmptyList<T>()
                : n == 1 ?
                    FL.NewFList(Head(list))
                    : FL.NewFList(Head(list), Take(n - 1, Tail(list)));
        }

        public static FList<T> Reverse<T>( FList<T> list)
        {
            return IsEmpty(list) ?
                list
                : FL.NewFList(Last(list), Reverse(Init(list)));
        }
        #endregion

        #region Higher-order functions: Map, Filter, Reduce, Any
        public static bool Any<T>(Func<T, bool> f, FList<T> list)
        {
            return !IsEmpty(Filter(f, list));
        }

        public static FList<T> Filter<T>(Func<T, bool> func, FList<T> list)
        {
            return list.IsEmpty ?
                list
                : func(list.Head) ?
                        NewFList(Head(list), Filter(func, Tail(list))) :
                        Filter(func, Tail(list));
        }

        public static FList<U> Map<T, U>(Func<T, U> f, FList<T> list)
        {
            return IsEmpty(list) ?
                      EmptyList<U>()               
                        :IsEmpty(Tail(list)) ?
                        f(list.Head) != null ?
                            NewFList<U>(f(list.Head))
                            : EmptyList<U>()
                        : f(list.Head) != null ?
                            NewFList<U>(f(list.Head), Map(f, list.Tail))
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
            return list.IsEmpty ?
                start
                : list.Tail.IsEmpty ?
                    f(list.Head, start)
                    : FoldR(f, f(list.Head, start), list.Tail);
        }

        #endregion
    }
}

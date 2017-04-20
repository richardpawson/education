using System;

namespace FunctionalLibrary
{
    public static class MergeSort
    {
        public static FList<T> Sort<T>(FList<T> list, Func<T, T, bool> greaterThan)
        {
            if (list.Count() < 2)
            {
                return list;
            }
            else
            {
                var half = list.Count() / 2;
                return Merge(Sort(list.Skip(half), greaterThan), Sort(list.Take(half), greaterThan), greaterThan);
            }
        }

        public static FList<T> Merge<T>(FList<T> a, FList<T> b, Func<T, T, bool> greaterThan)
        {
            if (a.IsEmpty)
            {
                return b;
            }
            else if (b.IsEmpty)
            {
                return a;
            }
            else if (greaterThan(a.Head, b.Head))
            {
                return FList.Cons(a.Head, Merge(a.Tail, b, greaterThan));
            }
            else
            {
                return FList.Cons(b.Head, Merge(a, b.Tail, greaterThan));
            }
        }

        public static FList<string> Sort(FList<string> list, Func<string, string, bool> greaterThan)
        {
            if (list.Count() < 2)
            {
                return list;
            }
            else
            {
                var half = list.Count() / 2;
                return Merge(Sort(list.Skip(half), greaterThan), Sort(list.Take(half), greaterThan), greaterThan);
            }
        }

        public static FList<string> Merge(FList<string> a, FList<string> b, Func<string, string, bool> greaterThan)
        {
            if (a.IsEmpty)
            {
                return b;
            }
            else if (b.IsEmpty)
            {
                return a;
            }
            else if (greaterThan(a.Head, b.Head))
            {
                return FList.Cons(a.Head, Merge(a.Tail, b, greaterThan));
            }
            else
            {
                return FList.Cons(b.Head, Merge(a, b.Tail, greaterThan));
            }
        }

        public static FList<string> SortAlphabetical(FList<string> list)
        {
            if (list.Count() < 2)
            {
                return list;
            }
            else
            {
                var half = list.Count() / 2;
                return MergeAlphabetical(SortAlphabetical(list.Skip(half)), SortAlphabetical(list.Take(half)));
            }
        }

        public static FList<string> MergeAlphabetical(FList<string> a, FList<string> b)
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
                return FList.Cons(a.Head, MergeAlphabetical(a.Tail, b));
            }
            else
            {
                return FList.Cons(b.Head, MergeAlphabetical(a, b.Tail));
            }
        }
    }
}

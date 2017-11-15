using System;

namespace FunctionalLibrary
{
    public static class MergeSort
    {
        public static FList<T> Sort<T>(FList<T> list, Func<T, T, bool> greaterThan)
        {
            return list.Count() < 2 ?
                  list :
                  Merge(Sort(list.Skip(HalfLength(list)), greaterThan), Sort(list.Take(HalfLength(list)), greaterThan), greaterThan);
        }

        public static FList<T> Merge<T>(FList<T> a, FList<T> b, Func<T, T, bool> greaterThan)
        {
            return a.IsEmpty ?
                b :
                b.IsEmpty ?
                    a :
                    greaterThan(a.Head, b.Head) ?
                        FList.Cons(a.Head, Merge(a.Tail, b, greaterThan)):
                        FList.Cons(b.Head, Merge(a, b.Tail, greaterThan));
        }

        public static FList<string> Sort(FList<string> list, Func<string, string, bool> greaterThan)
        {
            return list.Count() < 2 ?
                list:
                Merge(Sort(list.Skip(HalfLength(list)), greaterThan), Sort(list.Take(HalfLength(list)), greaterThan), greaterThan);
        }

        public static FList<string> Merge(FList<string> a, FList<string> b, Func<string, string, bool> greaterThan)
        {
            return a.IsEmpty ?
                b :
                b.IsEmpty ?
                    a :
                    greaterThan(a.Head, b.Head) ?
                        FList.Cons(a.Head, Merge(a.Tail, b, greaterThan)) :
                        FList.Cons(b.Head, Merge(a, b.Tail, greaterThan));
        }

        public static FList<string> SortAlphabetical(FList<string> list)
        {
            return list.Count() < 2 ?
                list : 
                MergeAlphabetical(SortAlphabetical(list.Skip(HalfLength(list))), SortAlphabetical(list.Take(HalfLength(list))));
        }

        public static FList<string> MergeAlphabetical(FList<string> a, FList<string> b)
        {
            return a.IsEmpty?
                b:
                b.IsEmpty ?
                    a:
                    string.Compare(a.Head, b.Head) < 0 ?
                        FList.Cons(a.Head, MergeAlphabetical(a.Tail, b)):
                        FList.Cons(b.Head, MergeAlphabetical(a, b.Tail));
        }

        //returns half the length of the list, rounded down
        private static int HalfLength<T>(FList<T> list)
        {
            return list.Count() / 2;
        }
    }
}

using System;

namespace FunctionalLibrary
{
    public static class Sorting
    {

        public static FList<T> LeftHalf<T>(FList<T> list)
        {
            return list.Skip(list.Count() / 2);
        }

        public static FList<T> RightHalf<T>(FList<T> list)
        {
            return list.Take(list.Count() / 2);
        }

        public static FList<T> MergeSort<T>(FList<T> list, Func<T, T, bool> p)
        {
            return list.Count() < 2 ?
                    list :
                    Merge(MergeSort(LeftHalf(list), p), MergeSort(RightHalf(list), p), p);
        }

        public static FList<T> Merge<T>(FList<T> a, FList<T> b, Func<T, T, bool> p)
        {
            return a.IsEmpty ?
                b :
                b.IsEmpty ?
                    a :
                    p(a.Head, b.Head) ?
                        new FList<T>(a.Head, Merge(a.Tail, b, p)) :
                        new FList<T>(b.Head, Merge(a, b.Tail, p));
        }

    }
}

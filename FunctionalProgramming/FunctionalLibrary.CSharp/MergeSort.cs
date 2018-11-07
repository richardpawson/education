using System;

namespace FunctionalLibrary
{
    public static class Sorting
    {

        public static FList<T> LeftHalf<T>(FList<T> list)
        {
            return FC.Drop(FC.Length(list) / 2, list);
        }

        public static FList<T> RightHalf<T>(FList<T> list)
        {
            return FC.Take(FC.Length(list) / 2, list);
        }

        public static FList<T> MergeSort<T>( Func<T, T, bool> f, FList<T> list)
        {
            return FC.Length(list) < 2 ?
                    list :
                    Merge(MergeSort(f, LeftHalf(list)), MergeSort(f, RightHalf(list)), f);
        }

        public static FList<T> Merge<T>(FList<T> a, FList<T> b, Func<T, T, bool> f)
        {
            return a.IsEmpty ?
                b :
                b.IsEmpty ?
                    a :
                    f(a.Head, b.Head) ?
                        new FList<T>(a.Head, Merge(a.Tail, b, f)) :
                        new FList<T>(b.Head, Merge(a, b.Tail, f));
        }

    }
}

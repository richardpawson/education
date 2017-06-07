using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolymorphicSorting
{
    public static class SortFunctions
    {
        public static List<object> QuickSort(List<object> unsorted)
        {
            Random r = new Random();
            var less = new List<object>();
            var greater = new List<object>();
            if (unsorted.Count <= 1) return unsorted;
            var pos = r.Next(unsorted.Count);
            var pivot = unsorted[pos];
            unsorted.RemoveAt(pos);
            foreach (var item in unsorted)
            {
                if (item.IsBefore(pivot))
                {
                    less.Add(item);
                }
                else
                {
                    greater.Add(item);
                }
            }
            var sorted = new List<object>(less);
            sorted.Add(pivot);
            sorted.AddRange(greater);
            return sorted;
        }

        //pseudo-code dynamic language

        //def quickSort(unsorted)
        //    r = new Random
        //    less = new List
        //    greater = new List
        //    if a.Count <= 1 return unsorted
        //    pos = r.Next(unsorted.Count);
        //    pivot = a[pos];
        //    a.RemoveAt(pos);
        //    foreach (item in unsorted)
        //        if item.IsBefore(pivot) then
        //            less.Add(item)
        //        else
        //            greater.Add(item)
        //    }
        //    sorted = less.makeCopy
        //    sorted.Add(pivot)
        //    sorted.AddAll(greater)
        //    return sorted
    }
}

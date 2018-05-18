using System;
using System.Collections.Generic;
using System.Linq;

namespace SortingTestbed
{
    public static class SortAlgorithms
    {
        //In-place sort
        //You can use the pseudo-code in Heathcote p238
        public static void BubbleSort(int[] items)
        {
            throw new NotImplementedException();
        }

        //In-place sort of array
        //Implementation of the pseudo-code in Heathcote p240
        public static void InPlaceMergeSort(int[] list)
        {
            InPlaceMergeSort(list, 0, list.Length - 1);
        }

        private static void InPlaceMergeSort(int[] list, int first, int last)
        {
            if (first < last)
            {
                var mid = (first + last) / 2;
                InPlaceMergeSort(list, first, mid);
                InPlaceMergeSort(list, mid + 1, last);
                MergeTwoOrderedSubLists(list, first, mid+1, last);
            }
        }

        internal static void MergeTwoOrderedSubLists(int[] list, int startOfFirst, int startOfSecond, int last)
        {
            if (startOfFirst < startOfSecond && startOfSecond < last)
            {
                if (list[startOfFirst] > list[startOfSecond])
                {
                    //Swap first and mid+1
                    var temp = list[startOfFirst];
                    list[startOfFirst] = list[startOfSecond];
                    list[startOfSecond] = temp;
                    MergeTwoOrderedSubLists(list, startOfFirst, startOfSecond+1, last);
                }
                else
                {
                    MergeTwoOrderedSubLists(list, startOfFirst+1, startOfSecond, last);
                }
            }
        }

        //Not-in-place (or 'out-of-place') sort 
        //(considered better practice  - and paves the way for 'functional programming')
        public static List<int> OutOfPlaceMergeSort(List<int> mergeList)
        {
            throw new NotImplementedException();
        }
    }
}

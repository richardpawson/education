using System;
using System.Collections.Generic;
using System.Linq;

namespace SortingTestbed
{
    public static class SortAlgorithms
    {
        //This is an 'in-place' sort -  it modifies the input list, so nothing returned.
        public static void BubbleSort(int[] list)
        {
            throw new NotImplementedException();
        }


        //Using a recursive approach. This is an 'out of place' sort
        //Make use of the MergeOrderedLists function (to be implemented) below
        public static List<int> MergeSort(List<int> mergeList)
        {
            throw new NotImplementedException();
        }

        //Creates a single list (ordered low-to-high) from two input lists, each ordered low-to-high.
        //Note that the input lists may be of differing lengths, and either, or both, may be empty.
        //
        //You will need to implement this function and call it within MergeSort.
        //It has been made public here so that it can be tested separately.  It might also have other uses.
        public static List<int> MergeOrderedLists(List<int> left, List<int> right)
        {
            throw new NotImplementedException();
        }

    }
}

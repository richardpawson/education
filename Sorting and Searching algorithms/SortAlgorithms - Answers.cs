using System;
using System.Collections.Generic;
using System.Linq;

namespace SortingTestbed
{
    public static class SortAlgorithms
    {
        //Implementation of the pseudo-code in Heathcote p238
        public static void BubbleSort(int[] items)
        {
            int n = items.Length;

            for (int i = 0; i < n-1; i++)
            {
                for (int j = 0; j < n-1-i; j++)
                {
                    if (items[j] > items[j + 1]) //then swap them
                    {
                        var temp = items[j + 1];
                        items[j + 1] = items[j];
                        items[j] = temp;
                    }
                }
            }
        }

        #region Recursive implementation of Merge Sort
        public static List<int> MergeSort(List<int> mergeList)
        {
            if (mergeList.Count < 2)
            {
                return mergeList;
            }
            else
            {
                List<int> leftHalf = LeftHalfOf(mergeList);
                List<int> rightHalf = RightHalfOf(mergeList);
                List<int> leftSorted = MergeSort(leftHalf);
                List<int> rightSorted = MergeSort(rightHalf);
                return MergeOrderedLists(leftSorted, rightSorted);
            }
        }

        #endregion

        public static List<int> MergeOrderedLists(List<int> leftList, List<int> rightList)
        {
            int leftPos = 0;
            int rightPos = 0;
            var result = new List<int>();
            while (leftPos < leftList.Count && rightPos < rightList.Count)
            {
                if (leftList[leftPos] < rightList[rightPos])
                {
                    result.Add(leftList[leftPos]);
                    leftPos++;
                }
                else
                {
                    result.Add(rightList[rightPos]);
                    rightPos++;
                }
            }

            //Add any remaining items from left or right list (there won't be both)
            //they will they all be greater than existing values in results, and already in order
            while (leftPos < leftList.Count)
            {
                result.Add(leftList[leftPos]);
                leftPos += 1;
            }
            while (rightPos < rightList.Count)
            {
                result.Add(rightList[rightPos]);
                rightPos += 1;
            }
            //A more efficient way to do this using AddRange and Skip
            //result.AddRange(left.Skip(leftPos));
            //result.AddRange(right.Skip(rightPos));
            return result;
        }

        private static List<int> RightHalfOf(List<int> mergeList)
        {
            return mergeList.Skip(mergeList.Count / 2).ToList();
        }

        private static List<int> LeftHalfOf(List<int> mergeList)
        {
            return mergeList.Take(mergeList.Count / 2).ToList();
        }
    }
}

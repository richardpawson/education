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

        //Implementation of the pseudo-code in Heathcote p240
        public static void InPlaceMergeSort(int[] mergeList)
        {
          if (mergeList.Length > 1)
            {
                int mid = mergeList.Length / 2; //Rounds down
                var leftHalf = mergeList.Take(mid).ToArray();
                var rightHalf = mergeList.Skip(mid).ToArray();
                InPlaceMergeSort(leftHalf);
                InPlaceMergeSort(rightHalf);
                int i = 0;
                int j = 0;
                int k = 0;
                while (i < leftHalf.Length && j < rightHalf.Length)
                {
                    if (leftHalf[i] < rightHalf[j])
                    {
                        mergeList[k] = leftHalf[i];
                        i++;
                    } else
                    {
                        mergeList[k] = rightHalf[j];
                        j++;
                    }
                    k++;
                }
                //Check if left half has elements not merged
                while (i < leftHalf.Length)
                {
                    mergeList[k] = leftHalf[i];
                    i += 1;
                    k += 1;
                }
                //Check if right half has elements not merged
                while (j < rightHalf.Length)
                {
                    mergeList[k] = rightHalf[j];
                    j += 1;
                    k += 1;
                }
            }
        }

        #region Elegant Merge Sort
        public static List<int> OutOfPlaceMergeSort(List<int> mergeList)
        {
            if (mergeList.Count < 2)
            {
                return mergeList;
            }
            else
            {
                List<int> leftHalf = LeftHalfOf(mergeList);
                List<int> rightHalf = RightHalfOf(mergeList);
                List<int> leftSorted = OutOfPlaceMergeSort(leftHalf);
                List<int> rightSorted = OutOfPlaceMergeSort(rightHalf);
                return MergeOrderedLists(leftSorted, rightSorted);
            }
        }

        private static List<int> MergeOrderedLists(List<int> leftHalf, List<int> rightHalf)
        {
            if (leftHalf.Count == 0)
            {
                return rightHalf;
            }
            else if (rightHalf.Count == 0)
            {
                return leftHalf;
            }
            else
            {
                var list = new List<int>();
                var left = leftHalf.First(); //Or leftHalf[0]
                var right = rightHalf.First(); //Or rightHalf[0]
                if (left < right)
                {
                    list.Add(left);
                    list.AddRange(MergeOrderedLists(leftHalf.Skip(1).ToList(), rightHalf));
                }
                else
                {
                    list.Add(right);
                    list.AddRange(MergeOrderedLists(leftHalf, rightHalf.Skip(1).ToList()));
                }
                return list;
            }
        }

        private static List<int> RightHalfOf(List<int> mergeList)
        {
            return mergeList.Skip(mergeList.Count / 2).ToList();
        }

        private static List<int> LeftHalfOf(List<int> mergeList)
        {
            return mergeList.Take(mergeList.Count / 2).ToList();
        }
        #endregion
    }
}

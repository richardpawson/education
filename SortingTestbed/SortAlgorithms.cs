using System;
using System.Collections.Generic;
using System.Linq;

namespace SortingTestbed
{
    public static class SortAlgorithms
    {

        public static void BubbleSort(int[] values)
        {
            int n = values.Length;
            //A total of n passes (where n is length of array)
            //each passing getting one shorter
            for (int i = n; i > 0; i--)
            {
                //Within a pass, compare pairs from the start of the array to the end of the unsorted section
                for (int j = 0; j < i-1; j++)
                {
                    if (values[j] > values[j + 1]) //then swap them
                    {
                        var temp = values[j + 1];
                        values[j + 1] = values[j];
                        values[j] = temp;
                    }
                }
            }
        }

        public static void MergeSort(int[] mergeList)
        {
          if (mergeList.Length > 1)
            {
                int mid = mergeList.Length / 2; //Rounds down
                var leftHalf = mergeList.Take(mid).ToArray();
                var rightHalf = mergeList.Skip(mid).ToArray();
                MergeSort(leftHalf);
                MergeSort(rightHalf);
                int i = 0;
                int j = 0;
                int k = 0;
                while (i < leftHalf.Length && j < rightHalf.Length)
                {
                    if (leftHalf[i] < rightHalf[j])
                    {
                        mergeList[k] = leftHalf[i];
                        i += 1;
                    } else
                    {
                        mergeList[k] = rightHalf[j];
                        j += 1;
                    }
                    k += 1;
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
    }
}

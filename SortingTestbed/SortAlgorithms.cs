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
    }
}

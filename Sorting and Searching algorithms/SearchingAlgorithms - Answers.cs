using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingTestbed
{
    public static class SearchingAlgorithms
    {
        //If the array contains the item sought, function should return 
        //the index of that item in the array. Otherwise it should return '-1'.
        public static int LinearSearch(int[] items, int itemSought)
        { 
            int index = -1; //return value for 'not found'
            int i = 0;
            bool found = false;
            while (i < items.Length && !found)
            {
                if (items[i] == itemSought)
                {
                    index = i;
                    found = true;
                }
                i++;
            }
            return index;
        }

        //As above
        public static int BinarySearch(int[] items, int itemSought)
        {
            int index = -1; //return value for 'not found'
            bool found = false;
            int first = 0;
            int last = items.Length - 1;
            while  (first <= last && !found)
            {
                int midpoint = (first + last) / 2;  //rounds down
                if (items[midpoint] == itemSought)
                {
                    found = true;
                    index = midpoint;
                } else
                {
                    if (items[midpoint] < itemSought)
                    {
                        first = midpoint + 1;
                    } else
                    {
                        last = midpoint - 1;
                    }
                }
            }
            return index;
        }

    }
}

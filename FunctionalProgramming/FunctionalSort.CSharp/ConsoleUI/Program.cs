﻿using System;
using FunctionalLibrary;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = FList.Cons("Flag","Nest","Cup","Burg", "Yacht","Next");


            var alpha = Sorting.MergeSort(list, alphabetical);
            Console.WriteLine(alpha.ToString());
            var rev = Sorting.MergeSort(list, reverse);
            Console.WriteLine(rev.ToString());
            var len = Sorting.MergeSort(list, length);
            Console.WriteLine(len.ToString());

            var iList = FList.Cons(4, 7, 12, 3, 88, 9, 2, 7);
            var up = Sorting.MergeSort(iList, greaterThan);
            Console.WriteLine(up.ToString());
            var down = Sorting.MergeSort(iList, reverse);
            Console.WriteLine(down.ToString());

            Console.ReadKey();
        }

        static bool alphabetical(string s1, string s2)
        {
            return string.Compare(s2, s1) > 0;
        }

        static bool reverse(string s1, string s2)
        {
            return string.Compare(s2, s1) < 0;
        }

        static bool length(string s1, string s2)
        {
            return s2.Length > s1.Length;
        }

        static bool greaterThan(int i1, int i2)
        {
            return i2 > i1;
        }

        static bool reverse(int i1, int i2)
        {
            return i1 > i2;
        }
    }    
}

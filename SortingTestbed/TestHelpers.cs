using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text;

namespace SortingTestbed
{
    public static class TestHelpers
    {
        

        public static void AssertArraysAreIdentical(int[] expected, int[] actual)
        {
            var expectedSB = new StringBuilder();
            var actualSB = new StringBuilder();
            Assert.AreEqual(expected.Length, actual.Length,"Arrays not equal size");
            for (int i = 0; i < expected.Length; i++)
            {
                expectedSB.Append(expected[i]).Append(",");
                actualSB.Append(actual[i]).Append(",");
            }
            Assert.AreEqual(expectedSB.ToString(), actualSB.ToString());
        }

        public static int[] GenerateRandomisedArray(int length)
        {
            var data = GenerateOrderedArray(length);
            var rand = new Random();
            for (int i = 0; i < data.Length; i++)
            {
                int element1 = rand.Next(0, data.Length);
                int element2 = rand.Next(0, data.Length);
                //swap element
                var temp = data[element1];
                data[element1] = data[element2];
                data[element2] = temp;
            }
            return data;
        }

        public static int[] GenerateOrderedArray(int length)
        {
            var data = new int[length];
            for (int i = 0; i < length; i++)
            {
                data[i] = i;
            }
            return data;
        }
    }
}

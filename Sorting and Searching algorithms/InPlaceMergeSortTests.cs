using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SortingTestbed
{
    [TestClass]
    public class InPlaceMergeSortTests
    {
        [TestMethod]
        public void InPlaceMerge10()
        {
            var data = TestHelpers.GenerateRandomisedArray(10);
            SortAlgorithms.InPlaceMergeSort(data);
            var expected = TestHelpers.GenerateOrderedArray(10);
            TestHelpers.AssertArraysAreIdentical(expected, data);
        }
        [TestMethod]
        public void InPlaceMerge11()
        {
            var data = TestHelpers.GenerateRandomisedArray(11);
            SortAlgorithms.InPlaceMergeSort(data);
            var expected = TestHelpers.GenerateOrderedArray(11);
            TestHelpers.AssertArraysAreIdentical(expected, data);
        }

        [TestMethod]
        public void InPlaceMerge6()
        {
            var data = new int[] { 0, 1, 2, 3, 5, 4 };
            SortAlgorithms.InPlaceMergeSort(data);
            var expected = new int[] { 0, 1, 2, 3,4,5 };
            TestHelpers.AssertArraysAreIdentical(expected, data);
        }
        [TestMethod]
        public void InPlaceMerge4()
        {
            var data = new int[] { 2, 0, 3, 1 };
            SortAlgorithms.InPlaceMergeSort(data);
            var expected = new int[] { 0, 1, 2, 3 };
            TestHelpers.AssertArraysAreIdentical(expected, data);
        }
        [TestMethod]
        public void InPlaceMerge3()
        {
            var data = TestHelpers.GenerateRandomisedArray(3);
            SortAlgorithms.InPlaceMergeSort(data);
            var expected = TestHelpers.GenerateOrderedArray(3);
            TestHelpers.AssertArraysAreIdentical(expected, data);
        }

        [TestMethod]
        public void InPlaceMerge2()
        {
            var data = TestHelpers.GenerateRandomisedArray(2);
            SortAlgorithms.InPlaceMergeSort(data);
            var expected = TestHelpers.GenerateOrderedArray(2);
            TestHelpers.AssertArraysAreIdentical(expected, data);
        }
        [TestMethod]
        public void InPlaceMerge1()
        {
            var data = TestHelpers.GenerateRandomisedArray(1);
            SortAlgorithms.InPlaceMergeSort(data);
            var expected = TestHelpers.GenerateOrderedArray(1);
            TestHelpers.AssertArraysAreIdentical(expected, data);
        }
        [TestMethod]
        public void InPlaceMerge0()
        {
            var data = TestHelpers.GenerateRandomisedArray(0);
            SortAlgorithms.InPlaceMergeSort(data);
            var expected = TestHelpers.GenerateOrderedArray(0);
            TestHelpers.AssertArraysAreIdentical(expected, data);
        }     
    }
}

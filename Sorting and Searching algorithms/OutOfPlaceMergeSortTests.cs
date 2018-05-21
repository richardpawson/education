using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Collections.Generic;

namespace SortingTestbed
{
    [TestClass]
    public class OutOfPlaceMergeSortTests
    {
        [TestMethod]
        public void OutOfPlaceMerge10()
        {
            var input = TestHelpers.GenerateRandomisedArray(10).ToList();
            var actual = SortAlgorithms.OutOfPlaceMergeSort(input);
            var expected = TestHelpers.GenerateOrderedArray(10).ToList();
            TestHelpers.AssertListsAreIdentical(expected, actual);
        }
        [TestMethod]
        public void OutOfPlaceMerge11()
        {
            var input = TestHelpers.GenerateRandomisedArray(11).ToList();
            var actual = SortAlgorithms.OutOfPlaceMergeSort(input);
            var expected = TestHelpers.GenerateOrderedArray(11).ToList();
            TestHelpers.AssertListsAreIdentical(expected, actual);
        }
        [TestMethod]
        public void OutOfPlaceMerge5()
        {
            var input = TestHelpers.GenerateRandomisedArray(5).ToList();
            var actual = SortAlgorithms.OutOfPlaceMergeSort(input);
            var expected = TestHelpers.GenerateOrderedArray(5).ToList();
            TestHelpers.AssertListsAreIdentical(expected, actual);
        }
        [TestMethod]
        public void OutOfPlaceMerge4()
        {
            var input = new List<int> { 2, 0, 3, 1 };
            var actual = SortAlgorithms.OutOfPlaceMergeSort(input);
            var expected = new List<int> { 0, 1, 2, 3 };
            TestHelpers.AssertListsAreIdentical(expected, actual);
        }
        [TestMethod]
        public void OutOfPlaceMerge3()
        {
            var input = TestHelpers.GenerateRandomisedArray(3).ToList();
            var actual = SortAlgorithms.OutOfPlaceMergeSort(input);
            var expected = TestHelpers.GenerateOrderedArray(3).ToList();
            TestHelpers.AssertListsAreIdentical(expected, actual);
        }
        [TestMethod]
        public void OutOfPlaceMerge2()
        {
            var input = TestHelpers.GenerateRandomisedArray(2).ToList();
            var actual = SortAlgorithms.OutOfPlaceMergeSort(input);
            var expected = TestHelpers.GenerateOrderedArray(2).ToList();
            TestHelpers.AssertListsAreIdentical(expected, actual);
        }
        [TestMethod]
        public void OutOfPlaceMerge1()
        {
            var input = TestHelpers.GenerateRandomisedArray(1).ToList();
            var actual = SortAlgorithms.OutOfPlaceMergeSort(input);
            var expected = TestHelpers.GenerateOrderedArray(1).ToList();
            TestHelpers.AssertListsAreIdentical(expected, actual);
        }
        [TestMethod]
        public void OutOfPlaceMerge0()
        {
            var input = TestHelpers.GenerateRandomisedArray(0).ToList();
            var actual = SortAlgorithms.OutOfPlaceMergeSort(input);
            var expected = TestHelpers.GenerateOrderedArray(0).ToList();
            TestHelpers.AssertListsAreIdentical(expected, actual);
        }       
    }
}

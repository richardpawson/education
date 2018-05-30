using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SortingTestbed
{
    [TestClass]
    public class HeathcoteMergeSortTests
    {
        [TestMethod]
        public void InPlaceMerge10()
        {
            var data = TestHelpers.GenerateRandomisedArray(10).ToList();
            SortAlgorithms.HeathcoteMergeSort(data);
            var expected = TestHelpers.GenerateOrderedArray(10).ToList();
            TestHelpers.AssertListsAreIdentical(expected, data);
        }
        [TestMethod]
        public void InPlaceMerge11()
        {
            var data = TestHelpers.GenerateRandomisedArray(11).ToList();
            SortAlgorithms.HeathcoteMergeSort(data);
            var expected = TestHelpers.GenerateOrderedArray(11).ToList();
            TestHelpers.AssertListsAreIdentical(expected, data);
        }

        [TestMethod]
        public void InPlaceMerge6()
        {
            var data = new List<int> { 0, 1, 2, 3, 5, 4 };
            SortAlgorithms.HeathcoteMergeSort(data);
            var expected = new List<int> { 0, 1, 2, 3,4,5 };
            TestHelpers.AssertListsAreIdentical(expected, data);
        }
        [TestMethod]
        public void InPlaceMerge4()
        {
            var data = new List<int> { 2, 0, 3, 1 };
            SortAlgorithms.HeathcoteMergeSort(data);
            var expected = new List<int> { 0, 1, 2, 3 };
            TestHelpers.AssertListsAreIdentical(expected, data);
        }
        [TestMethod]
        public void InPlaceMerge3()
        {
            var data = TestHelpers.GenerateRandomisedArray(3).ToList();
            SortAlgorithms.HeathcoteMergeSort(data);
            var expected = TestHelpers.GenerateOrderedArray(3).ToList();
            TestHelpers.AssertListsAreIdentical(expected, data);
        }

        [TestMethod]
        public void InPlaceMerge2()
        {
            var data = TestHelpers.GenerateRandomisedArray(2).ToList();
            SortAlgorithms.HeathcoteMergeSort(data);
            var expected = TestHelpers.GenerateOrderedArray(2).ToList();
            TestHelpers.AssertListsAreIdentical(expected, data);
        }
        [TestMethod]
        public void InPlaceMerge1()
        {
            var data = new List<int> { 7 };
            SortAlgorithms.HeathcoteMergeSort(data);
            var expected = new List<int> { 7 };
            TestHelpers.AssertListsAreIdentical(expected, data);
        }
        [TestMethod]
        public void InPlaceMerge0()
        {
            var data = new List<int> { };         
            SortAlgorithms.HeathcoteMergeSort(data);
            var expected = new List<int> { };
            TestHelpers.AssertListsAreIdentical(expected, data);
        }     
    }
}

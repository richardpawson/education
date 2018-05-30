using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Collections.Generic;

namespace SortingTestbed
{
    [TestClass]
    public class MergeSortTests
    {
        [TestMethod]
        public void Merge10()
        {
            var input = TestHelpers.GenerateRandomisedArray(10).ToList();
            var actual = SortAlgorithms.MergeSort(input);
            var expected = TestHelpers.GenerateOrderedArray(10).ToList();
            TestHelpers.AssertListsAreIdentical(expected, actual);
        }
        [TestMethod]
        public void Merge11()
        {
            var input = TestHelpers.GenerateRandomisedArray(11).ToList();
            var actual = SortAlgorithms.MergeSort(input);
            var expected = TestHelpers.GenerateOrderedArray(11).ToList();
            TestHelpers.AssertListsAreIdentical(expected, actual);
        }
        [TestMethod]
        public void Merge5()
        {
            var input = TestHelpers.GenerateRandomisedArray(5).ToList();
            var actual = SortAlgorithms.MergeSort(input);
            var expected = TestHelpers.GenerateOrderedArray(5).ToList();
            TestHelpers.AssertListsAreIdentical(expected, actual);
        }
        [TestMethod]
        public void Merge4()
        {
            var input = new List<int> { 2, 0, 3, 1 };
            var actual = SortAlgorithms.MergeSort(input);
            var expected = new List<int> { 0, 1, 2, 3 };
            TestHelpers.AssertListsAreIdentical(expected, actual);
        }
        [TestMethod]
        public void Merge3()
        {
            var input = TestHelpers.GenerateRandomisedArray(3).ToList();
            var actual = SortAlgorithms.MergeSort(input);
            var expected = TestHelpers.GenerateOrderedArray(3).ToList();
            TestHelpers.AssertListsAreIdentical(expected, actual);
        }
        [TestMethod]
        public void Merge2()
        {
            var input = TestHelpers.GenerateRandomisedArray(2).ToList();
            var actual = SortAlgorithms.MergeSort(input);
            var expected = TestHelpers.GenerateOrderedArray(2).ToList();
            TestHelpers.AssertListsAreIdentical(expected, actual);
        }
        [TestMethod]
        public void Merge1()
        {
            var input = TestHelpers.GenerateRandomisedArray(1).ToList();
            var actual = SortAlgorithms.MergeSort(input);
            var expected = TestHelpers.GenerateOrderedArray(1).ToList();
            TestHelpers.AssertListsAreIdentical(expected, actual);
        }
        [TestMethod]
        public void Merge0()
        {
            var input = TestHelpers.GenerateRandomisedArray(0).ToList();
            var actual = SortAlgorithms.MergeSort(input);
            var expected = TestHelpers.GenerateOrderedArray(0).ToList();
            TestHelpers.AssertListsAreIdentical(expected, actual);
        }

        //[TestMethod]
        //public void TestLeftHalf()
        //{
        //    var input = new List<int> {1,2,3 };
        //    var result = SortAlgorithms.LeftHalfOf(input);
        //    var expected = new List<int> { 1 };
        //    CollectionAssert.AreEqual(expected, result);
        //}

        //[TestMethod]
        //public void TestRightHalf()
        //{
        //    var input = new List<int> { 1, 2, 3 };
        //    var result = SortAlgorithms.RightHalfOf(input);
        //    var expected = new List<int> { 2,3 };
        //    CollectionAssert.AreEqual(expected, result);
        //}
    }
}

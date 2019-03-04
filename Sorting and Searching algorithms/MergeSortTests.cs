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
        public void MergeSort10()
        {
            var input = TestHelpers.GenerateRandomisedArray(10).ToList();
            var actual = SortAlgorithms.MergeSort(input);
            var expected = TestHelpers.GenerateOrderedArray(10).ToList();
            TestHelpers.AssertListsAreIdentical(expected, actual);
        }
        [TestMethod]
        public void MergeSort11()
        {
            var input = TestHelpers.GenerateRandomisedArray(11).ToList();
            var actual = SortAlgorithms.MergeSort(input);
            var expected = TestHelpers.GenerateOrderedArray(11).ToList();
            TestHelpers.AssertListsAreIdentical(expected, actual);
        }
        [TestMethod]
        public void MergeSort5()
        {
            var input = TestHelpers.GenerateRandomisedArray(5).ToList();
            var actual = SortAlgorithms.MergeSort(input);
            var expected = TestHelpers.GenerateOrderedArray(5).ToList();
            TestHelpers.AssertListsAreIdentical(expected, actual);
        }
        [TestMethod]
        public void MergeSort4()
        {
            var input = new List<int> { 2, 0, 3, 1 };
            var actual = SortAlgorithms.MergeSort(input);
            var expected = new List<int> { 0, 1, 2, 3 };
            TestHelpers.AssertListsAreIdentical(expected, actual);
        }
        [TestMethod]
        public void MergeSort3()
        {
            var input = TestHelpers.GenerateRandomisedArray(3).ToList();
            var actual = SortAlgorithms.MergeSort(input);
            var expected = TestHelpers.GenerateOrderedArray(3).ToList();
            TestHelpers.AssertListsAreIdentical(expected, actual);
        }
        [TestMethod]
        public void MergeSort2()
        {
            var input = TestHelpers.GenerateRandomisedArray(2).ToList();
            var actual = SortAlgorithms.MergeSort(input);
            var expected = TestHelpers.GenerateOrderedArray(2).ToList();
            TestHelpers.AssertListsAreIdentical(expected, actual);
        }
        [TestMethod]
        public void MergeSort1()
        {
            var input = TestHelpers.GenerateRandomisedArray(1).ToList();
            var actual = SortAlgorithms.MergeSort(input);
            var expected = TestHelpers.GenerateOrderedArray(1).ToList();
            TestHelpers.AssertListsAreIdentical(expected, actual);
        }
        [TestMethod]
        public void MergeSort0()
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


        [TestMethod] 
        public void Merge1()
        {
            var left = new List<int> { 4, 11, 17 };
            var right = new List<int> { 0, 3, 5, 7, 11, 13, 18, 20 };
            var expected = new List<int> { 0, 3, 4, 5, 7, 11, 11, 13, 17, 18, 20 };
            var result = SortAlgorithms.MergeOrderedLists(left, right);
            TestHelpers.AssertArraysAreIdentical(expected.ToArray(), result.ToArray());
        }

        [TestMethod]
        public void Merge2()
        {
            var right = new List<int> { 4, 11, 17 };
            var left = new List<int> { 0, 3, 5, 7, 11, 13, 18, 20 };
            var expected = new List<int> { 0, 3, 4, 5, 7, 11, 11, 13, 17, 18, 20 };
            var result = SortAlgorithms.MergeOrderedLists(left, right);
            TestHelpers.AssertArraysAreIdentical(expected.ToArray(), result.ToArray());
        }

        [TestMethod]
        public void Merge3()
        {
            var right = new List<int> { 6 };
            var left = new List<int> { 0, 3, 5, 7, 11, 13, 18, 20 };
            var expected = new List<int> { 0, 3, 5, 6,7, 11, 13, 18, 20 };
            var result = SortAlgorithms.MergeOrderedLists(left, right);
            TestHelpers.AssertArraysAreIdentical(expected.ToArray(), result.ToArray());
        }

        [TestMethod]
        public void Merge4()
        {
            var right = new List<int> {};
            var left = new List<int> { 0, 3, 5, 7, 11, 13, 18, 20 };
            var expected = new List<int> { 0, 3, 5, 7, 11, 13, 18, 20 };
            var result = SortAlgorithms.MergeOrderedLists(left, right);
            TestHelpers.AssertArraysAreIdentical(expected.ToArray(), result.ToArray());
        }

        [TestMethod]
        public void Merge5()
        {
            var left = new List<int> { };
            var right = new List<int> { 0, 3, 5, 7, 11, 13, 18, 20 };
            var expected = new List<int> { 0, 3, 5, 7, 11, 13, 18, 20 };
            var result = SortAlgorithms.MergeOrderedLists(left, right);
            TestHelpers.AssertArraysAreIdentical(expected.ToArray(), result.ToArray());
        }

        [TestMethod]
        public void Merge6()
        {
            var left = new List<int> { };
            var right = new List<int> {};
            var expected = new List<int> { };
            var result = SortAlgorithms.MergeOrderedLists(left, right);
            TestHelpers.AssertArraysAreIdentical(expected.ToArray(), result.ToArray());
        }
    }
}

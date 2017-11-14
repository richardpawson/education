using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SortingTestbed
{
    [TestClass]
    public class MergeSortTests
    {
        [TestMethod]
        public void Merge10()
        {
            var data = TestHelpers.GenerateRandomisedArray(10);
            SortAlgorithms.MergeSort(data);
            var reference = TestHelpers.GenerateOrderedArray(10);
            TestHelpers.AssertArraysAreIdentical(reference, data);
        }
        [TestMethod]
        public void Merge11()
        {
            var data = TestHelpers.GenerateRandomisedArray(11);
            SortAlgorithms.MergeSort(data);
            var reference = TestHelpers.GenerateOrderedArray(11);
            TestHelpers.AssertArraysAreIdentical(reference, data);
        }
        [TestMethod]
        public void Merge3()
        {
            var data = TestHelpers.GenerateRandomisedArray(3);
            SortAlgorithms.MergeSort(data);
            var reference = TestHelpers.GenerateOrderedArray(3);
            TestHelpers.AssertArraysAreIdentical(reference, data);
        }
        [TestMethod]
        public void Merge2()
        {
            var data = TestHelpers.GenerateRandomisedArray(2);
            SortAlgorithms.MergeSort(data);
            var reference = TestHelpers.GenerateOrderedArray(2);
            TestHelpers.AssertArraysAreIdentical(reference, data);
        }
        [TestMethod]
        public void Merge1()
        {
            var data = TestHelpers.GenerateRandomisedArray(1);
            SortAlgorithms.MergeSort(data);
            var reference = TestHelpers.GenerateOrderedArray(1);
            TestHelpers.AssertArraysAreIdentical(reference, data);
        }
        [TestMethod]
        public void Merge0()
        {
            var data = TestHelpers.GenerateRandomisedArray(0);
            SortAlgorithms.MergeSort(data);
            var reference = TestHelpers.GenerateOrderedArray(0);
            TestHelpers.AssertArraysAreIdentical(reference, data);
        }       
    }
}

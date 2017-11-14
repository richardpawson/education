using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SortingTestbed
{
    [TestClass]
    public class BubbleSortTests
    {
        [TestMethod]
        public void Bubble10()
        {
            var data = TestHelpers.GenerateRandomisedArray(10);
            SortAlgorithms.BubbleSort(data);
            var reference = TestHelpers.GenerateOrderedArray(10);
            TestHelpers.AssertArraysAreIdentical(reference, data);
        }
        [TestMethod]
        public void Bubble11()
        {
            var data = TestHelpers.GenerateRandomisedArray(11);
            SortAlgorithms.BubbleSort(data);
            var reference = TestHelpers.GenerateOrderedArray(11);
            TestHelpers.AssertArraysAreIdentical(reference, data);
        }
        [TestMethod]
        public void Bubble1()
        {
            var data = TestHelpers.GenerateRandomisedArray(1);
            SortAlgorithms.BubbleSort(data);
            var reference = TestHelpers.GenerateOrderedArray(1);
            TestHelpers.AssertArraysAreIdentical(reference, data);
        }
        [TestMethod]
        public void Bubble0()
        {
            var data = TestHelpers.GenerateRandomisedArray(0);
            SortAlgorithms.BubbleSort(data);
            var reference = TestHelpers.GenerateOrderedArray(0);
            TestHelpers.AssertArraysAreIdentical(reference, data);
        }
        
    }
}

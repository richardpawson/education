using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SortingTestbed
{
    [TestClass]
    public class BubbleSortTests
    {
        [TestMethod]
        public void Bubble1()
        {
            var data = TestHelpers.GenerateRandomisedArray(10);
            SortAlgorithms.BubbleSort(data);
            var reference = TestHelpers.GenerateOrderedArray(10);
            TestHelpers.AssertArraysAreIdentical(reference, data);
        }

        [TestMethod]
        public void Merge1()
        {
            var data = TestHelpers.GenerateRandomisedArray(10);
            SortAlgorithms.BubbleSort(data);
            var reference = TestHelpers.GenerateOrderedArray(10);
            TestHelpers.AssertArraysAreIdentical(reference, data);
        }
        
    }
}

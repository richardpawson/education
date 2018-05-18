using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SortingTestbed
{
    [TestClass]
    public class BinarySearchTests
    {
        [TestMethod]
        public void BinarySearchFor33()
        {
            var data = TestHelpers.GenerateOrderedArray(100);
            int searchFor = 33;
            var index = SearchingAlgorithms.BinarySearch(data, searchFor);
            Assert.AreEqual(33, data[index]);
        }

        [TestMethod]
        public void BinarySearchFor99()
        {
            var data = TestHelpers.GenerateOrderedArray(100);
            int searchFor = 99;
            var index = SearchingAlgorithms.BinarySearch(data, searchFor);
            Assert.AreEqual(99, data[index]);
        }

        [TestMethod]
        public void BinarySearchFor0()
        {
            var data = TestHelpers.GenerateOrderedArray(100);
            int searchFor = 0;
            var index = SearchingAlgorithms.BinarySearch(data, searchFor);
            Assert.AreEqual(0, data[index]);
        }

        [TestMethod]
        public void BinarySearchOnOddNumber()
        {
            var data = TestHelpers.GenerateOrderedArray(99);
            int searchFor = 75;
            var index = SearchingAlgorithms.BinarySearch(data, searchFor);
            Assert.AreEqual(75, data[index]);
        }

        [TestMethod]
        public void BinarySearch1()
        {
            var data = TestHelpers.GenerateOrderedArray(1);
            int searchFor = 0;
            var index = SearchingAlgorithms.BinarySearch(data, searchFor);
            Assert.AreEqual(0, data[index]);
        }

        [TestMethod]
        public void BinarySearchNotFound()
        {
            var data = TestHelpers.GenerateOrderedArray(10);
            int searchFor = 20;
            var index = SearchingAlgorithms.BinarySearch(data, searchFor);
            Assert.AreEqual(-1, index);
        }
    }
}

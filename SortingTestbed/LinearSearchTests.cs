using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SortingTestbed
{
    [TestClass]
    public class LinearSearchTests
    {
        [TestMethod]
        public void LinearSearch10()
        {
            var data = TestHelpers.GenerateRandomisedArray(10);
            int searchFor = 5;
            var index = SearchingAlgorithms.LinearSearch(data, searchFor);
            Assert.AreEqual(5, data[index]);
        }

        [TestMethod]
        public void LinearSearch1()
        {
            var data = TestHelpers.GenerateRandomisedArray(1);
            int searchFor = 0;
            var index = SearchingAlgorithms.LinearSearch(data, searchFor);
            Assert.AreEqual(0, data[index]);
        }

        [TestMethod]
        public void LinearSearchNotFound()
        {
            var data = TestHelpers.GenerateRandomisedArray(10);
            int searchFor = 20;
            var index = SearchingAlgorithms.LinearSearch(data, searchFor);
            Assert.AreEqual(-1, index);
        }
    }
}

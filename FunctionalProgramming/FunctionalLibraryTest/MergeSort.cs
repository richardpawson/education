using FunctionalLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FunctionalLibraryTest
{
    [TestClass]
    public class MergeSort : TestBase
    {
        [TestMethod]
        public void MergeSort1()
        {
            var list = FList.New(7,1,4,6,3,2,5);
            var actual = Sorting.MergeSort((x,y) => x < y, list);
            var expected = FList.New(1,2,3,4,5,6,7);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void MergeSort2()
        {
            var list = FList.New(1, 4, 6, 3, 2, 5);
            var actual = Sorting.MergeSort((x, y) => x < y, list);
            var expected = FList.New(1, 2, 3, 4, 5, 6);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void MergeSort3()
        {
            var list = FList.New(3,3, 4, 4, 3);
            var actual = Sorting.MergeSort((x, y) => x < y, list);
            var expected = FList.New(3,3,3,4,4);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void MergeSort4()
        {
            var list = FList.New(3);
            var actual = Sorting.MergeSort((x, y) => x < y, list);
            var expected = FList.New(3);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void MergeSort5()
        {
            var list = FList.Empty<int>();
            var actual = Sorting.MergeSort((x, y) => x < y, list);
            var expected = FList.Empty<int>();
            Assert.AreEqual(expected, actual);
        }

    }
}

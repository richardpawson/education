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
            var list = FC.NewFList(7,1,4,6,3,2,5);
            var actual = Sorting.MergeSort((x,y) => x < y, list);
            var expected = FC.NewFList(1,2,3,4,5,6,7);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void MergeSort2()
        {
            var list = FC.NewFList(1, 4, 6, 3, 2, 5);
            var actual = Sorting.MergeSort((x, y) => x < y, list);
            var expected = FC.NewFList(1, 2, 3, 4, 5, 6);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void MergeSort3()
        {
            var list = FC.NewFList(3,3, 4, 4, 3);
            var actual = Sorting.MergeSort((x, y) => x < y, list);
            var expected = FC.NewFList(3,3,3,4,4);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void MergeSort4()
        {
            var list = FC.NewFList(3);
            var actual = Sorting.MergeSort((x, y) => x < y, list);
            var expected = FC.NewFList(3);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void MergeSort5()
        {
            var list = FC.EmptyList<int>();
            var actual = Sorting.MergeSort((x, y) => x < y, list);
            var expected = FC.EmptyList<int>();
            Assert.AreEqual(expected, actual);
        }

    }
}

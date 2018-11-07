using FunctionalLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FunctionalLibraryTest
{
    [TestClass]
    public class Drop : TestBase
    {
        [TestMethod]
        public void Drop1()
        {
            var list = FC.NewFList(1, 2, 3, 4, 5);
            var actual = FC.Drop(1, list);
            var expected = FC.NewFList(2, 3, 4, 5);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Drop2()
        {
            var list = FC.NewFList(1, 2, 3, 4, 5);
            var actual = FC.Drop(4, list);
            var expected = FC.NewFList(5);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Drop3()
        {
            var list = FC.NewFList(1, 2, 3, 4, 5);
            var actual = FC.Drop(5, list);
            var expected = FC.EmptyList<int>();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Drop4()
        {
            var list = FC.NewFList(1, 2, 3, 4, 5);
            var actual = FC.Drop(0, list);
            var expected = FC.NewFList(1, 2, 3, 4, 5);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Drop5()
        {
            var list = FC.NewFList(1, 2, 3, 4, 5);
            var actual = FC.Drop(6, list);
            var expected = FC.EmptyList<int>();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Drop6()
        {
            var list = FC.EmptyList<int>();
            var actual = FC.Drop(1, list);
            var expected = FC.EmptyList<int>();
            Assert.AreEqual(expected, actual);
        }
    }
}

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
            var list = FL.NewFList(1, 2, 3, 4, 5);
            var actual = FL.Drop(1, list);
            var expected = FL.NewFList(2, 3, 4, 5);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Drop2()
        {
            var list = FL.NewFList(1, 2, 3, 4, 5);
            var actual = FL.Drop(4, list);
            var expected = FL.NewFList(5);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Drop3()
        {
            var list = FL.NewFList(1, 2, 3, 4, 5);
            var actual = FL.Drop(5, list);
            var expected = FL.EmptyList<int>();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Drop4()
        {
            var list = FL.NewFList(1, 2, 3, 4, 5);
            var actual = FL.Drop(0, list);
            var expected = FL.NewFList(1, 2, 3, 4, 5);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Drop5()
        {
            var list = FL.NewFList(1, 2, 3, 4, 5);
            var actual = FL.Drop(6, list);
            var expected = FL.EmptyList<int>();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Drop6()
        {
            var list = FL.EmptyList<int>();
            var actual = FL.Drop(1, list);
            var expected = FL.EmptyList<int>();
            Assert.AreEqual(expected, actual);
        }
    }
}

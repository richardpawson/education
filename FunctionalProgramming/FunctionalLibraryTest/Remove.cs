using FunctionalLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FunctionalLibraryTest
{
    [TestClass]
    public class RemoveFirst : TestBase
    {

        [TestMethod]
        public void RemoveFirst1()
        {
            var list = FL.NewFList(1, 2, 3, 4);
            var actual = FL.RemoveFirst(3, list);
            var expected = FL.NewFList(1, 2, 4);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void RemoveFirst2()
        {
            var list = FL.NewFList(1, 2, 3, 4);
            var actual = FL.RemoveFirst(1, list);
            var expected = FL.NewFList(2, 3, 4);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void RemoveFirst3()
        {
            var list = FL.NewFList(1, 2, 3, 4);
            var actual = FL.RemoveFirst(4, list);
            var expected = FL.NewFList(1, 2, 3);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void RemoveFirst4()
        {
            var list = FL.NewFList(4);
            var actual = FL.RemoveFirst(4, list);
            var expected = FL.EmptyList<int>();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void RemoveFirst5()
        {
            var list = FL.EmptyList<int>();
            var actual = FL.RemoveFirst(4, list);
            var expected = FL.EmptyList<int>();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void RemoveFirst6()
        {
            var list = FL.NewFList(3, 2, 3, 4);
            var actual = FL.RemoveFirst(3, list);
            var expected = FL.NewFList(2, 3, 4);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void RemoveFirst7()
        {
            var list = FL.NewFList(3, 3, 3);
            var actual = FL.RemoveFirst(3, list);
            var expected = FL.NewFList(3,3);
            Assert.AreEqual(expected, actual);
        }
    }
}

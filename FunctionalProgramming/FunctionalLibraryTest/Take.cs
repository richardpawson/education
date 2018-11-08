using FunctionalLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FunctionalLibraryTest
{
    [TestClass]
    public class Take : TestBase
    {
        [TestMethod]
        public void Take1()
        {
            var list = FL.NewFList(1, 2, 3, 4, 5);
            var actual = FL.Take(1, list);
            var expected = FL.NewFList(1);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Take2()
        {
            var list = FL.NewFList(1, 2, 3, 4, 5);
            var actual = FL.Take(4, list);
            var expected = FL.NewFList(1, 2, 3, 4);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Take3()
        {
            var list = FL.NewFList(1, 2, 3, 4, 5);
            var actual = FL.Take(5, list);
            var expected = FL.NewFList(1, 2, 3, 4, 5);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Take4()
        {
            var list = FL.NewFList(1, 2, 3, 4, 5);
            var actual = FL.Take(0, list);
            var expected = FL.EmptyList<int>();
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void Take5()
        {
            var list = FL.NewFList(1, 2, 3, 4, 5);
            var actual = FL.Take(6, list);
            var expected = FL.NewFList(1, 2, 3, 4, 5);
            Assert.AreEqual(expected, actual);
        }

    }
}

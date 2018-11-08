using FunctionalLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FunctionalLibraryTest
{
    [TestClass]
    public class Elem : TestBase
    {
        [TestMethod]
        public void Elem1()
        {
            var list = FL.NewFList(1, 2, 3, 4, 5);
            var actual = FL.Elem(3, list);
            var expected = true;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Elem2()
        {
            var list = FL.NewFList(1, 2, 2, 4, 5);
            var actual = FL.Elem(2, list);
            var expected = true;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Elem3()
        {
            var list = FL.NewFList(1, 2, 3, 4, 5);
            var actual = FL.Elem(6, list);
            var expected = false;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Elem4()
        {
            var list = FL.NewFList(5);
            var actual = FL.Elem(5, list);
            var expected = true;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Elem5()
        {
            var list = FL.NewFList(5);
            var actual = FL.Elem(6, list);
            var expected = false;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Elem6()
        {
            var list = FL.EmptyList<int>();
            var actual = FL.Elem(6, list);
            var expected = false;
            Assert.AreEqual(expected, actual);
        }
    }
}

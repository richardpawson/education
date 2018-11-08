using FunctionalLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FunctionalLibraryTest
{
    [TestClass]
    public class Reverse : TestBase
    {
        [TestMethod]
        public void Reverse1()
        {
            var list = FL.NewFList(1, 2, 3, 4, 5);
            var actual = FL.Reverse(list);
            var expected = FL.NewFList(5,4,3,2,1);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Reverse2()
        {
            var list = FL.NewFList(3,4);
            var actual = FL.Reverse(list);
            var expected = FL.NewFList(4,3);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Reverse3()
        {
            var list = FL.NewFList(2);
            var actual = FL.Reverse(list);
            var expected = FL.NewFList(2);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Reverse4()
        {
            var list = FL.EmptyList<int>();
            var actual = FL.Reverse(list);
            var expected = FL.EmptyList<int>();
            Assert.AreEqual(expected, actual);
        }

    }
}

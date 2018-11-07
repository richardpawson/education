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
            var list = FC.NewFList(1, 2, 3, 4, 5);
            var actual = FC.Reverse(list);
            var expected = FC.NewFList(5,4,3,2,1);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Reverse2()
        {
            var list = FC.NewFList(3,4);
            var actual = FC.Reverse(list);
            var expected = FC.NewFList(4,3);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Reverse3()
        {
            var list = FC.NewFList(2);
            var actual = FC.Reverse(list);
            var expected = FC.NewFList(2);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Reverse4()
        {
            var list = FC.EmptyList<int>();
            var actual = FC.Reverse(list);
            var expected = FC.EmptyList<int>();
            Assert.AreEqual(expected, actual);
        }

    }
}

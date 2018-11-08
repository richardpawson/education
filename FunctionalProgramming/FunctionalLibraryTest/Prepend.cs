using FunctionalLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FunctionalLibraryTest
{
    [TestClass]
    public class Prepend : TestBase
    {
        [TestMethod]
        public void Prepend1()
        {
            var list = FL.NewFList(1, 2, 3);
            var actual = FL.Prepend(4, list);
            var expected = FL.NewFList(4, 1, 2, 3);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Prepend2()
        {
            var list = FL.NewFList(1);
            var actual = FL.Prepend(4, list);
            var expected = FL.NewFList(4, 1);
            Assert.AreEqual(expected, actual);
        }


        [TestMethod]
        public void Prepend3()
        {
            var list = FL.EmptyList<int>();
            var actual = FL.Prepend(4, list);
            var expected = FL.NewFList(4);
            Assert.AreEqual(expected, actual);
        }

    }
}

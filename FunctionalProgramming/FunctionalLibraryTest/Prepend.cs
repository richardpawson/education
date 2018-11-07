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
            var list = FC.NewFList(1, 2, 3);
            var actual = FC.Prepend(4, list);
            var expected = FC.NewFList(4, 1, 2, 3);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Prepend2()
        {
            var list = FC.NewFList(1);
            var actual = FC.Prepend(4, list);
            var expected = FC.NewFList(4, 1);
            Assert.AreEqual(expected, actual);
        }


        [TestMethod]
        public void Prepend3()
        {
            var list = FC.EmptyList<int>();
            var actual = FC.Prepend(4, list);
            var expected = FC.NewFList(4);
            Assert.AreEqual(expected, actual);
        }

    }
}

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
            var list = FList.New(1, 2, 3);
            var actual = FList.Prepend(4, list);
            var expected = FList.New(4, 1, 2, 3);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Prepend2()
        {
            var list = FList.New(1);
            var actual = FList.Prepend(4, list);
            var expected = FList.New(4, 1);
            Assert.AreEqual(expected, actual);
        }


        [TestMethod]
        public void Prepend3()
        {
            var list = FList.Empty<int>();
            var actual = FList.Prepend(4, list);
            var expected = FList.New(4);
            Assert.AreEqual(expected, actual);
        }

    }
}

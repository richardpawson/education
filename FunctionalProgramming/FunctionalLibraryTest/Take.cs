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
            var list = FList.New(1, 2, 3, 4, 5);
            var actual = FList.Take(1, list);
            var expected = FList.New(1);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Take2()
        {
            var list = FList.New(1, 2, 3, 4, 5);
            var actual = FList.Take(4, list);
            var expected = FList.New(1, 2, 3, 4);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Take3()
        {
            var list = FList.New(1, 2, 3, 4, 5);
            var actual = FList.Take(5, list);
            var expected = FList.New(1, 2, 3, 4, 5);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Take4()
        {
            var list = FList.New(1, 2, 3, 4, 5);
            var actual = FList.Take(0, list);
            var expected = FList.Empty<int>();
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void Take5()
        {
            var list = FList.New(1, 2, 3, 4, 5);
            var actual = FList.Take(6, list);
            var expected = FList.New(1, 2, 3, 4, 5);
            Assert.AreEqual(expected, actual);
        }

    }
}

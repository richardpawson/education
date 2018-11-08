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
            var list = FList.New(1, 2, 3, 4, 5);
            var actual = FList.Drop(1, list);
            var expected = FList.New(2, 3, 4, 5);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Drop2()
        {
            var list = FList.New(1, 2, 3, 4, 5);
            var actual = FList.Drop(4, list);
            var expected = FList.New(5);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Drop3()
        {
            var list = FList.New(1, 2, 3, 4, 5);
            var actual = FList.Drop(5, list);
            var expected = FList.Empty<int>();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Drop4()
        {
            var list = FList.New(1, 2, 3, 4, 5);
            var actual = FList.Drop(0, list);
            var expected = FList.New(1, 2, 3, 4, 5);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Drop5()
        {
            var list = FList.New(1, 2, 3, 4, 5);
            var actual = FList.Drop(6, list);
            var expected = FList.Empty<int>();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Drop6()
        {
            var list = FList.Empty<int>();
            var actual = FList.Drop(1, list);
            var expected = FList.Empty<int>();
            Assert.AreEqual(expected, actual);
        }
    }
}

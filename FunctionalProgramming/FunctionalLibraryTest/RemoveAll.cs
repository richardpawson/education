using FunctionalLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FunctionalLibraryTest
{
    [TestClass]
    public class RemoveAll : TestBase
    {

        [TestMethod]
        public void RemoveAll1()
        {
            var list = FList.New(1, 2, 3, 4);
            var actual = FList.RemoveAll(3, list);
            var expected = FList.New(1, 2, 4);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void RemoveAll2()
        {
            var list = FList.New(1, 2, 3, 4);
            var actual = FList.RemoveAll(1, list);
            var expected = FList.New(2, 3, 4);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void RemoveAll3()
        {
            var list = FList.New(1, 2, 3, 4);
            var actual = FList.RemoveAll(4, list);
            var expected = FList.New(1, 2, 3);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void RemoveAll4()
        {
            var list = FList.New(4);
            var actual = FList.RemoveAll(4, list);
            var expected = FList.Empty<int>();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void RemoveAll5()
        {
            var list = FList.Empty<int>();
            var actual = FList.RemoveAll(4, list);
            var expected = FList.Empty<int>();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void RemoveAll6()
        {
            var list = FList.New(3, 2, 3, 4);
            var actual = FList.RemoveAll(3, list);
            var expected = FList.New(2, 4);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void RemoveAll7()
        {
            var list = FList.New(3, 3, 3);
            var actual = FList.RemoveAll(3, list);
            var expected = FList.Empty<int>();
            Assert.AreEqual(expected, actual);
        }
    }
}

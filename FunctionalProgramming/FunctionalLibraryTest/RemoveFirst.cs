using FunctionalLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FunctionalLibraryTest
{
    [TestClass]
    public class RemoveFirst : TestBase
    {

        [TestMethod]
        public void RemoveFirst1()
        {
            var list = FList.New(1, 2, 3, 4);
            var actual = FList.RemoveFirst(3, list);
            var expected = FList.New(1, 2, 4);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void RemoveFirst2()
        {
            var list = FList.New(1, 2, 3, 4);
            var actual = FList.RemoveFirst(1, list);
            var expected = FList.New(2, 3, 4);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void RemoveFirst3()
        {
            var list = FList.New(1, 2, 3, 4);
            var actual = FList.RemoveFirst(4, list);
            var expected = FList.New(1, 2, 3);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void RemoveFirst4()
        {
            var list = FList.New(4);
            var actual = FList.RemoveFirst(4, list);
            var expected = FList.Empty<int>();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void RemoveFirst5()
        {
            var list = FList.Empty<int>();
            var actual = FList.RemoveFirst(4, list);
            var expected = FList.Empty<int>();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void RemoveFirst6()
        {
            var list = FList.New(3, 2, 3, 4);
            var actual = FList.RemoveFirst(3, list);
            var expected = FList.New(2, 3, 4);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void RemoveFirst7()
        {
            var list = FList.New(3, 3, 3);
            var actual = FList.RemoveFirst(3, list);
            var expected = FList.New(3,3);
            Assert.AreEqual(expected, actual);
        }
    }
}

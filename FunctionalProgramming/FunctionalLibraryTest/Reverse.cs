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
            var list = FList.New(1, 2, 3, 4, 5);
            var actual = FList.Reverse(list);
            var expected = FList.New(5,4,3,2,1);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Reverse2()
        {
            var list = FList.New(3,4);
            var actual = FList.Reverse(list);
            var expected = FList.New(4,3);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Reverse3()
        {
            var list = FList.New(2);
            var actual = FList.Reverse(list);
            var expected = FList.New(2);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Reverse4()
        {
            var list = FList.Empty<int>();
            var actual = FList.Reverse(list);
            var expected = FList.Empty<int>();
            Assert.AreEqual(expected, actual);
        }

    }
}

using FunctionalLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FunctionalLibraryTest
{
    [TestClass]
    public class Append : TestBase
    {
        [TestMethod]
        public void Append1()
        {
            var list = FList.New(1, 2, 3);
            var actual = FList.Append(list, FList.New(4));
            var expected = FList.New(1, 2, 3, 4);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Append2()
        {
            var list = FList.New(1);
            var actual = FList.Append(list, FList.New(4));
            var expected = FList.New(1, 4);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Append3()
        {
            var list = FList.Empty<int>();
            var actual = FList.Append(list, FList.New(4));
            var expected = FList.New(4);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Append4()
        {
            var list = FList.New(1,2);
            var actual = FList.Append(list, FList.New(4,7));
            var expected = FList.New(1,2,4,7);
            Assert.AreEqual(expected, actual);
        }

    }
}

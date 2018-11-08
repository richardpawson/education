using FunctionalLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FunctionalLibraryTest
{
    [TestClass]
    public class Length : TestBase
    {
        [TestMethod]
        public void Length1()
        {
            var list = FList.New(1, 2, 3, 4, 5);
            var actual = FList.Length(list);
            var expected = 5;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Length2()
        {
            var list = FList.New(5);
            var actual = FList.Length(list);
            var expected = 1;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Length3()
        {
            var list = FList.Empty<int>();
            var actual = FList.Length(list);
            var expected = 0;
            Assert.AreEqual(expected, actual);
        }


    }
}

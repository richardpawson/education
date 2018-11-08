using FunctionalLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FunctionalLibraryTest
{
    [TestClass]
    public class Map : TestBase
    {
        [TestMethod]
        public void Map1()
        {
            var list = FList.New(1, 2, 3);
            var actual = FList.Map(i => i * i, list);
            var expected = FList.New(1, 4, 9);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Map2()
        {
            var list = FList.New(3);
            var actual = FList.Map(i => i * i, list);
            var expected = FList.New(9);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Map3()
        {
            var list = FList.Empty<int>();
            var actual = FList.Map(i => i * i, list);
            var expected = FList.Empty<int>();
            Assert.AreEqual(expected, actual);
        }

    }
}

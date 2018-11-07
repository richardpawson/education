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
            var list = FC.NewFList(1, 2, 3);
            var actual = FC.Map(i => i * i, list);
            var expected = FC.NewFList(1, 4, 9);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Map2()
        {
            var list = FC.NewFList(3);
            var actual = FC.Map(i => i * i, list);
            var expected = FC.NewFList(9);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Map3()
        {
            var list = FC.EmptyList<int>();
            var actual = FC.Map(i => i * i, list);
            var expected = FC.EmptyList<int>();
            Assert.AreEqual(expected, actual);
        }

    }
}

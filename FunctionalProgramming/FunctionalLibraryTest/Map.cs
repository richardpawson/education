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
            var list = FL.NewFList(1, 2, 3);
            var actual = FL.Map(i => i * i, list);
            var expected = FL.NewFList(1, 4, 9);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Map2()
        {
            var list = FL.NewFList(3);
            var actual = FL.Map(i => i * i, list);
            var expected = FL.NewFList(9);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Map3()
        {
            var list = FL.EmptyList<int>();
            var actual = FL.Map(i => i * i, list);
            var expected = FL.EmptyList<int>();
            Assert.AreEqual(expected, actual);
        }

    }
}

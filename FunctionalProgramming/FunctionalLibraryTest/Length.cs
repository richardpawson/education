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
            var list = FL.NewFList(1, 2, 3, 4, 5);
            var actual = FL.Length(list);
            var expected = 5;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Length2()
        {
            var list = FL.NewFList(5);
            var actual = FL.Length(list);
            var expected = 1;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Length3()
        {
            var list = FL.EmptyList<int>();
            var actual = FL.Length(list);
            var expected = 0;
            Assert.AreEqual(expected, actual);
        }


    }
}

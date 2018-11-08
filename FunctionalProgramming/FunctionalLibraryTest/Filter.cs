using FunctionalLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FunctionalLibraryTest
{
    [TestClass]
    public class FilterTests :TestBase
    {
        [TestMethod]
        public void Filter1()
        {
            var list = FL.NewFList(1, 2, 3);
            var actual = FL.Filter(i => i > 1, list);
            var expected = FL.NewFList(2, 3);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Filter2()
        {
            var list = FL.NewFList(1, 2, 3);
            var actual = FL.Filter(i => i > 3, list);
            var expected = FL.EmptyList<int>();
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void Filter3()
        {
            var list = FL.NewFList(1, 2, 3);
            var actual = FL.Filter(i => i > 0, list);
            var expected = FL.NewFList(1, 2, 3);
            Assert.AreEqual(expected, actual);
        }
    }
}

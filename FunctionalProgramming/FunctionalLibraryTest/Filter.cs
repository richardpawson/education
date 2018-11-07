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
            var list = FC.NewFList(1, 2, 3);
            var actual = FC.Filter(i => i > 1, list);
            var expected = FC.NewFList(2, 3);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Filter2()
        {
            var list = FC.NewFList(1, 2, 3);
            var actual = FC.Filter(i => i > 3, list);
            var expected = FC.EmptyList<int>();
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void Filter3()
        {
            var list = FC.NewFList(1, 2, 3);
            var actual = FC.Filter(i => i > 0, list);
            var expected = FC.NewFList(1, 2, 3);
            Assert.AreEqual(expected, actual);
        }
    }
}

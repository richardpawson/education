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
            var list = FList.New(1, 2, 3);
            var actual = FList.Filter(i => i > 1, list);
            var expected = FList.New(2, 3);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Filter2()
        {
            var list = FList.New(1, 2, 3);
            var actual = FList.Filter(i => i > 3, list);
            var expected = FList.Empty<int>();
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void Filter3()
        {
            var list = FList.New(1, 2, 3);
            var actual = FList.Filter(i => i > 0, list);
            var expected = FList.New(1, 2, 3);
            Assert.AreEqual(expected, actual);
        }
    }
}

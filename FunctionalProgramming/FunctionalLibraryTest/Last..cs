using FunctionalLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FunctionalLibraryTest
{
    [TestClass]
    public class Last : TestBase
    {
        [TestMethod]
        public void Last1()
        {
            var list = FL.NewFList(1, 2, 3,4,5);
            var actual = FL.Last(list);
            var expected = 5;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Last2()
        {
            var list = FL.NewFList(1);
            var actual = FL.Last(list);
            var expected = 1;
            Assert.AreEqual(expected, actual);
        }

    }
}

using FunctionalLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FunctionalLibraryTest
{
    [TestClass]
    public class FoldR : TestBase
    {
        [TestMethod]
        public void FoldR1()
        {
            var list = FL.NewFList(1, 2, 4, 8, 16);
            int actual = FL.FoldR((agg, input) => agg + input, 0, list);
            Assert.AreEqual(31, actual);
        }

        [TestMethod]
        public void FoldR2()
        {
            var list = FL.NewFList(1, 2, 4, 8, 16);
            int actual = FL.FoldR((agg, input) => agg * input, 1, list);
            Assert.AreEqual(1024, actual);
        }

        [TestMethod]
        public void FoldR3()
        {
            var list = FL.NewFList(1, 2, 4, 8, 16);
            int actual = FL.FoldR((agg, input) => agg - input, 0, list);
            Assert.AreEqual(11, actual);
        }

        [TestMethod]
        public void FoldR4()
        {
            var list = FL.NewFList(1, 2, 4, 8, 16);
            int actual = FL.FoldR((agg, input) => agg / input, 1, list);
            Assert.AreEqual(4, actual);
        }
    }
}

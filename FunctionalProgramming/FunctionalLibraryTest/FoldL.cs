using FunctionalLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FunctionalLibraryTest
{
    [TestClass]
    public class FoldL : TestBase
    {
        [TestMethod]
        public void FoldL1()
        {
            var list = FList.New(1, 2, 4,8,16);
            int actual = FList.FoldL((agg, input) => agg + input, 0, list);
            Assert.AreEqual(31, actual);
        }

        [TestMethod]
        public void FoldL2()
        {
            var list = FList.New(1, 2, 4, 8, 16);
            int actual = FList.FoldL((agg, input) => agg * input, 1, list);
            Assert.AreEqual(1024, actual);
        }

        [TestMethod]
        public void FoldL3()
        {
            var list = FList.New(1, 2, 4, 8, 16);
            int actual = FList.FoldL((agg, input) => agg - input, 0, list);
            Assert.AreEqual(-31, actual);
        }

        [TestMethod]
        public void FoldL4()
        {
            var list = FList.New<float>(1, 2, 4, 8, 16);
            float actual = FList.FoldL((agg, input) => agg / input, 1, list);
            Assert.AreEqual(9.765625e-4, actual);
        }
    }
}

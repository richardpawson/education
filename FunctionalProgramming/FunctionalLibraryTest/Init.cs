using FunctionalLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FunctionalLibraryTest
{
    [TestClass]
    public class Init : TestBase
    {
        [TestMethod]
        public void Init1()
        {
            var list = FL.NewFList(1, 2, 3,4,5);
            var actual = FL.Init(list);
            var expected = FL.NewFList(1, 2, 3, 4);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Init2()
        {
            var list = FL.NewFList(1);
            var actual = FL.Init(list);
            var expected = FL.EmptyList<int>();
            Assert.AreEqual(expected, actual);
        }

    }
}

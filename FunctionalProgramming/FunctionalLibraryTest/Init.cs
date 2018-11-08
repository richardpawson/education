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
            var list = FList.New(1, 2, 3,4,5);
            var actual = FList.Init(list);
            var expected = FList.New(1, 2, 3, 4);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Init2()
        {
            var list = FList.New(1);
            var actual = FList.Init(list);
            var expected = FList.Empty<int>();
            Assert.AreEqual(expected, actual);
        }

    }
}

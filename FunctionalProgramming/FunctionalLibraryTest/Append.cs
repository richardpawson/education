using FunctionalLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FunctionalLibraryTest
{
    [TestClass]
    public class Append : TestBase
    {
        [TestMethod]
        public void Append1()
        {
            var list = FC.NewFList(1, 2, 3);
            var actual = FC.Append(list, 4);
            var expected = FC.NewFList(1, 2, 3, 4);
            Assert.AreEqual(expected, actual);
        }


        [TestMethod]
        public void Append2()
        {
            var list = FC.NewFList(1);
            var actual = FC.Append(list, 4);
            var expected = FC.NewFList(1, 4);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Append3()
        {
            var list = FC.EmptyList<int>();
            var actual = FC.Append(list, 4);
            var expected = FC.NewFList(4);
            Assert.AreEqual(expected, actual);
        }

    }
}

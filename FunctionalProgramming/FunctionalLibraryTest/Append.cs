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
            var list = FL.NewFList(1, 2, 3);
            var actual = FL.Append(list, FL.NewFList(4));
            var expected = FL.NewFList(1, 2, 3, 4);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Append2()
        {
            var list = FL.NewFList(1);
            var actual = FL.Append(list, FL.NewFList(4));
            var expected = FL.NewFList(1, 4);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Append3()
        {
            var list = FL.EmptyList<int>();
            var actual = FL.Append(list, FL.NewFList(4));
            var expected = FL.NewFList(4);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Append4()
        {
            var list = FL.NewFList(1,2);
            var actual = FL.Append(list, FL.NewFList(4,7));
            var expected = FL.NewFList(1,2,4,7);
            Assert.AreEqual(expected, actual);
        }

    }
}

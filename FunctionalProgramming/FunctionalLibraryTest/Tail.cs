using FunctionalLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FunctionalLibraryTest
{
    [TestClass]
    public class Tail : TestBase
    {
        [TestMethod]
        public void Tail1()
        {
            var list = FC.NewFList(1, 2, 3, 4, 5);
            var actual = FC.Tail(list);
            var expected = FC.NewFList(2, 3, 4,5);
            Assert.AreEqual(expected, actual);
        }

        public void Tail2()
        {
            var list = FC.NewFList(1, 2);
            var actual = FC.Tail(list);
            var expected = FC.NewFList(2);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Tail3()
        {
            var list = FC.NewFList(5);
            var actual = FC.Tail(list);
            var expected = FC.EmptyList<int>();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Tail4()
        {
            var list = FC.EmptyList<int>();
            try
            {
                var actual = FC.Tail(list);
                Assert.Fail("EmptyListException NOT thrown");
            }
            catch (EmptyListException)
            {
            }
        }


    }
}

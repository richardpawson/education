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
            var list = FL.NewFList(1, 2, 3, 4, 5);
            var actual = FL.Tail(list);
            var expected = FL.NewFList(2, 3, 4,5);
            Assert.AreEqual(expected, actual);
        }

        public void Tail2()
        {
            var list = FL.NewFList(1, 2);
            var actual = FL.Tail(list);
            var expected = FL.NewFList(2);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Tail3()
        {
            var list = FL.NewFList(5);
            var actual = FL.Tail(list);
            var expected = FL.EmptyList<int>();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Tail4()
        {
            var list = FL.EmptyList<int>();
            try
            {
                var actual = FL.Tail(list);
                Assert.Fail("EmptyListException NOT thrown");
            }
            catch (EmptyListException)
            {
            }
        }


    }
}

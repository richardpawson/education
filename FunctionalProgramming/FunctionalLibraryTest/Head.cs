using FunctionalLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FunctionalLibraryTest
{
    [TestClass]
    public class Head : TestBase
    {
        [TestMethod]
        public void Head1()
        {
            var list = FL.NewFList(1, 2, 3, 4, 5);
            var actual = FL.Head(list);
            var expected = 1;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Head2()
        {
            var list = FL.NewFList(5);
            var actual = FL.Head(list);
            var expected = 5;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Head3()
        {
            var list = FL.EmptyList<int>();
            try
            {
                var actual = FL.Head(list);
                Assert.Fail("EmptyListException NOT thrown");
            }
            catch (EmptyListException)
            {
            }
        }


    }
}

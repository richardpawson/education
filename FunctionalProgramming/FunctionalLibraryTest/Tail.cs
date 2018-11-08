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
            var list = FList.New(1, 2, 3, 4, 5);
            var actual = FList.Tail(list);
            var expected = FList.New(2, 3, 4,5);
            Assert.AreEqual(expected, actual);
        }

        public void Tail2()
        {
            var list = FList.New(1, 2);
            var actual = FList.Tail(list);
            var expected = FList.New(2);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Tail3()
        {
            var list = FList.New(5);
            var actual = FList.Tail(list);
            var expected = FList.Empty<int>();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Tail4()
        {
            var list = FList.Empty<int>();
            try
            {
                var actual = FList.Tail(list);
                Assert.Fail("EmptyListException NOT thrown");
            }
            catch (EmptyListException)
            {
            }
        }


    }
}

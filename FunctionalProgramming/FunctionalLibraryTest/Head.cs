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
            var list = FList.New(1, 2, 3, 4, 5);
            var actual = FList.Head(list);
            var expected = 1;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Head2()
        {
            var list = FList.New(5);
            var actual = FList.Head(list);
            var expected = 5;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Head3()
        {
            var list = FList.Empty<int>();
            try
            {
                var actual = FList.Head(list);
                Assert.Fail("EmptyListException NOT thrown");
            }
            catch (EmptyListException)
            {
            }
        }


    }
}

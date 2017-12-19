using FunctionalLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FunctionalLibraryTest
{
    [TestClass]
    public class FListTests
    {
        [TestMethod]
        public void Where1()
        {
            var list = FList.Cons(1, 2, 3);
            var actual = list.Where(i => i > 1);
            var expected = FList.Cons(2, 3);
            AssertListsAreIdentical(expected, actual);
        }

        [TestMethod]
        public void Any1()
        {
            var list = FList.Cons(1, 2, 3);
            var any = list.Any(i => i > 1);
            Assert.IsTrue(any);
        }

        [TestMethod]
        public void Any2()
        {
            var list = FList.Cons(1, 2, 3);
            var any = list.Any(i => i > 3);
            Assert.IsFalse(any);
        }

        [TestMethod]
        public void Select1()
        {
            var list = FList.Cons(1, 2, 3);
            var actual = list.Select(i => i * i);
            var expected = FList.Cons(1, 4, 9);
            AssertListsAreIdentical(expected, actual);
        }

        [TestMethod]
        public void Aggregate1()
        {
            var list = FList.Cons(1, 2, 3,4,5);
            int actual = list.Aggregate((input, agg) => agg += input);
            Assert.AreEqual(15, actual);
        }

        [TestMethod]
        public void Aggregate2()
        {
            var list = FList.Cons(1, 2, 3);
            int actual = list.Aggregate((input, agg) => agg += input*input);
            Assert.AreEqual(14, actual);
        }

        #region helpers
        private void AssertListsAreIdentical<T>(FList<T> expected, FList<T> actual)
        {
            Assert.IsTrue(ListsAreIdentical(expected, actual));
        }
        private bool ListsAreIdentical<T>(FList<T> expected, FList<T> actual)
        {
            return expected.IsEmpty && actual.IsEmpty ||
                expected.Head.Equals(actual.Head) && ListsAreIdentical(expected.Tail, actual.Tail);
        }
        #endregion
    }
}

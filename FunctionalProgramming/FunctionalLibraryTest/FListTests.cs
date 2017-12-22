using FunctionalLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FunctionalLibraryTest
{
    [TestClass]
    public class FListTests
    {
        [TestMethod]
        public void Filter1()
        {
            var list = FList.Cons(1, 2, 3);
            var actual = list.Filter(i => i > 1);
            var expected = FList.Cons(2, 3);
            AssertListsAreIdentical(expected, actual);
        }

        [TestMethod]
        public void Filter2()
        {
            var list = FList.Cons(1, 2, 3);
            var actual = list.Filter(i => i > 3);
            var expected = FList.Empty<int>();
            AssertListsAreIdentical(expected, actual);
        }
        [TestMethod]
        public void Filter3()
        {
            var list = FList.Cons(1, 2, 3);
            var actual = list.Filter(i => i > 0);
            var expected = FList.Cons(1, 2, 3);
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
            var filtered = list.Filter(i => i > 3);
            var any = list.Any(i => i > 3);
            Assert.IsFalse(any);
        }

        [TestMethod]
        public void Map1()
        {
            var list = FList.Cons(1, 2, 3);
            var actual = list.Map(i => i * i);
            var expected = FList.Cons(1, 4, 9);
            AssertListsAreIdentical(expected, actual);
        }

        [TestMethod]
        public void Reduce1()
        {
            var list = FList.Cons(1, 2, 3,4,5);
            int actual = list.Reduce((input, agg) => agg += input);
            Assert.AreEqual(15, actual);
        }

        [TestMethod]
        public void Reduce2()
        {
            var list = FList.Cons(1, 2, 3);
            int actual = list.Reduce((input, agg) => agg += input*input);
            Assert.AreEqual(14, actual);
        }

        [TestMethod]
        public void Prepend1()
        {
            var list = FList.Cons(1, 2, 3);
            var actual = list.Prepend(4);
            var expected = FList.Cons(4, 1, 2, 3);
            AssertListsAreIdentical(expected, actual);
        }

        [TestMethod]
        public void Prepend2()
        {
            var list = FList.Cons(1);
            var actual = list.Prepend(4);
            var expected = FList.Cons(4, 1);
            AssertListsAreIdentical(expected, actual);
        }


        [TestMethod]
        public void Prepend3()
        {
            var list = FList.Empty<int>();
            var actual = list.Prepend(4);
            var expected = FList.Cons(4);
            AssertListsAreIdentical(expected, actual);
        }


        [TestMethod]
        public void Append1()
        {
            var list = FList.Cons(1, 2, 3);
            var actual = list.Append(4);
            var expected = FList.Cons(1, 2, 3, 4);
            AssertListsAreIdentical(expected, actual);
        }


        [TestMethod]
        public void Append2()
        {
            var list = FList.Cons(1);
            var actual = list.Append(4);
            var expected = FList.Cons(1,4);
            AssertListsAreIdentical(expected, actual);
        }

        [TestMethod]
        public void Append3()
        {
            var list = FList.Empty<int>();
            var actual = list.Append(4);
            var expected = FList.Cons(4);
            AssertListsAreIdentical(expected, actual);
        }

        [TestMethod]
        public void Remove1()
        {
            var list = FList.Cons(1, 2, 3, 4);
            var actual = list.Remove(3);
            var expected = FList.Cons(1, 2, 4);
            AssertListsAreIdentical(expected, actual);
        }

        [TestMethod]
        public void Remove2()
        {
            var list = FList.Cons(1, 2, 3, 4);
            var actual = list.Remove(1);
            var expected = FList.Cons(2, 3, 4);
            AssertListsAreIdentical(expected, actual);
        }

        [TestMethod]
        public void Remove3()
        {
            var list = FList.Cons(1, 2, 3, 4);
            var actual = list.Remove(4);
            var expected = FList.Cons(1,2,3);
            AssertListsAreIdentical(expected, actual);
        }

        [TestMethod]
        public void Remove4()
        {
            var list = FList.Cons(4);
            var actual = list.Remove(4);
            var expected = FList.Empty<int>();
            AssertListsAreIdentical(expected, actual);
        }

        [TestMethod]
        public void Remove5()
        {
            var list = FList.Empty<int>();
            var actual = list.Remove(4);
            var expected = FList.Empty<int>();
            AssertListsAreIdentical(expected, actual);
        }

        [TestMethod]
        public void Remove6()
        {
            var list = FList.Cons(3, 2, 3, 4);
            var actual = list.Remove(3);
            var expected = FList.Cons(2, 4);
            AssertListsAreIdentical(expected, actual);
        }

        [TestMethod]
        public void Remove7()
        {
            var list = FList.Cons(3, 3, 3);
            var actual = list.Remove(3);
            var expected = FList.Empty<int>();
            AssertListsAreIdentical(expected, actual);
        }

        [TestMethod]
        public void Skip1()
        {
            var list = FList.Cons(1,2,3,4,5);
            var actual = list.Skip(1);
            var expected = FList.Cons(2,3,4,5);
            AssertListsAreIdentical(expected, actual);
        }

        [TestMethod]
        public void Skip2()
        {
            var list = FList.Cons(1, 2, 3, 4, 5);
            var actual = list.Skip(4);
            var expected = FList.Cons(5);
            AssertListsAreIdentical(expected, actual);
        }

        [TestMethod]
        public void Skip3()
        {
            var list = FList.Cons(1, 2, 3, 4, 5);
            var actual = list.Skip(5);
            var expected = FList.Empty<int>();
            AssertListsAreIdentical(expected, actual);
        }

        [TestMethod]
        public void Skip4()
        {
            var list = FList.Cons(1, 2, 3, 4, 5);
            var actual = list.Skip(0);
            var expected = FList.Cons(1, 2, 3, 4, 5);
            AssertListsAreIdentical(expected, actual);
        }

        [TestMethod]
        public void Take1()
        {
            var list = FList.Cons(1, 2, 3, 4, 5);
            var actual = list.Take(1);
            var expected = FList.Cons(1);
            AssertListsAreIdentical(expected, actual);
        }

        [TestMethod]
        public void Take2()
        {
            var list = FList.Cons(1, 2, 3, 4, 5);
            var actual = list.Take(4);
            var expected = FList.Cons(1, 2, 3, 4);
            AssertListsAreIdentical(expected, actual);
        }

        [TestMethod]
        public void Take3()
        {
            var list = FList.Cons(1, 2, 3, 4, 5);
            var actual = list.Take(5);
            var expected = FList.Cons(1, 2, 3, 4, 5);
            AssertListsAreIdentical(expected, actual);
        }

        [TestMethod]
        public void Take4()
        {
            var list = FList.Cons(1, 2, 3, 4, 5);
            var actual = list.Take(0);
            var expected = FList.Empty<int>();
            AssertListsAreIdentical(expected, actual);
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

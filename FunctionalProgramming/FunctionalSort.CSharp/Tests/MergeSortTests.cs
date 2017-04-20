using Microsoft.VisualStudio.TestTools.UnitTesting;
using FunctionalLibrary;

namespace Tests
{
    [TestClass]
    public class MergeSortTests
    {
        [TestMethod]
        public void TestSortAlphabeticalHappyCase()
        {
            var list = FList.Cons("Flag", "Nest", "Cup", "Burg", "Yatch", "Next");
            var sorted = MergeSort.SortAlphabetical(list);
            var expected = FList.Cons("Burg", "Cup", "Flag", "Nest", "Next", "Yatch");
            Assert.AreEqual(expected, sorted);
        }

        [TestMethod]
        public void TestSortAlphabeticalWithDuplicates()
        {
            var list = FList.Cons("Flag", "Cup", "Cup", "Burg", "Cup", "Next");
            var sorted = MergeSort.SortAlphabetical(list);
            var expected = FList.Cons("Burg", "Cup", "Cup", "Cup", "Flag", "Next");
            Assert.AreEqual(expected, sorted);
        }

        [TestMethod]
        public void TestSortAlphabeticalWithOne()
        {
            var list = FList.Cons("Flag");
            var sorted = MergeSort.SortAlphabetical(list);
            var expected = FList.Cons("Flag");
            Assert.AreEqual(expected, sorted);
        }

        [TestMethod]
        public void TestSortAlphabeticalEmpty()
        {
            var list = FList.Empty<string>();
            var sorted = MergeSort.SortAlphabetical(list);
            var expected = FList.Empty<string>();
            Assert.AreEqual(expected, sorted);
        }

        [TestMethod]
        public void TestSortWithAlphabeticalFunction()
        {
            var list = FList.Cons("Flag", "Nest", "Cup", "Burg", "Yatch", "Next");
            var sorted = MergeSort.Sort(list, alphabetical);
            var expected = FList.Cons("Burg", "Cup", "Flag", "Nest", "Next", "Yatch");
            Assert.AreEqual(expected, sorted);
        }

        [TestMethod]
        public void TestSortWithReverseFunction()
        {
            var list = FList.Cons("Flag", "Nest", "Cup", "Burg", "Yatch", "Next");
            var sorted = MergeSort.Sort(list, reverse);
            var expected = FList.Cons("Yatch", "Next", "Nest", "Flag", "Cup","Burg");
            Assert.AreEqual(expected, sorted);
        }

        [TestMethod]
        public void TestSortByLengthDecreasing()
        {
            var list = FList.Cons("Flag", "Nest", "Cup", "Burg", "Yatch", "Next");
            var sorted = MergeSort.Sort(list, length);
            var expected = FList.Cons( "Cup", "Flag", "Nest", "Burg","Next", "Yatch");
            Assert.AreEqual(expected, sorted);
        }


        [TestMethod]
        public void TestSortIntegers()
        {
            var list = FList.Cons(4, 7, 12, 3, 88, 9, 2, 7);
            var sorted = MergeSort.Sort(list, greaterThan);
            var expected = FList.Cons(2,3,4,7,7,9,12,88);
            Assert.AreEqual(expected, sorted);
        }

        [TestMethod]
        public void TestSortIntegersInReverse()
        {
            var list = FList.Cons(4, 7, 12, 3, 88, 9, 2, 7);
            var sorted = MergeSort.Sort(list, reverse);
            var expected = FList.Cons(88,12,9,7,7,4,3,2);
            Assert.AreEqual(expected, sorted);
        }

        static bool alphabetical(string s1, string s2)
        {
            return string.Compare(s2, s1) > 0;
        }

        static bool reverse(string s1, string s2)
        {
            return string.Compare(s2, s1) < 0;
        }

        static bool length(string s1, string s2)
        {
            return s2.Length > s1.Length;
        }

        static bool greaterThan(int i1, int i2)
        {
            return i2 > i1;
        }

        static bool reverse(int i1, int i2)
        {
            return i1 > i2;
        }
    }
}

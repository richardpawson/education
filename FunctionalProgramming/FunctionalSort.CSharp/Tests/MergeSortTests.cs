using Microsoft.VisualStudio.TestTools.UnitTesting;
using FunctionalLibrary;
using System.Linq;
using System.Collections.Generic;

namespace Tests
{
    [TestClass]
    public class MergeSortTests
    {


[TestMethod]
public void TestSortWithAlphabeticalFunction()
{
    var list = FList.Cons("Flag", "Nest", "Cup", "Burg", "Yacht", "Next");
    var sorted = Sorting.MergeSort(list, alphabetical);
    var expected = FList.Cons("Burg", "Cup", "Flag", "Nest", "Next", "Yacht");
    Assert.AreEqual(expected, sorted);
}

[TestMethod]
public void TestSortWithAnonymousFunction()
{
    var list = FList.Cons("Flag", "Nest", "Cup", "Burg", "Yacht", "Next");
    var sorted = Sorting.MergeSort(list, (s1,s2) => s1.Last() < s2.Last()) ;
    var expected = FList.Cons("Flag", "Burg", "Cup", "Nest", "Yacht", "Next");
    Assert.AreEqual(expected, sorted);
}

        [TestMethod]
        public void TestSortWithReverseFunction()
        {
            var list = FList.Cons("Flag", "Nest", "Cup", "Burg", "Yacht", "Next");
            var sorted = Sorting.MergeSort(list, reverse);
            var expected = FList.Cons("Yacht", "Next", "Nest", "Flag", "Cup","Burg");
            Assert.AreEqual(expected, sorted);
        }

        [TestMethod]
        public void TestSortByLengthDecreasing()
        {
            var list = FList.Cons("Flag", "Nest", "Cup", "Burg", "Yacht", "Next");
            var sorted = Sorting.MergeSort(list, (s1, s2) => s2.Length > s1.Length);
            var expected = FList.Cons( "Cup", "Flag", "Nest", "Burg","Next", "Yacht");
            Assert.AreEqual(expected, sorted);
        }

        [TestMethod]
        public void TestSortByLengthDecreasingUsingLambda()
        {
            var list = FList.Cons("Flag", "Nest", "Cup", "Burg", " Yacht ", "Next");
            var sorted = Sorting.MergeSort(list, (s1, s2) => s2.Length > s1.Length);
            var expected = FList.Cons("Cup", "Flag", "Nest", "Burg", "Next", " Yacht ");
            Assert.AreEqual(expected, sorted);
        }


        [TestMethod]
        public void TestSortIntegers()
        {
            var list = FList.Cons(4, 7, 12, 3, 88, 9, 2, 7);
            var sorted = Sorting.MergeSort(list, greaterThan);
            var expected = FList.Cons(2,3,4,7,7,9,12,88);
            Assert.AreEqual(expected, sorted);
        }

        [TestMethod]
        public void TestSortIntegersInReverse()
        {
            var list = FList.Cons(4, 7, 12, 3, 88, 9, 2, 7);
            var sorted = Sorting.MergeSort(list, reverse);
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

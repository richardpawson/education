using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class UnitTests
{
    [TestMethod]
    public void Test_2ContainsRoot()
    {
        var bst = new BinarySearchTree("Monkey");
        Assert.IsTrue(bst.Contains("Monkey"));
    }

    [TestMethod]
    public void Test_3ContainsFalse()
    {
        var bst = new BinarySearchTree("Monkey");
        Assert.IsFalse(bst.Contains("Aardvark"));
    }

    [TestMethod]
    public void Test_4AddMultiple()
    {
        var bst = new BinarySearchTree("Monkey");
          bst.Add("Topi");
        bst.Add("Zebra");
        Assert.IsTrue(bst.Contains("Monkey"));
        Assert.IsTrue(bst.Contains("Topi"));
        Assert.IsTrue(bst.Contains("Zebra"));
        Assert.IsFalse(bst.Contains("Aardvark"));
    }

    [TestMethod]
    public void Test_5TraverseBreadthFirst()
    {
        var bst = new BinarySearchTree("Monkey");
        bst.Add("Cow");
        bst.Add("Aardvark");
        bst.Add("Topi");
        bst.Add("Zebra");
        var actual = bst.TraverseBreadthFirst();
        var expected = new List<string> { "Monkey", "Cow", "Topi", "Aardvark", "Zebra" };
        CollectionAssert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Test_6AddingInDifferentOrderResultsInDifferentStructure()
    {
        var bst = new BinarySearchTree("Monkey");
        bst.Add("Aardvark");
        bst.Add("Zebra");
        bst.Add("Topi");
        bst.Add("Cow");
        var actual = bst.TraverseBreadthFirst();
        var expected = new List<string> { "Monkey",  "Aardvark", "Zebra", "Cow", "Topi", };
        CollectionAssert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Test_7TraverseDepthFirstPreOrder()
    {
        var bst = new BinarySearchTree("Monkey");
        bst.Add("Cow");
        bst.Add("Aardvark");
        bst.Add("Topi");
        bst.Add("Zebra");
        var actual = bst.TraverseDepthFirstPreOrder();
        var expected = new List<string> { "Monkey", "Cow",  "Aardvark", "Topi", "Zebra" };
        CollectionAssert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Test_8TraverseDepthFirstInOrder()
    {
        var bst = new BinarySearchTree("Monkey");
        bst.Add("Cow");
        bst.Add("Aardvark");
        bst.Add("Topi");
        bst.Add("Zebra");
        var actual = bst.TraverseDepthFirstInOrder();
        var expected = new List<string> {"Aardvark", "Cow", "Monkey", "Topi", "Zebra" };
        CollectionAssert.AreEqual(expected, actual);
    }
    [TestMethod]
    public void Test_9TraverseDepthFirstPostOrder()
    {
        var bst = new BinarySearchTree("Monkey");
        bst.Add("Cow");
        bst.Add("Aardvark");
        bst.Add("Topi");
        bst.Add("Zebra");
        var actual = bst.TraverseDepthFirstPostOrder();
        var expected = new List<string> { "Aardvark", "Cow", "Zebra", "Topi","Monkey" };
        CollectionAssert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Test10Remove()
    {
        var bst = new BinarySearchTree("Monkey");
        bst.Add("Cow");
        bst.Add("Aardvark");
        bst.Add("Topi");
        bst.Add("Zebra");
        bst.Remove("Cow");
        var actual = bst.TraverseBreadthFirst();
        var expected =  new List<string> { "Monkey", "Aardvark", "Topi",  "Zebra" };
        CollectionAssert.AreEqual(expected, actual);
    }
    [TestMethod]
    public void Test11RemoveRoot()
    {
        var bst = new BinarySearchTree("Monkey");
        bst.Add("Cow");
        bst.Add("Aardvark");
        bst.Add("Topi");
        bst.Add("Zebra");
        bst.Remove("Monkey");
        var actual = bst.TraverseBreadthFirst();
        var expected = new List<string> {"Zebra", "Topi", "Aardvark","Cow" };
        CollectionAssert.AreEqual(expected, actual);
    }
}


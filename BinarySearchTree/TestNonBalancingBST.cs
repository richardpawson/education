using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class TestNonBalancingBST
{
    [TestMethod]
    public void Test_1ConstructorAndToString()
    {
        var bst = new NonBalancingBST ("Monkey");
        Assert.AreEqual("Monkey", bst.ToString());
    }

    [TestMethod]
    public void Test_2ContainsRoot()
    {
        var bst = new NonBalancingBST ("Monkey");
        Assert.IsTrue(bst.Contains("Monkey"));
    }

    [TestMethod]
    public void Test_3ContainsFalse()
    {
        var bst = new NonBalancingBST ("Monkey");
        Assert.IsFalse(bst.Contains("Aardvark"));
    }

    [TestMethod]
    public void Test_4AddMultiple()
    {
        var bst = new NonBalancingBST ("Monkey");
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
        var bst = new NonBalancingBST ("Monkey");
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
        var bst = new NonBalancingBST ("Monkey");
        bst.Add("Aardvark");
        bst.Add("Zebra");
        bst.Add("Topi");
        bst.Add("Cow");
        var actual = bst.TraverseBreadthFirst();
        var expected = new List<string> { "Monkey", "Aardvark", "Zebra", "Cow", "Topi", };
        CollectionAssert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Test_7TraverseDepthFirstPreOrder()
    {
        var bst = new NonBalancingBST ("Monkey");
        bst.Add("Cow");
        bst.Add("Aardvark");
        bst.Add("Topi");
        bst.Add("Zebra");
        var actual = bst.TraverseDepthFirstPreOrder();
        var expected = new List<string> { "Monkey", "Cow", "Aardvark", "Topi", "Zebra" };
        CollectionAssert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Test_8TraverseDepthFirstInOrder()
    {
        var bst = new NonBalancingBST ("Monkey");
        bst.Add("Cow");
        bst.Add("Aardvark");
        bst.Add("Topi");
        bst.Add("Zebra");
        var actual = bst.TraverseDepthFirstInOrder();
        var expected = new List<string> { "Aardvark", "Cow", "Monkey", "Topi", "Zebra" };
        CollectionAssert.AreEqual(expected, actual);
    }
    [TestMethod]
    public void Test_9TraverseDepthFirstPostOrder()
    {
        var bst = new NonBalancingBST ("Monkey");
        bst.Add("Cow");
        bst.Add("Aardvark");
        bst.Add("Topi");
        bst.Add("Zebra");
        var actual = bst.TraverseDepthFirstPostOrder();
        var expected = new List<string> { "Aardvark", "Cow", "Zebra", "Topi", "Monkey" };
        CollectionAssert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Test10Remove()
    {
        var bst = new NonBalancingBST ("Monkey");
        bst.Add("Cow");
        bst.Add("Aardvark");
        bst.Add("Topi");
        bst.Add("Zebra");
        bst.Remove("Cow");
        var actual = bst.TraverseBreadthFirst();
        var expected = new List<string> { "Monkey", "Aardvark", "Topi", "Zebra" };
        CollectionAssert.AreEqual(expected, actual);
    }
    [TestMethod]
    public void Test11RemoveRoot()
    {
        var bst = new NonBalancingBST ("Monkey");
        bst.Add("Cow");
        bst.Add("Aardvark");
        bst.Add("Topi");
        bst.Add("Zebra");
        bst.Remove("Monkey");
        var actual = bst.TraverseBreadthFirst();
        var expected = new List<string> { "Zebra", "Topi", "Aardvark", "Cow" };
        CollectionAssert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Test_12Summary()
    {
        var bst = new NonBalancingBST ("Monkey");
        bst.Add("Elephant");
        bst.Add("Aardvark");
        bst.Add("Horse");
        bst.Add("Zebra");
        Assert.AreEqual("Monkey\n  L:Elephant\n    L:Aardvark\n    R:Horse\n  R:Zebra\n", bst.Summary());
    }
    [TestMethod]
    public void Test_13DepthAndBalance()
    {
        var bst = new NonBalancingBST ("Monkey");
        Assert.AreEqual(1, bst.Depth);
        Assert.AreEqual(0, bst.Balance());
        bst.Add("Elephant");
        Assert.AreEqual(2, bst.Depth);
        Assert.AreEqual(-1, bst.Balance());
        bst.Add("Aardvark");
        Assert.AreEqual(3, bst.Depth);
        Assert.AreEqual(-2, bst.Balance());
        bst.Add("Horse");
        Assert.AreEqual(-2, bst.Balance());
        Assert.AreEqual(3, bst.Depth);
        bst.Add("Zebra");
        Assert.AreEqual(3, bst.Depth);
        Assert.AreEqual(-1, bst.Balance());
        Assert.AreEqual("Monkey\n  L:Elephant\n    L:Aardvark\n    R:Horse\n  R:Zebra\n", bst.Summary());
    }
}


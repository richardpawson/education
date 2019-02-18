using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class TestSelfBalancingBST { 
    [TestMethod]
    public void Test_1ConstructorAndToString()
    {
        var bst = new SelfBalancingBST("Monkey");
        Assert.AreEqual("Monkey", bst.ToString());
    }

    [TestMethod]
    public void Test_2ContainsRoot()
    {
        var bst = new SelfBalancingBST("Monkey");
        Assert.IsTrue(bst.Contains("Monkey"));
    }

    [TestMethod]
    public void Test_3ContainsFalse()
    {
        var bst = new SelfBalancingBST("Monkey");
        Assert.IsFalse(bst.Contains("Aardvark"));
    }

    [TestMethod]
    public void Test_4AddMultiple()
    {
        var bst = new SelfBalancingBST("Monkey");
        bst.Add("Topi");
        bst.Add("Zebra");
        Assert.IsTrue(bst.Contains("Monkey"));
        Assert.IsTrue(bst.Contains("Topi"));
        Assert.IsTrue(bst.Contains("Zebra"));
        Assert.IsFalse(bst.Contains("Aardvark"));
    }


    [TestMethod]
    public void Test_6AddingInDifferentOrderResultsInDifferentStructure()
    {
        var bst = new SelfBalancingBST("Monkey");
        bst.Add("Aardvark");
        bst.Add("Zebra");
        bst.Add("Topi");
        bst.Add("Cow");
        var actual = bst.TraverseBreadthFirst();
        var expected = new List<string> { "Monkey", "Aardvark", "Zebra", "Cow", "Topi", };
        CollectionAssert.AreEqual(expected, actual);
    }

  
    [TestMethod]
    public void Test10Remove()
    {
        var bst = new SelfBalancingBST("Monkey");
        bst.Add("Cow");
        bst.Add("Aardvark");
        bst.Add("Topi");
        bst.Add("Zebra");
        bst.Remove("Cow");
        var actual = bst.TraverseBreadthFirst();
        var expected = new List<string> { "Topi", "Monkey", "Zebra", "Aardvark" };
        CollectionAssert.AreEqual(expected, actual);
    }
    [TestMethod]
    public void Test11RemoveRoot()
    {
        var bst = new SelfBalancingBST("Monkey");
        bst.Add("Cow");
        bst.Add("Aardvark");
        bst.Add("Topi");
        bst.Add("Zebra");
        bst.Remove("Monkey");
        var actual = bst.TraverseBreadthFirst();
        var expected = new List<string> { "Cow", "Aardvark", "Topi", "Zebra"};
        CollectionAssert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Test_12Summary()
    {
        var bst = new SelfBalancingBST("Monkey");
        bst.Add("Elephant");
        bst.Add("Aardvark");
        bst.Add("Horse");
        bst.Add("Zebra");
        Assert.AreEqual("Elephant\n  L:Aardvark\n  R:Monkey\n    L:Horse\n    R:Zebra\n", bst.Summary());
    }
    [TestMethod]
    public void Test_13DepthAndBalance()
    {
        var bst = new SelfBalancingBST("Monkey");
        Assert.AreEqual(1, bst.Depth);
        Assert.AreEqual(0, bst.Balance());
        bst.Add("Elephant");
        Assert.AreEqual(2, bst.Depth);
        Assert.AreEqual(-1, bst.Balance());
        bst.Add("Aardvark");
        Assert.AreEqual(2, bst.Depth);
        Assert.AreEqual(0, bst.Balance());
        bst.Add("Horse");
        Assert.AreEqual(1, bst.Balance());
        Assert.AreEqual(3, bst.Depth);
        bst.Add("Zebra");
        Assert.AreEqual(3, bst.Depth);
        Assert.AreEqual(1, bst.Balance());
    }
}


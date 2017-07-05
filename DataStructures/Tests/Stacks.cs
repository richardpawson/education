using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections;

namespace DataStructures
{
    [TestClass]
    public class StackTests
    {
        [TestMethod]
        public void ReadyMadeStack()
        {
            var q = new System.Collections.Stack(5); //Initial capacity
            q.Push("Pear");
            q.Push("Cherry");
            q.Push(3.141);  //Stack takes any type of object
            q.Push("Apple");
            q.Push("Raspberry");
            Assert.AreEqual(5, q.Count);
            Assert.AreEqual("Raspberry", q.Pop());
            Assert.AreEqual(4, q.Count);
            q.Push("Lemon");
            q.Push("Lime"); //Stack dynamically expands capacity
            Assert.AreEqual(6, q.Count);
            Assert.AreEqual("Lime", q.Peek());
            Assert.AreEqual(6, q.Count); //Peek does not remove item
            for (int i = 0; i < 6; i++) //Now remove all items
            {
                q.Pop();
            }
            Assert.AreEqual(0, q.Count);
            try
            {
                q.Pop();
                Assert.Fail(); //Should not get here!
            }
            catch (InvalidOperationException e)
            {
                Assert.AreEqual("Stack empty.", e.Message);
            }
        }

        [TestMethod]
        public void CustomStack()
        {
            var q = new Stack(5);
            q.Push("Pear");
            q.Push("Cherry");
            q.Push(3.141);  //Stack takes any type of object
            q.Push("Apple");
            q.Push("Raspberry");
            Assert.AreEqual(5, q.Count);
            Assert.AreEqual("Raspberry", q.Pop());
            Assert.AreEqual(4, q.Count);
            q.Push("Lemon");
            //Test exception thrown if attempt to exceed size
            try
            {
                q.Push("Lime");
                Assert.Fail("Should not get here!"); 
            }
            catch (InvalidOperationException e)
            {

                Assert.AreEqual("Stack full.", e.Message);
                Assert.AreEqual(5, q.Count);
            }
            Assert.AreEqual("Lemon", q.Peek());
            Assert.AreEqual(5, q.Count); //Peek does not remove item
            for (int i = 0; i < 5; i++) //Now remove all items
            {
                q.Pop();
            }
            Assert.AreEqual(0, q.Count);
            try
            {
                q.Pop();
                Assert.Fail("Should not get here!");
            }
            catch (InvalidOperationException e)
            {
                Assert.AreEqual("Stack empty.", e.Message);
            }
        }
    }
}

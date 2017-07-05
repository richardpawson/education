using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections;

namespace DataStructures
{
    [TestClass]
    public class QueueTests
    {
        [TestMethod]
        public void ReadyMadeQueue()
        {
            var q = new Queue(5); //Initial capacity
            q.Enqueue("Pear");
            q.Enqueue("Cherry");
            q.Enqueue(3.141);  //Queue takes any type of object
            q.Enqueue("Apple");
            q.Enqueue("Raspberry");
            Assert.AreEqual(5, q.Count);
            Assert.AreEqual("Pear", q.Dequeue());
            Assert.AreEqual(4, q.Count);
            q.Enqueue("Lemon");
            q.Enqueue("Lime"); //Queue dynamically expands capacity
            Assert.AreEqual(6, q.Count);
            Assert.AreEqual("Cherry", q.Peek());
            Assert.AreEqual(6, q.Count); //Peek does not remove item
            for (int i = 0; i < 6; i++) //Now remove all items
            {
                q.Dequeue();
            }
            Assert.AreEqual(0, q.Count);
            try
            {
                q.Dequeue();
                Assert.Fail(); //Should not get here!
            }
            catch (InvalidOperationException)
            {
                // Test passes if correct exception thrown
            }
        }

        [TestMethod]
        public void CustomLinearQueue()
        {
            var q = new LinearQueue(5);
            q.Enqueue("Pear");
            q.Enqueue("Cherry");
            q.Enqueue(3.141);  //Queue takes any type of object
            q.Enqueue("Apple");
            q.Enqueue("Raspberry");
            Assert.AreEqual(5, q.Count);
            //Try exceeding size
            try
            {
                q.Enqueue("Papaya");
                Assert.Fail(); //Should not get here
            }
            catch (Exception e)
            {
                Assert.AreEqual("Queue full.", e.Message);
            }
            Assert.AreEqual("Pear", q.Dequeue());
            Assert.AreEqual(4, q.Count);
            //Now show that the linear queue has been 'used up'
            try
            {
                q.Enqueue("Banana");
                Assert.Fail(); //Should not get here!
            }
            catch (InvalidOperationException)
            {
                // Test passes if correct exception thrown
            }

            for (int i = 0; i < 4; i++) //Now remove all items
            {
                q.Dequeue();
            }
            Assert.AreEqual(0, q.Count);
            try
            {
                q.Dequeue();
                Assert.Fail(); //Should not get here!
            }
            catch (InvalidOperationException e)
            {
                Assert.AreEqual("Queue empty.", e.Message);
            }
        }

        [TestMethod]
        public void CustomCircularQueue()
        {
            var q = new CircularQueue(5);
            q.Enqueue("Pear");
            q.Enqueue("Cherry");
            q.Enqueue(3.141);  //Queue takes any type of object
            q.Enqueue("Apple");
            q.Enqueue("Raspberry");
            Assert.AreEqual(5, q.Count);
            Assert.AreEqual("Pear", q.Dequeue());
            Assert.AreEqual(4, q.Count);
            q.Enqueue("Banana");
            Assert.AreEqual(5, q.Count);
            //Try exceeding size
            try
            {
                q.Enqueue("Papaya");
                Assert.Fail("Should not get here!");
            }
            catch (Exception e)
            {
                Assert.AreEqual("Queue full.", e.Message);
            }
            for (int i = 0; i < 5; i++) //Now remove all items
            {
                q.Dequeue();
            }
            Assert.AreEqual(0, q.Count);
            try
            {
                q.Dequeue();
                Assert.Fail("Should not get here!");
            }
            catch (InvalidOperationException e)
            {
                Assert.AreEqual("Queue empty.", e.Message);
            }
        }
    }
}

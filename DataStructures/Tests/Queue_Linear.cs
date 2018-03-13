using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections;

namespace DataStructures
{
    [TestClass]
    public class Linear_Circular_Tests
    {
        [TestMethod]
        public void EnqueueMixedTypesOfObject()
        {
            var q = new LinearQueue(5);
            q.Enqueue("Pear");
            q.Enqueue("Cherry");
            q.Enqueue(3.141);  //Queue takes any type of object
        }

        [TestMethod]
        public void EnqueueToCapacity()
        {
            var q = new LinearQueue(5);
            q.Enqueue("Pear");
            q.Enqueue("Cherry");
            q.Enqueue("Apple");
            q.Enqueue("Raspberry");
            q.Enqueue("Banana");
        }

        [TestMethod]
        public void Count()
        {
            var q = new LinearQueue(5);
            q.Enqueue("Pear");
            q.Enqueue("Cherry");
            Assert.AreEqual(2, q.Count);
            q.Enqueue("Apple");
            q.Enqueue("Raspberry");
            Assert.AreEqual(4, q.Count);
        }

        [TestMethod]
        public void Dequeue()
        {
            var q = new LinearQueue(5);
            q.Enqueue("Pear");
            q.Enqueue("Cherry");
            q.Enqueue("Apple");
            q.Enqueue("Raspberry");
            Assert.AreEqual(4, q.Count);
            Assert.AreEqual("Pear", q.Dequeue());
            Assert.AreEqual(3, q.Count);
            Assert.AreEqual("Cherry", q.Dequeue());
            Assert.AreEqual(2, q.Count);
        }

        [TestMethod]
        public void Peek()
        {
            var q = new LinearQueue(5);
            q.Enqueue("Pear");
            q.Enqueue("Cherry");
            Assert.AreEqual("Pear", q.Peek());
            Assert.AreEqual("Pear", q.Peek());  //i.e. first Peek does not change the queue
            q.Dequeue();
            Assert.AreEqual("Cherry", q.Peek());
        }

        [TestMethod]
        public void SizeExceeded()
        {
            var q = new LinearQueue(3);
            q.Enqueue("Pear");
            q.Enqueue("Cherry");
            q.Enqueue("Apple");
            try
            {
                q.Enqueue("Papaya");
                Assert.Fail("Should not get here!");
            }
            catch (InvalidOperationException e)
            {
                Assert.AreEqual("Queue full", e.Message);
            }
        }


        [TestMethod]
        public void IsEmptyAtStart()
        {
            var q = new LinearQueue(3);
            Assert.IsTrue(q.IsEmpty());
        }

        [TestMethod]
        public void ReturnsToIsEmpty()
        {
            var q = new LinearQueue(3);
            q.Enqueue("Pear");
            Assert.IsFalse(q.IsEmpty());
            q.Dequeue();
            Assert.IsTrue(q.IsEmpty());
        }

        [TestMethod]
        public void CannotDequeueAnEmptyQueue()
        {
            var q = new LinearQueue(3);
            try
            {
                q.Dequeue();
                Assert.Fail("Expected exception was not thrown");
            }
            catch (InvalidOperationException e)
            {
                Assert.AreEqual("Queue empty", e.Message);
            }
        }

        [TestMethod]
        public void CannotPeekAnEmptyQueue()
        {
            var q = new LinearQueue(3);
            try
            {
                q.Peek();
                Assert.Fail("Expected exception was not thrown");
            }
            catch (InvalidOperationException e)
            {
                Assert.AreEqual("Queue empty", e.Message);
            }
        }

        [TestMethod]
        public void FillUpAfterRepeatedEnqueueDequeue()
        {
            var q = new LinearQueue(3);
            q.Enqueue("Pear");
            q.Enqueue("Cherry");
            Assert.AreEqual("Pear", q.Dequeue());
            q.Enqueue("Apple");
            Assert.AreEqual("Cherry", q.Dequeue());
            Assert.AreEqual(1, q.Count);
            try
            {
                q.Enqueue("Orange");
                Assert.Fail("Expected exception was not thrown");
            }
            catch (InvalidOperationException e)
            {
                Assert.AreEqual("Queue full", e.Message);
            }
        }

    }
}

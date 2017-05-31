using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections;

namespace DataStructures
{
    [TestClass]
    public class Queues
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
            var q = new MyLinearQueue(5);
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
            var q = new MyCircularQueue(5);
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

    public class MyLinearQueue
    {
        private object[] elements;
        private int front;
        private int rear;
        public int Count { get; private set; }

        public MyLinearQueue(int size)
        {
            elements = new object[size];
            front = rear = -1;
            Count = 0;
        }

        public void Enqueue(object obj)
        {
            if (front == -1 && rear == -1)
            {
                front = rear = 0;
            }
            else
            {
                if (rear + 1 >=  elements.Length)
                {
                    throw new InvalidOperationException("Queue full.");
                }
                else
                {
                    rear += 1;
                }
            }
            elements[rear] = obj;
            Count += 1;
        }

        public object Dequeue()
        {
            object item = null;
            if (front == -1 && rear == -1)
            {
                throw new InvalidOperationException("Queue empty.");
            }
            else
            {
                item = elements[front];
                if (front == rear)
                {
                    front = rear = -1;
                }
                else
                {
                    front += 1;
                }
            }
            Count -= 1;
            return item;
        }
    }

    public class MyCircularQueue
    {
        private int size;
        private object[] elements;
        private int front;
        private int rear;
        public int Count { get; private set; }

        public MyCircularQueue(int size)
        {
            this.size = size;
            elements = new object[size];
            front = rear = -1;
            Count = 0;
        }

        public void Enqueue(object obj)
        {
            if (front == -1 && rear == -1)
            {
                front = rear = 0;
            }
            else
            {
                if ((rear + 1) % size == front)
                {
                    throw new InvalidOperationException("Queue full.");
                }
                else
                {
                    rear = (rear + 1) % size;
                }
            }
            elements[rear] = obj;
            Count += 1;
        }

        public object Dequeue()
        {
            object item = null;
            if (front == -1 && rear == -1)
            {
                throw new InvalidOperationException("Queue empty.");
            }
            else
            {
                item = elements[front];
                if (front == rear)
                {
                    front = rear = -1;
                }
                else
                {
                    front = (front + 1) % size;
                }
            }
            Count -= 1;
            return item;
        }
    }

}

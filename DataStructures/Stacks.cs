using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections;

namespace DataStructures
{
    [TestClass]
    public class Stacks
    {
        [TestMethod]
        public void ReadyMadeStack()
        {
            var q = new Stack(5); //Initial capacity
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
            var q = new MyStack(5);
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


    public class MyStack
    {
        private int size;
        private object[] elements;
        private int pointer;

        public MyStack(int size)
        {
            this.size = size;
            elements = new object[size];
            pointer = -1;
        }

        public int Count
        {
            get
            {
                return pointer + 1;
            }
        }

        public void Push(object obj)
        {
            if (pointer +1 < size)
            {
                pointer += 1;
                elements[pointer] = obj;
            } else
            {
                throw new InvalidOperationException("Stack full.");
            }
        }

        public object Pop()
        {
            if (pointer == -1)
            {
                throw new InvalidOperationException("Stack empty.");
            }
            else
            {
                object item = elements[pointer];
                pointer -= 1;
                return item;
            }
        }

        public object Peek()
        {
            if (pointer == -1)
            {
                throw new InvalidOperationException("Stack empty.");
            } else
            {
                return elements[pointer];
            }
        }
    }
  

   

}

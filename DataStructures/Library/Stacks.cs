using System;

namespace DataStructures
{
    public class Stack
    {
        private int size;
        private object[] elements;
        private int pointer;

        public Stack(int size)
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

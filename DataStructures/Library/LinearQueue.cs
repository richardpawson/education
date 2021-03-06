﻿using System;

namespace DataStructures
{ 
    public class LinearQueue
    {
        private object[] elements;
        private int front;
        private int rear;
        public int Count { get; private set; }

        public LinearQueue(int size)
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
                    throw new InvalidOperationException("Queue full");
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
                throw new InvalidOperationException("Queue empty");
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

        public object Peek()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Queue empty");
            }
            return elements[front];
        }

        public bool IsEmpty()
        {
            return front == -1 && rear == -1;
        }
    }
}

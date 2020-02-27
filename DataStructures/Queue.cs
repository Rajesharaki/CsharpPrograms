using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructurePrograms
{
    class Queue<T>
    {
        int Rear;
        int Front;
        T[] Array;
        int size;

        //Empty queue
        public Queue(int Capacity)
        {
            Array = new T[Capacity];
        }

        //Adds new items to the rear of the queue
        public void Enqueue(T Item)
        {
            if (Rear == Array.Length)
            {
                Console.WriteLine("Queue Over Flow");
                return;
            }
            Array[Rear++] = Item;
            size++;
        }

        //Removes the front item from the queue
        public T Dequeue()
        {
            if (Front == -1)
            {
                Console.WriteLine("Queue Under Flow...");
                return (T)default;
            }
            T data = Array[Front++];
            size--;
            return data;
        }

        //returns the number of items in the queue
        public int Size()
        {
            return size;
        }

        //tests to see whether the queue is empty
        public bool IsEmpty()
        {
            if (Rear - 1 == -1)
            {
                return true;
            }
            return false;
        }

        //Override tostring method
        public override String ToString()
        {
            String St = "{";
            for (int i = Front; i < Rear; i++)
            {
                St += Array[i];
                if (i < Rear - 1)
                {
                    St += ",";
                }
            }
            St += "}";
            return St;
        }
    }
}

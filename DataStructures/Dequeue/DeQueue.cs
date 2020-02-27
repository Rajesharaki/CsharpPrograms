using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructurePrograms
{
    class DeQueue<T>
    {
        int Rear = -1, Front = -1, size = 0;
        T[] Array;

        //Creates a new Dequeue that is empty
        public DeQueue(int Capacity)
        {
            Array = new T[Capacity];
        }

        //Adds a new Item to thr Rear of the Dequeue
        public void AddRear(T Item)
        {
            if (Rear == Array.Length - 1)  //If Rear is More than Queue Size 
            {
                Console.WriteLine("Queue is OverFlow.....");
                return;
            }
            else
            {
                size++;
                Array[++Rear] = Item;  //Item adds at the Rear
                if (Front == -1)
                {
                    Front++;
                }
            }
        }

        //Removes the Front item from the Dequeue 
        public T RemoveFront()
        {
            if (Front == -1) //If there is No Item inside the queue
            {
                Console.WriteLine("Queue is Underflow...");
                return (T)default;
            }
            else if (Front == Rear) //If There is only one element inside the queue
            {
                Console.WriteLine("List is Empty");
                T Item = Array[Front];
                Front = -1;
                Rear = -1;
                size--;
                return Item;
            }
            else
            {
                T Item = Array[Front++];size--;
                return Item;
            }
        }

        //Adds new  items to the Front of the Dequeue
        public void AddFront(T Item)
        {
            if (Front == -1)
            {
                Array[++Front] = Item;
                Rear++;size++; 
                return;
            }
            else if (Front == 0)
            {
                Console.WriteLine("Queue is UnderFlow...");
                return;
            }
            else
            {
                Array[--Front] = Item;size++;
            }
        }

        //Remove the Rear item from the Dequeue
        public T RemoveRear()
        {
            if (Rear == -1)
            {
                Console.WriteLine("Queue is Empty....");
                return (T) default;
            }
            else if (Front == Rear)
            {
                T Data = Array[Rear];
                Front = -1;
                Rear = -1;size--;
                return Data;
            }
            else
            {
                T Data = Array[Rear--];size--;
                return Data;
            }
        }

        //Check queue is empty
        public bool IsEmpty()
        {
            if (Rear == -1 && Front == -1)
            {
                return true;
            }
            return false;
        }

        //Size of an Queue
        public int Size()
        {
            return size;
        }
        //Override the ToString Method
        public override String ToString()
        {
            String st = "{";
            if (Front > -1)
            {
                for (int i = Front; i <= Rear; i++)
                {
                    st += Array[i];
                    if (i <= Rear - 1)
                    {
                        st += ",";
                    }
                }
            }
            st += "}";
            return st;
        }
    }
}

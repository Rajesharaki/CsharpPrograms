using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructurePrograms
{
    class OrderedList
    {
        class Node
        {
           public Node Next;
           public Node Prev;
           public  int data;
                public Node( int data)
                {
                 
                this.data = data;
                }
        }
        Node head;
        //Add method in Ascending order
        public void Add(int data)
        {
            Node n = new Node(data);
            if (head == null)
            {
                head = n;
                return;
            }
            Node t = head;
            while (t.Next != null)
            {
                t = t.Next;
            }
            t.Next = n;
            n.Prev = t;
            Node p = head, q = p.Next;
            //Bubble Sort
          for(Node i = head; i.Next!=null; i=i.Next)
            {
                for(Node j = i.Next; j!=null; j=j.Next)
                {
                    if (i.data > j.data)
                    {
                        int temp = i.data;
                        i.data = j.data;
                        j.data = temp;
                    }
                }
            }
        }
        //Remove Method
        public void Remove(int data)
        {
            Node t = head;
            if (head == null)
            {
                throw new NullReferenceException("List is Empty.....");
            }
            if (head.Prev == null)
            {
                if (t.data == data)
                {
                    head = head.Next;
                    return;
                }
            }
            Node p = t;
            while (t != null)
            {
                if (t.Next == null)
                {
                    p.Next = null;
                    return;
                }
                if (t.data == data)
                {
                    p.Next = t.Next;
                    t.Next.Prev = p;
                    return;
                }
                p = t;
                t = t.Next;
            }
        }
        //Override ToString Method
        public override String ToString()
        {
            string st = "[";Node t = head;
            while (t != null)
            {
                st += t.data;
                if (t.Next != null)
                {
                    st += ",";
                }
                t = t.Next;
            }
            st += "]";
            return st;
        }
        //Search method
        public bool Search(int data)
        {
            Node t = head;
            while (t != null)
            {
                if (t.data == data)
                {
                    return true;
                }
                t = t.Next;
            }
            return false;
        }
        //Check list is Empty or not
        public bool IsEmpty()
        {
            return head == null;
        }
        //List Size Method
        public int Size()
        {
            int Count = 0;Node t = head;
            while (t != null)
            {
                Count++;
                t = t.Next;
            }
            return Count;
        }
        //Item index
        public int Index(int data)
        {
            int Count = 0;Node t = head;
            while (t != null)
            {
                if (t.data == data)
                {
                    return Count;
                }
                Count++;t = t.Next;
            }
            return -1;
        }
        //Remoove and Return the Last Item
        public int Pop()
        {
            Node t = head, p = t;
            while (t.Next != null)
            {
                p = t;
                t = t.Next;
            }
           int data= t.data;
            p.Next = null;
            return data;
        }
        //Remove And Return Element Based on Position
        public int Pop(int Position)
        {
            if (Position == 0)
            {
                int data = head.data;
                head = head.Next;
                return data;
            }
            Node t = head,p=t;int Count = 0;
            while (t != null)
            {
                if (t.Next == null)
                {
                    if (Position == Count)
                    {
                        int data = t.data;
                        p.Next = null;
                        return data;
                    }
                }
                if (Position == Count)
                {
                    int data = t.data;
                    p.Next = t.Next;
                    t.Next.Prev = p;
                    return data;
                }
                p = t;
                t = t.Next;Count++;
            }
            return -1;
        }
        public int Peek(int Position)
        {
            Node t = head;
            int count = 0;
            while (t != null)
            {
                if (Position == count)
                {
                    return t.data;
                }
                count++;
                t = t.Next;
            }
            return -1;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructurePrograms
{
     public class UnOrderedList<T>
    {
         public class Node
        {
            public Node Next; 
            public Node Prev; 
            public  T data;
            public Node(T data)
            {
                this.data = data;
            }
        }
        static Node head;
        //Add element in the list 
        public void Add(T data)
        {
            Node n = new Node(data);
            if(head == null)
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
        }
        //Element add in first 
        public void AddFirst(T data)
        {
            Node n = new Node(data);
            n.data = data;
            n.Next = head;
            head.Prev = n;
            head = n;

        }
        //Remove the element based on given data
        public void Remove(T data)
        {
            Node t = head, p = t;
            if (head.Prev == null)
            {
                if (t.data.Equals(data))
                {
                    head = head.Next;
                    head.Prev = null;
                    return;
                }
            }

            while (t != null)
            {
                if (t.Next == null)
                {
                    p.Next = null;
                    return;
                }
                if (t.data.Equals(data))
                {
                    p.Next = t.Next;
                    t.Next.Prev = null;
                    return;
                }
                p = t;
                t = t.Next;
            }
        }
        //Searching element and return boolean values
        public bool Search(T data)
        {
            Node t = head;
            while (t != null)
            {
                if (t.data.Equals(data))
                {
                    return true;
                }
                t = t.Next;
            }
            return false;
        }
        //override Tostring method
        public override string ToString()
        {
            Node t = head;
            string st = "[";
            while (t != null)
            {
                st += t.data;
                if (t.Next != null)
                {
                    st += ",";
                }
                t = t.Next;
            }
            return st += "]";
        }
        //Size of list
        public int Size()
        {
            Node t = head;
            int count = 1;
            while (t != null)
            {
                count++;
                t = t.Next;
            }
            return count;
        }
        //Element index
        public int Index(T data)
        {
            int count=-1;
            Node t = head;
            while (t != null)
            {
                count++;
                if (t.data.Equals(data))
                {
                    return count;
                }
                t = t.Next;
            }
            return -1;
        }
        // element add at the end
        public void Append(T data)
        {
            Node t = head;
            Node n = new Node(data);
            while (t.Next != null)
            {
                t = t.Next;
            }
            t.Next = n;
            n.Prev = t;
        }
        //Element add based on position
        public void Insert(int Position,T data)
        {
            if (Position == 0)
            {
                AddFirst(data);
            }
            Node t = head;
            int Count = 1;
            while (t != null)
            {
                if (Count == Position)
                {
                    Node n = new Node(data);
                    n.Prev = t;
                    n.Next = t.Next;
                    t.Next = n;
                }
                Count++;
                t = t.Next;
            }

        }
        //Remove the Element
        public T Pop()
        {
            Node t = head, p = t;
            while (t.Next != null)
            {
                p = t;
                t = t.Next;
            }
            T data = t.data;
            p.Next = null;
            return data;
        }
        // remove the element based on position
        public T Pop(int Position)
        {
            if (Position == 0)
            {
                T data = head.data;
                head = head.Next;
                return data;
            }
            Node t = head, P = t;
            int Count = 0;
            while (t != null)
            {
                if (Count == Position)
                {
                    T data = t.data;
                    P.Next = t.Next;
                    t.Next.Prev = P;
                    return data;
                }
                Count++;
                P = t;
                t = t.Next;
            }
            return (T)default;
        }
        //Check List is Empty
        public bool IsEmpty()
        {
          return  head == null;
        }
        //Peek the Element
        public T Peek(int Position)
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
            return (T)default;
        }
    }
}


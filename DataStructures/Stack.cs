using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructurePrograms
{
    class Stack<T>
    {
        T[] a;
        static int top=-1;
        public Stack(int Size)
        {
            a = new T[Size];
        }
        //push The Element into  a Stack
        public void Push(T data)
        {
            a[++top] = data;
        }

        //Pop the element
        public T Pop()
        {
            T data = a[top];
            a[top] = (T)default;
            top--;
            return data;
        }

        //Peek the last element
        public T Peek()
        {
            T data=a[top - 1];
           return data;        
        }

        //Check stack is empty or not
        public bool IsEmpty()
        {
            if (top == -1)
            {
                return true;
            }

            else return false;
        }

        //Size of Stack
        public int Size()
        {
            return a.Length;
        }

        //Show all data inside the stack
        public void Show()
        {
            string st = "[";
            for(int i = 0; i < a.Length; i++)
            {
                st += a[i];
                if (i < a.Length - 1)
                {
                    st += ",";
                }
            }
            st += "]";
            Console.WriteLine(st);
        }
    }
}

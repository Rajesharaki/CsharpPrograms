using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructurePrograms
{
    class BinarySearchTree
    {
        //Creating Node class
        class Node
        {
            public int Data;
            public Node Left;
            public Node Right;
            public Node(int Data)
            {
                this.Data = Data;
            }
        }
        Node Root;
        //Adds a Items into the binary tree
        public void Add(int Data)
        {
            Node n = new Node(Data);
            if (Root == null)      //If root is empty then root pointing to the newly created object
            {
                Root = n;
                return;
            }
            Node Current = Root;
            Node Parent = Current;
            while (Current != null)   //Finding the position to Add a items into the Balanced tree
            {
                Parent = Current;
                if (n.Data < Current.Data)
                {
                    Current = Current.Left;
                }
                else if(n.Data> Current.Data)
                {
                    Current = Current.Right;
                }
            }
            if (n.Data < Parent.Data) //If N data is Less than Parent Data then Add item into the Left side of Parent
            {
                Parent.Left = n;
            }
            else                       //Else Add item into Right side of Parent
            {
                Parent.Right = n;
            }
        }
        public bool Search(int Data)
        {
            static bool Searching(Node Root, int Data)
            {
                if (Root == null)
                {
                    return false;
                }
                if (Root.Data == Data)
                {
                    return true;
                }
                else if(Data<Root.Data)
                {
                    return Searching(Root.Left, Data);
                }
                else
                {
                    return Searching(Root.Right, Data);
                }

            }
            return Searching(Root, Data);
        }
    }
}

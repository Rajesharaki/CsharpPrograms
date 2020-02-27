using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DataStructurePrograms
{
    class HashFunction
    {
        public HashFunction()
        {
            Console.Write("Enter the File name: ");
            String FilePath = Path.GetFullPath(Console.ReadLine()); //Getting file full path
            String[] Con = File.ReadAllText(FilePath).Split(' ');   //Readiing all text from the file and returned in String array 
            int[] Content = IntArray(Con);
            OrderedList[] HashTable = CreateHashTable(Content);
            Console.Write("Enter the Searching element: ");
            int num = int.Parse(Console.ReadLine());
            if (Search(num, HashTable))
            {
                Console.WriteLine(num + " number is Found in the TextFile...");
            }
            else
            {
                Console.WriteLine(num + " number is not Found in TextFile..."); 
            }
            Display(HashTable);
        }
        //Convert String Array to int Array
        static int[] IntArray(String[] a)
        {
            UnOrderedList<int> list = new UnOrderedList<int>();
            int Number, i;
            //Fill string element into the UnOrderedList
            for (i = 0; i < a.Length; i++)
            {
                if (int.TryParse(a[i], out Number)) //Convert String element to int for ex: "32" its converted into int and added to the list & negelate "a" this type of string value
                {
                    list.Add(Number);
                }
            }
            //Find the proper size and added to the int arrray
            int[] b = new int[list.Size()];
            for (i = 0; i < b.Length; i++)
            {
                b[i] = list.Peek(i);
            }
            return b;
        }
        //Creating slot and  inside the slot create object of list and add elements into the slot
        public OrderedList[] CreateHashTable(int[] a)
        {
            OrderedList[] slot = new OrderedList[11];
            int i;
            for (i = 0; i < slot.Length; i++) //creating list object inside the slot
            {
                slot[i] = new OrderedList();
            }
            for (i = 0; i < a.Length; i++) //adding element to the slot
            {
                int Index = a[i] % 11; //Finding the slot position
                slot[Index].Add(a[i]);
            }
            return slot;
        }
        //Searching user Entered element
        public bool Search(int num, OrderedList[] a)
        {
            int Index = num % 11;
            return a[Index].Search(num);
        }
    }
}

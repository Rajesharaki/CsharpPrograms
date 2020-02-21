using System;
using System.Collections.Generic;
using System.Text;

namespace CsharpPrograms.AlgorithmPrograms
{
    class InsertionSort
    {
        public InsertionSort()
        {
            Sorting();
        }
        static void Sorting()
        {
            Utility u = new Utility();
            Console.Write("Enter the Size Of an array: ");
            int Size =u.ReadInt();
            String[] a = new String[Size];
            //array filling
            for(int i = 0; i < Size; i++)
            {
                Console.Write("Enter the Only String value: ");
                a[i]= Console.ReadLine();
            }
            //insertion sort
            for(int i = 1; i < Size; i++)
            {
                string temp = a[i];
                int j = i - 1;
                while (j >= 0 && a[j].CompareTo(temp) > 0)
                {
                    a[j + 1] = a[j];
                    j--;
                }
                a[j + 1] = temp;
            }
            //Sorted value display
            String st = "{";
            for(int i = 0; i < Size; i++)
            {
                st += a[i] + ",";
            }
            st += "}";
            Console.WriteLine(st);
        }
    }
}

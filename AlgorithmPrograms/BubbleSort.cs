using System;
using System.Collections.Generic;
using System.Text;

namespace CsharpPrograms.AlgorithmPrograms
{
    class BubbleSort
    {
        public BubbleSort()
        {
            Sorting();
        }
        static void Sorting()
        {
            Utility u = new Utility();
            Console.Write("Enter the size of an array: ");
            int Size = u.ReadInt();
            int[] a = new int[Size];
            for (int i = 0; i < Size; i++)
            {
                Console.Write("Enter the Values: ");
                a[i] = u.ReadInt();
            }
            for(int i = 0; i < Size; i++)
            {
                for(int j = i+1; j < Size; j++)
                {
                    if (a[i] > a[j])
                    {
                        int temp = a[i];
                        a[i] = a[j];
                        a[j] = temp;
                    }
                }
            }
            //Display sorted array
            String st = "{";
            for(int i = 0; i < Size; i++)
            {
                st += a[i]+",";
               
            }
            st += "}";
            Console.WriteLine(st);
        }
    }
}

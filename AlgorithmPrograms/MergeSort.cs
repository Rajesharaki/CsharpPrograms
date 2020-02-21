using System;
using System.Collections.Generic;
using System.Text;

namespace CsharpPrograms.AlgorithmPrograms
{
    class MergeSort
    {
        public MergeSort()
        {
            Show();
        }
        static void Show()
        {
            Console.Write("Enter the size of an array: ");
            int Size = int.Parse(Console.ReadLine());
            int[] a = new int[Size];
            Console.WriteLine("Fill the array ...................................................................");
            for(int i = 0; i < Size; i++)
            {
                Console.Write("Enter  the value: ");
                a[i] = int.Parse(Console.ReadLine());
            }
            Sort(a, 0, a.Length - 1);
            PrintArray(a);
        }
        static void Sort(int [] a,int f,int l)
        {
            if (f < l)
            {
                int mid = (f + l) / 2;
                Sort(a, f, mid);
                Sort(a,mid + 1, l);
                Merge(a,f,l,mid);
            }
        }
        static void Merge(int [] a,int f,int l,int mid)
        {
            int n1 = mid - f + 1;
            int n2 = l - mid;
            int[] L = new int[n1];
            int[] R = new int[n2];
            int i,j;
            for(i = 0;i < n1; i++)
            {
                L[i] = a[f+i];
            }
            for (i = 0; i < n2; i++)
            {
                R[i] = a[mid+1+i];
            }
            i = 0; j = 0;
            int k = f;
            while (i <n1 && j <n2)
            {
                if (L[i] <= R[j])
                {
                    a[k++] = L[i++];
                }
                else
                {
                    a[k++] = R[j++];
                }
            }
            while (i < n1)
            {
                a[k++] = L[i++];
            }
            while (j <n2)
            {
                a[k++] = R[j++];
            }
        }
        static void PrintArray(int[] a)
        {
            string st = "{";
            for(int i = 0; i < a.Length; i++)
            {
                st += a[i];
                if (i <= a.Length - 2)
                {
                    st += ",";
                }
            }
            st += "}";
            Console.WriteLine(st);
        }
    }
}

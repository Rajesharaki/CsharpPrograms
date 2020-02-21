using System;
using System.Collections.Generic;
using System.Text;

namespace CsharpPrograms.AlgorithmPrograms
{
    class BinarySearch
    {
        public BinarySearch()
        {
            Search();
        }
        static void Search()
        {
            Utility u = new Utility();
            Console.Write("Enter the size of an array: ");
            int Size = u.ReadInt();
            String[] a = new String[Size];
            for(int i = 0; i < a.Length; i++)
            {
                Console.Write("Enter the word: ");
                a[i] = Console.ReadLine();
            }
            Console.WriteLine("Enter the Serching Element: ");
            String Ele = Console.ReadLine();
           int Index= Recursion(a,0,a.Length-1,Ele);
            Console.WriteLine(Ele + " Present index is: '" + Index + "'");
        }
        static int Recursion(String[] a,int f,int l,String Ele)
        {
            Array.Sort(a);
            if (f > l) 
            {
                return -1;
            }
            int mid=(f+l)/2;
            if (Ele.CompareTo(a[mid])==0)
            {
                return mid;
            }
            else if (Ele.CompareTo(a[mid]) > 0)
            {
                f = mid+1;
            }
            else
            {
                l = mid-1;
            }
            return Recursion(a, f, l, Ele);
        }
    }
}

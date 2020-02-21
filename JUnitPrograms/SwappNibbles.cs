using System;
using System.Collections.Generic;
using System.Text;

namespace CsharpPrograms.JUnitTestingPrograms
{
    class SwappNibbles
    {
        public SwappNibbles()
        {
            Show();
        }
        static void Show()
        {
            Utility u = new Utility();
            Console.Write("Enter the number: ");
            int num = u.ReadInt();
            int bin=DecToBin(num);
            String s = "" + bin;
            int swdec= IsSwappNibbles(s);
            BinToDec(swdec);
        }
        static int DecToBin(int num)
        {
            int temp = num;
            String st = "";
            while (num != 0)
            {
                int rem = num % 2;
                st = rem + st;
                num /= 2;
            }
            Console.WriteLine(temp + " Before swap Binary value is: " + st);
            int bin = int.Parse(st);
            return bin;
        }
        static int IsSwappNibbles(String bin)
        {
            int l = bin.Length;
            char[] a = new char[l];
            int k = 0;
            for(int i = 0; i < a.Length; i++)
            {
                a[i]=bin[k];k++;
            }
            String s = "";
          for(int i=a.Length-4;i<a.Length;i++)
            {
                s += a[i]+"";
            }
          for(int i = 0; i < 4; i++)
            {
                s += a[i] + "";
            }
            Console.WriteLine("After Swap "+s);
            int sw = int.Parse(s);
            return sw;
        }
        static void BinToDec(int bin)
        {
            double sum = 0;int i = 1;
            while (bin != 0)
            {
                int rem = bin % 10;
                sum += rem * i;
                bin /= 10;
                i *= 2;
            }
            Console.WriteLine("After Swapping Decimal number: " + sum);
        }
    }
}

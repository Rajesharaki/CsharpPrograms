using System;
using System.Collections.Generic;
using System.Text;

namespace CsharpPrograms.AlgorithmPrograms
{
    class MakeStringPalindrome
    {
        public MakeStringPalindrome()
        {
            Make();
        }
        static void Make()
        {
            Console.Write("Enter the String: ");
            String str = Console.ReadLine();
            //First Check Given string is palindrome or not
            int o = 0, p = str.Length-1;
            while (o <= p)
            {
                if (str[o] == str[p])
                {
                    o++; p--;
                    if (o == p)
                    {
                        Console.WriteLine(str + " is a Palindrome word.........");
                        Environment.Exit(0);
                    }
                }
                else
                {
                    break;
                }

            }
            //if not then make string to palindrome
            char[] a=str.ToCharArray();//string char array
            Array.Sort(a);
            char[] b = new char[a.Length];//Empty array
            int i, m = 0, n = a.Length - 1;
            //filling Empty array
            for (i = 0; m <n &&i<a.Length-1; i++)
            {
                if (a[i] == a[i + 1])
                {
                    b[m] = a[i];
                    b[n] = a[i + 1];
                    m++; n--;
                }
            }
            
            //making string
            int r = 0, s = 0; char[] temp = new char[a.Length];
            for(int j = 0; j < a.Length; j++)
            {
                for (int k = 0; k < a.Length; k++)
                {
                    if (a[j] != a[k])
                    {
                        r++;
                        if (r == a.Length-1)
                        {
                            temp[s] = a[j];
                            s++;
                        }
                    }
                }
                r = 0;
            }
            //Check palindrome
            for (int u = 0; u < a.Length; u++)
            {
                if (temp[u] != '\u0000')
                {
                    b[m] = temp[u];
                    m++;
                }
            }
            String st = new String(b);
            Console.WriteLine(st);
            int v = 0, l = st.Length - 1;
            while (v < l)
            {
                if (st[v] != st[l])
                {
                    Console.WriteLine(st + " Word is Not a Palindrome");
                    Environment.Exit(0);
                }
                v++;l--;
            }
            Console.WriteLine(st + " Word is a Palindrome");

        }
    }
}


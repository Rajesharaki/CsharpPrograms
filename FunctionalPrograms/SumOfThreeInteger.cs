using System;
using System.Collections.Generic;
using System.Text;


namespace CsharpPrograms.FunctionalPrograms
{
    class SumOfThreeInteger
    {
      public SumOfThreeInteger()
        {
            CallMethod();
        }
        static void CallMethod()
        {
            Utility u = new Utility();
            Console.Write("Enter the Size Of an array: ");
            int size = u.ReadInt();
            int[] a = new int[size];
            for(int i = 0; i < a.Length; i++)
            {
                Console.Write("Enter the values: ");
                a[i] = u.ReadInt();
            }
            int count = 0;
            for (int i = 0; i < a.Length; i++)
            {
                for(int j = 0; j < a.Length; j++)
                {
                    for(int k = 0; k < a.Length; k++)
                    {
                        if (a[i] + a[j] + a[k] == 0)
                        {
                            Console.WriteLine( "distinct triplates are: " +a[i] + " " + a[j] +" " + a[k]);
                            count++;
                        }
                    }
                }
            }
            Console.WriteLine("number of triplets: " + count);
        }
    }
}

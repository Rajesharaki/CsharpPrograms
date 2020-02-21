using System;
using System.Collections.Generic;
using System.Text;

namespace CsharpPrograms.AlgorithmPrograms
{
    class PrimeRange
    {
        public PrimeRange()
        {
            PrintPrime();
        }
        static void PrintPrime()
        {
            Utility u = new Utility();
            Console.WriteLine("Enter the range: ");
            Console.Write("Enter First range value: ");
            int Low = u.ReadInt();
            Console.Write("Enter the Second range value: ");
            int High = u.ReadInt();
            if (Low > High)
            {
              
                int temp = Low;
                Low = High;
                High = temp;
            }
            for (int i = Low; i <= High; i++)
            {
                if (IsPrime(i))
                {
                    Console.WriteLine(i);
                }
            }
        }
        static bool IsPrime(int num)
        {
           
            bool flag = true;
            for(int i = 2; i <= num / 2; i++)
            {
                if (num % i == 0)
                {
                    flag = false;
                }
            }
            return flag;
        }
    }
}

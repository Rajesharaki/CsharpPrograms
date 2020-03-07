using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructurePrograms
{
    class PrimeNumber2D
    {
        public PrimeNumber2D()
        {
            Console.WriteLine("Enter the Range: ");
            Console.Write("Enter the Low Range: ");
            int Low = int.Parse(Console.ReadLine());
            Console.Write("Enter the high range: ");
            int High = int.Parse(Console.ReadLine());
            int Row = (High / 100);
            int Col = CountColumn();
            int[,] a = new int[Row, Col];
            FillArray(a,Row,Col);
            DisplayArray(a);
        }
        //Count number of prime number column
       static int CountColumn()
        {
            int Count = 0;
            for(int i = 0; i <= 100; i++)
            {
                if (IsPrime(i))
                {
                    Count++;
                }
            }
            return Count;
        }
        //Checking the number is prime or not
        static bool IsPrime(int num)
        {
            bool Flag = true;
            for(int i = 2; i < num / 2; i++)
            {
                if (num % i == 0)
                {
                    Flag = false;
                }
            }
            return Flag;
        }
        //Range of prime number filling into an 2D array
        static void FillArray(int[,] a,int Row,int Col)
        {
            int k = 1, n = 100, j = 0;
            for(int i = 0; i < Row; i++)
            {
                    while (k <=n&&j<Col)
                    {
                        if (IsPrime(k))
                        {
                            a[i, j] = k;
                            j++;
                        }
                        k++;
                    }
                k = n;n = n + 100;j = 0;
            }
        }
        //Displaying the array
        static void DisplayArray(int [,] a)
        {
            for(int i = 0; i < a.GetLength(0); i++)
            {
                for(int j = 0; j < a.GetLength(1); j++)
                {
                    if (a[i, j] != 0)
                    {
                        Console.Write(a[i, j] + " ");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}

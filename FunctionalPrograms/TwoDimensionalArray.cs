using System;
using CsharpPrograms.BasicPrograms;

namespace CsharpPrograms.FunctionalPrograms
{
    class TwoDimensionalArray
    {
        public TwoDimensionalArray()
        {
            ShowArray();
        }
        public static void ShowArray()
        {
            Utility u = new Utility();
            Console.Write("Enter the number of row: ");
            int row = u.ReadInt();
            Console.Write("Enter the number of column: ");
            int col = u.ReadInt();
            int[,] a= new int[row, col];
            for (int i = 0; i < a.GetLength(0); i++)
            {
                for(int j=0;j<a.GetLength(1);j++)
                {
                    Console.Write("Enter the value: ");
                    a[i, j] = u.ReadInt();
                }
            }
            Console.WriteLine("Array Filled");
            for(int i = 0; i < a.GetLength(0); i++)
            {
                for (int j = 0; j < a.GetLength(1); j++)
                {
                    Console.Write(a[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine("Array Displayed............");
        }
    }
}

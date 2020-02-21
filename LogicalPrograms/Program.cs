using System;
using System.Collections.Generic;
using System.Text;
using CsharpPrograms.LogicalPrograms;


namespace CsharpPrograms.BasicPrograms
{
    class Program
    {
        static void Main(string[] args)
        {
            Utility u = new Utility();
            Console.Write("Enter the Class Number: ");
                int num = u.ReadInt();
            switch (num)
            {
                case 1: new Gambler(); break;
                case 2: new CoupanNumber(); break;
                case 3: new StopWatch(); break;
                case 4: new TicTacGame(); break;
                case 5: new TicTacGameByUsingOneDArray();break;
                default: Console.WriteLine("No such Class Name: ");
                    break;
            }
        }
    }
}

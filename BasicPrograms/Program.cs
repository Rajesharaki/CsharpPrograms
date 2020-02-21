using System;
using System.Collections.Generic;
using System.Text;


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
                case 1: new UserName();break;
                case 2: new FlipCoin();break;
                case 3: new LeapYear();break;
                case 4: new PowerOf2();break;
                case 5: new HarmonicNumber();break;
                case 6: new Factor();break;
                default: Console.WriteLine("No such Class Name: ");
                    break;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using CsharpPrograms.JUnitTestingPrograms;


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
                case 1: new TemperaturConversion(); break;
                case 2: new MonthlyPayment(); break;
                case 3: new Sqrt(); break;
                case 4: new ToBinary(); break;
                case 5: new SwappNibbles(); break;
                case 6: new VendingMachine(); break;
                default: Console.WriteLine("No such Class Name: ");
                    break;
            }
        }
    }
}

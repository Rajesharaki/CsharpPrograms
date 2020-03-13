using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.StructuralDesignPattern.FacadeDesignPattern
{
    public class FacadeDesignPatternTesting
    {
        static void Main(String [] args)
        {
            Console.WriteLine("Display address from json file");
            Console.WriteLine();
            DisplayAddress.FromJsonFile();

            Console.WriteLine("-------------------------------------------");
            Console.WriteLine("Display address from Text file");
            Console.WriteLine();
            DisplayAddress.FromTextFile();
        }
    }
}

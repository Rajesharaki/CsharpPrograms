using DesignPatterns.CreationalDesignPatterns.FactoryPattern;
using System;

namespace DesignPatterns
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the Product Name: ");
            Computer Product = ComputerFactory.GetInstance(Console.ReadLine());
            Product.Produce();
        }
    }
}

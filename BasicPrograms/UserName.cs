using System;
using CsharpPrograms.BasicPrograms;

namespace CsharpPrograms.BasicPrograms
{
    class UserName
    {
        public UserName()
        {
            PrintName();
        }
        static void PrintName()
        {
            Utility u = new Utility();
            Console.Write("Enter your name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Hello " + name + " ,How are you? ");
        }
    }
}

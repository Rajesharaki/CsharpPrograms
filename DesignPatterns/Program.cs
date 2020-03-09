using DesignPatterns.CreationalDesignPatterns.SingletonPatterns;
using System;

namespace DesignPatterns
{
    class Program
    {
        static void Main(string[] args)
        {
            var object1=SingletonPattern.GetInstance;
            var object2 = SingletonPattern.GetInstance;
            Console.WriteLine(object1.GetHashCode());
            Console.WriteLine(object1.GetHashCode());
        }
    }
}

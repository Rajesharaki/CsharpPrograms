using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.CreationalDesignPatterns.SingletonPatterns
{
    sealed class StaticIntialazationSingleton
    {
        private static StaticIntialazationSingleton Instance = new StaticIntialazationSingleton();
        private StaticIntialazationSingleton() { }
        public static StaticIntialazationSingleton GetStaticIntialazationSingleton
        {
          
            get
            {
                int a,b;
                Console.Write("Enter the value: ");
                int.TryParse(Console.ReadLine(), out a);
                Console.Write("Enter the value: ");
                int.TryParse(Console.ReadLine(), out b);
                try
                {
                    return Instance;
                }
                catch (Exception e)
                {
                    throw new Exception("Exception occured in creating singleton instance");
                }
            }
        }
    }
}

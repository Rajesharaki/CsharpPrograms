using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.CreationalDesignPatterns.SingletonPatterns
{
    sealed class DoublyCheckedLocking
    {
        private static Object ObjectInstance = new object();
        private static DoublyCheckedLocking Instance;
        private static int count = 0;
        private DoublyCheckedLocking() { Console.WriteLine("Count: " + (++count)); }
       
        public static DoublyCheckedLocking GetDoublyCheckedLockingInsatnce
        {
            get
            {
                if (Instance == null)
                {
                    lock (ObjectInstance)
                    {
                        if (Instance == null)
                        {
                            Instance = new DoublyCheckedLocking();
                        }
                    }
                }
                return Instance;
            }
        }
        public void PrintDetails(string message)
        {
            Console.WriteLine(message);
        }
    }
}

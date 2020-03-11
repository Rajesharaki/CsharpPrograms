using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.CreationalDesignPatterns.SingletonPatterns
{
    public sealed class ThreadSafeSingleton
    {
        private static readonly  Object Locker = new Object();
        private static ThreadSafeSingleton Instance;
        static int count = 0;

        /*Make Constructor private because if we make constructor private out side the class we can't create object and that class doesn't have any child class 
        (means inheritance not possible)*/
        private ThreadSafeSingleton() { Console.WriteLine("Count: " + (++count)); }

        /*if we make method synchronize then it's create only one object in multithreading or single threading but drawback is if we make method synchornize then performance will reduce*/
        public static ThreadSafeSingleton GetInstance
        {
            get
            {
                lock (Locker)
                {
                    if (Instance == null)
                    {
                        Instance = new ThreadSafeSingleton();
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

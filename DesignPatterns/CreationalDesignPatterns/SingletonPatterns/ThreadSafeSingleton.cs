using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.CreationalDesignPatterns.SingletonPatterns
{
    public sealed class ThreadSafeSingleton
    {
        private static  Object Locker = new Object();
        private static ThreadSafeSingleton Instance;
        private ThreadSafeSingleton() { }
        public static ThreadSafeSingleton GetInstance()
        {
            if (Instance == null)
            {
                lock (Locker)
                {
                    if (Instance == null)
                    {
                        Instance = new ThreadSafeSingleton();
                    }
                }
            }
            return Instance;
        }
    }
}

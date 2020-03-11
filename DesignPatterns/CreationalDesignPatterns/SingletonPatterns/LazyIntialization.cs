using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace DesignPatterns.CreationalDesignPatterns.SingletonPatterns
{
    public sealed class LazyIntialization
    {
        private static LazyIntialization Instance;
        private LazyIntialization() { }
        public static LazyIntialization GetInstance()
        {
            if (Instance == null)
            {
                Instance = new LazyIntialization();
            }
            return Instance;
        }

    }
}

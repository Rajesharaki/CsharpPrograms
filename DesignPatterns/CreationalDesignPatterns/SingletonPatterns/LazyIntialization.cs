using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.CreationalDesignPatterns.SingletonPatterns
{
    class LazyIntialization
    {
        private static LazyIntialization Instance;
        private LazyIntialization() { }
        public LazyIntialization GetInsatnce()
        {
            Instance = null;
            if (Instance == null)
            {
                Instance = new LazyIntialization();
            }
            return Instance;
        }
    }
}

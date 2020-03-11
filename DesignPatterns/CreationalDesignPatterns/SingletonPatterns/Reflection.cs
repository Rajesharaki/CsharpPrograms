using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.CreationalDesignPatterns.SingletonPatterns
{
    sealed class Reflection : Demo
    {
        private Reflection()
        {

        }
        public static Reflection GetInstance
        {
            get
            {
                return ReflectionHelperClass.Instance;
            }
        }
        private sealed class ReflectionHelperClass
        {
            public static Reflection Instance = new Reflection();
        }
    }
}

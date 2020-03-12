using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.CreationalDesignPatterns.SingletonPatterns
{
    sealed class Reflection
    {
        private Reflection()
        {
            if (ReflectionHelperClass.Instance != null)
            {
                throw new Exception("Excecption occured in creating Singleton object");
            }
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

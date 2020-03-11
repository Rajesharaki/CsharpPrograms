using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.CreationalDesignPatterns.SingletonPatterns
{
    public sealed class BillPughSingleton
    {
        static int count = 0;
        private BillPughSingleton() { Console.WriteLine("Count: "+(++count)); }
        public static BillPughSingleton GetPughSingletonInstance
        {
            get
            {
                return BillPughInnerClass.Instance;
            }
        }
        private sealed class BillPughInnerClass
        {
            public static BillPughSingleton Instance = new BillPughSingleton(); 
        }
    }
}

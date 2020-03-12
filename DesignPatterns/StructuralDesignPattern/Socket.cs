using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.StructuralDesignPattern
{
    //Assume we have one Socket and it produce 120 voltls
    public sealed class Socket //Just I making class singleton because here one object is enough
    {
        private Socket() { }

        //Creating a GetVolt method And it produce 120 volt
        public int GetVolt()
        {
            return 120;
        }

        //Get Socket instance
        public static Socket GetSocketInstance
        {
            get
            {
               return HelperClass.Instance;
            }
        }

        //Bill pugh Singleton 
        private sealed class HelperClass
        {
            public static Socket Instance=new Socket();
        }
    }
}

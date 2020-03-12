using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.StructuralDesignPattern
{
    class Testing
    {
        static void Main(String [] args)
        {
            ISocketAdopter Insatnce = new SocketAdopterImplementation();
            Console.WriteLine(Insatnce.GetVolt120());
            Console.WriteLine(Insatnce.GetVolt12());
            Console.WriteLine(Insatnce.GetVolt3());
        }
    }
}

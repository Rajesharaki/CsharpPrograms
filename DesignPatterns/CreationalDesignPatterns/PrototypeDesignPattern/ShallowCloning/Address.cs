using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.CreationalDesignPatterns.PrototypeDesignPattern.ShallowCloning
{
    public class Address : Cloning
    {
        public override Cloning GetClone()
        {
            return (Address)this.MemberwiseClone();
        }

        public override void GetDetails()
        {
            Console.WriteLine($"Address: {this.address}");
        }
    }
}

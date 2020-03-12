using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.CreationalDesignPatterns.PrototypeDesignPattern.DeepCloning
{
    public class Address : Clone
    {
        public string address { get; set; }
        public override Clone GetClone()
        {
            return (Address)this.MemberwiseClone();
        }

        public override void GetDetails()
        {
            Console.WriteLine($"Address: {this.address}");
        }
    }
}

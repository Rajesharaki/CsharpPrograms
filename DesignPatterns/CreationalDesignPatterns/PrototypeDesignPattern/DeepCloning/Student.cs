using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.CreationalDesignPatterns.PrototypeDesignPattern.DeepCloning
{
    public class Student :Clone
    {
        public string USN { get; set; }
        public Address addressObject=new Address();

        public override Clone GetClone()
        {
            Student Instance=(Student)this.MemberwiseClone(); // By using superclass reference copy the student object
            Instance.addressObject = (Address)addressObject.GetClone();
            return Instance;
        }

        public override void GetDetails()
        {
            Console.WriteLine($"Student Name : {this.Name}\nUSN:{this.USN}\nDept: {this.Dept}\nAddress: {addressObject.address}");
        }
    }
}

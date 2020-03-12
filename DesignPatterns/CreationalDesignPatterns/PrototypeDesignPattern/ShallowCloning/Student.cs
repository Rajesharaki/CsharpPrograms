using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.CreationalDesignPatterns.PrototypeDesignPattern.ShallowCloning
{
    //shallow clonning
    public class Student :Cloning
    {
        public string USN { get; set; }
       
        public override Cloning GetClone()
        {
            return (Student)this.MemberwiseClone(); // By using superclass reference copy the student object
        }

        public override void GetDetails()
        {
            Console.WriteLine($"Student Name : {this.Name}\nUSN:{this.USN}\nDept: {this.Dept}");
        }
    }
}

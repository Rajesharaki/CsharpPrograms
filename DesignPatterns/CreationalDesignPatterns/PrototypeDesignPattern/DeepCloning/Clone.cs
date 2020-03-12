using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.CreationalDesignPatterns.PrototypeDesignPattern.DeepCloning
{
    public abstract class Clone
    {
        public string Name { get; set; }
        public string Dept { get; set; }
       
        public abstract Clone GetClone();
        public abstract void GetDetails();
    }
}

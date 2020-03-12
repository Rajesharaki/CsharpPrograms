using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.CreationalDesignPatterns.PrototypeDesignPattern.ShallowCloning
{
    /// <summary>
    /// Create abstract class 
    /// </summary>
    public abstract class Cloning
    {
        public string Name { get; set; }
        public string Dept { get; set; }
        public string address { get; set; }
        public abstract Cloning GetClone();
        public abstract void GetDetails();
    }
}

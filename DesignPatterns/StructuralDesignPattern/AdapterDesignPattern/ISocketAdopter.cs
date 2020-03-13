using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.StructuralDesignPattern
{

    //Create ISocketAdopter interface Its adopter B/W Socket and Required voltage convereter
    public interface ISocketAdopter
    {
        public int GetVolt120(); //Adopter produce 120volts
        public int GetVolt12();//Adopter produce 12volts
        public int GetVolt3();//Adopter produce 3volts
    }
}

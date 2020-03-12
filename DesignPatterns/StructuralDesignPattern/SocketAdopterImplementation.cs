using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.StructuralDesignPattern
{

    /// <summary>
    /// Implementation of Scoket adopter interface
    /// </summary>
    public class SocketAdopterImplementation : ISocketAdopter
    {
        Socket obj = Socket.GetSocketInstance; //Creating Socket class object
        public int GetVolt120()
        {
            return obj.GetVolt(); //Producing 120volts
        }

        public int GetVolt12() //Adopter convert 120volts to 12 volts 
        {
            return Converter(obj,10); //120/10=12;
        }

        public int GetVolt3() //Adopter convert 120volts to 3 volts
        {
            return Converter(obj, 40);
        }

        //Converting Socket volts to required volts
        public int Converter(Socket Socketobj,int RequiredVolt)
        {
            int volt=(Socketobj.GetVolt()) / RequiredVolt;
            return volt;
        }
    }
}

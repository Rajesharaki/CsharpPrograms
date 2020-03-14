using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.BehavioralDesignPattern.MediatorDesignPattern
{
    class Client
    {
        static void Main(String [] args)
        {
            IMediator MediatorInstance = new MediatorImpl();
            IUsers Rajesha = new UsersImpl(MediatorInstance, "Rajesha");
            IUsers Madan= new UsersImpl(MediatorInstance, "Madan");
            IUsers Sanju = new UsersImpl(MediatorInstance, "Sanju");
            IUsers Sundar = new UsersImpl(MediatorInstance, "Sundar");
            IUsers Rohith = new UsersImpl(MediatorInstance, "Rohith");
          
            MediatorInstance.Register(Madan);
            MediatorInstance.Register(Sanju);
            MediatorInstance.Register(Sundar);
            MediatorInstance.Register(Rohith);
            Rajesha.Send("Hi How are you guys");
        }
    }
}

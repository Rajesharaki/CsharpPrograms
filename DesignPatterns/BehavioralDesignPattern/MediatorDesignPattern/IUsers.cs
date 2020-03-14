using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.BehavioralDesignPattern.MediatorDesignPattern
{
    public abstract class IUsers
    {
       public IMediator mediator;
        public string Name;
        public IUsers(IMediator mediator, string name)
        {
            this.mediator = mediator;
            this.Name = name;
        }
        public abstract void Receive(string message);
        public abstract void Send(string message );
    }
}

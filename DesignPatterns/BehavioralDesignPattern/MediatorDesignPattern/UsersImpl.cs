using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.BehavioralDesignPattern.MediatorDesignPattern
{
    public class UsersImpl : IUsers
    {
        public UsersImpl(IMediator mediator,string name) :base(mediator, name)
        {
         
        }
        public override void Receive(string message)
        {
            Console.WriteLine(this.Name + ": Received Message:  " + message);
        }

        public override void Send(string message)
        {
            Console.WriteLine(this.Name + ":Sending Message: " + message+"\n\n");
            mediator.SendMessage(message,this);
        }
    }
}

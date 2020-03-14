using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.BehavioralDesignPattern.MediatorDesignPattern
{
    public interface IMediator
    {
        public void Register(IUsers user);
        public void SendMessage(String message,IUsers users);
    }
}

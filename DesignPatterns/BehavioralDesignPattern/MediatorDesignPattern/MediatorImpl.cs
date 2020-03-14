using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.BehavioralDesignPattern.MediatorDesignPattern
{
    public class MediatorImpl : IMediator
    {
        List<IUsers> users = new List<IUsers>();
        public void Register(IUsers user)
        {
            users.Add(user);
        }

        public void SendMessage(string message,IUsers user)
        {
            foreach(var send in users)
            {
                if (send != user)
                {
                    send.Receive(message);
                }
            }
        }
    }
}

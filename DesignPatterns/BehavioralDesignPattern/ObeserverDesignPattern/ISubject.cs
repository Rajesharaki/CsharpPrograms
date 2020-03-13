using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.BehavioralDesignPattern
{
    public interface ISubject
    {
       
        public void Register(IObserver subscribe);
        public void UnRegister(IObserver subscribe);
        public void ProvideAvailablity(String Available);
    }
}

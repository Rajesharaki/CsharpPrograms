using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.BehavioralDesignPattern
{
    public class Testing
    {
        static void Main(String [] args)
        {
            ISubject flipkart = new Flipkart();
            IObserver instance = new PersonOne("Rajesha T K");
            flipkart.Register(instance);
            IObserver instance2 = new PersonOne("Sanju");
            flipkart.Register(instance2);
            IObserver instance1 = new PersonTwo("Madan T K");
            flipkart.Register(instance1);
            flipkart.ProvideAvailablity("available");
            flipkart.ProvideAvailablity("Notavailable");
        }
    }
}

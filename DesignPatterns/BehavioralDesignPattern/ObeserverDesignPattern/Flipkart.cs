using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.BehavioralDesignPattern
{
    public class Flipkart : ISubject
    {
        public string ProductName = "Redmi";
        public int Price = 10000;
        public string Available = "Available";
        List<IObserver> Details;
        public void Notify()
        {
            foreach (var notify in Details)
            {
                Flipkart instance = new Flipkart();
                notify.Update(instance);
            }
        }

        public void ProvideAvailablity(string Available)
        {
            if (Available.ToLower() == "available")
            {
                Notify();
            }
            else
            {
                Console.WriteLine("Out of Stock");
            }
        }
        public void Register(IObserver subscribe)
        {
            if (Details == null)
            {
                Details = new List<IObserver>();
            }
            Details.Add(subscribe);
        }

        public void UnRegister(IObserver subscribe)
        {
            if (Details.Contains(subscribe))
            {
                Details.Remove(subscribe);
            }
            else
            {
                Console.WriteLine("Not valid");
            }
        }
    }
}

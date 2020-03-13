using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.BehavioralDesignPattern
{
    public class PersonOne : IObserver
    {
        String PersonName;
        public PersonOne(string name)
        {
            this.PersonName = name;
        }

        public void Update(Flipkart updates)
        {
            Console.WriteLine($"Dear {this.PersonName}\nproduct:{updates.ProductName}\nPrice:{updates.Price}\nProduct {updates.Available} now........\n");
        }
    }
}

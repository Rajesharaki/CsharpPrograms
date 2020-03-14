using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.BehavioralDesignPattern.VisitorDesignPattern
{
    public class ShoppingCartVisitorImpl : IShoppingCartVisitor
    {
        public double Visit(Fruits fruit)
        {
            double sum = 0;
            sum += fruit.Weight * fruit.price;
            return sum;
        }

        public double Visit(Vegitables veg)
        {
            double sum = 0;
            sum += veg.Weight * veg.price;
            return sum;
        }
    }
}

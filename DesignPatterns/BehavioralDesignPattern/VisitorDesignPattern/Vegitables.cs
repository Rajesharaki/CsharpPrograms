using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.BehavioralDesignPattern.VisitorDesignPattern
{
    public class Vegitables:IItemElement
    {
        public string VegitablesName;
        public int price;
        public double Weight;
        public Vegitables(string VegitablesName, int price, double weight)
        {
            this.VegitablesName = VegitablesName;
            this.price = price;
            this.Weight = weight;
        }
        public double accept(IShoppingCartVisitor Visitor)
        {
            return Visitor.Visit(this);
        }
    }
}

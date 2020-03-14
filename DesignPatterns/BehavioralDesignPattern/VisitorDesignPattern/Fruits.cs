using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.BehavioralDesignPattern.VisitorDesignPattern
{
    public class Fruits : IItemElement
    {
        public string FruitName;
        public int price;
        public double Weight;
        public Fruits(string FruitName,int price,double weight) 
        {
            this.FruitName = FruitName;
            this.price = price;
            this.Weight = weight;
        }
        public double accept(IShoppingCartVisitor Visitor)
        {
            return Visitor.Visit(this);
        }
    }
}

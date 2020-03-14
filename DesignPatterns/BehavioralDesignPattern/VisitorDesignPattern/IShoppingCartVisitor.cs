using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.BehavioralDesignPattern.VisitorDesignPattern
{
    public interface IShoppingCartVisitor
    {
        public double Visit(Fruits fruit);
        public double Visit(Vegitables veg);
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.BehavioralDesignPattern.VisitorDesignPattern
{
    public interface IItemElement
    {
        public double accept(IShoppingCartVisitor Visitor);
    }
}

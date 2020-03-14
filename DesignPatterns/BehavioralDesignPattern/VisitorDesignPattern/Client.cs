using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.BehavioralDesignPattern.VisitorDesignPattern
{
    class Client
    {
        public static void Main(String [] args)
        {
            IItemElement[] items = new IItemElement[] {new Fruits("Apple",100,2),new Vegitables("Tamoto",60,1) };
            double total = Calculation(items);
            Console.WriteLine("TotalAmount: " + total);
        }
        private static double Calculation(IItemElement[] items)
        {
            double amount = 0;
            IShoppingCartVisitor visit = new ShoppingCartVisitorImpl();
            for (int i = 0; i < items.Length; i++)
            {
                amount += items[i].accept(visit);
            }
            return amount;
        }
    }
}

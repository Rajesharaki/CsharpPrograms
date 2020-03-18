using ObjectOrientedPrograms.CommercialDataProcessing;
using ObjectOrientedPrograms.InventoryManagementData;
using ObjectOrientedPrograms.DeckOfCards;
using System;

namespace ObjectOrientedPrograms.StockAccountManagement
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the class number  ");
            int num = int.Parse(Console.ReadLine());
            switch (num)
            {
                case 1:new AddressBook();break;
                case 2:new InventoryManagement();break;
                case 3:new StockAccountManagement();break;
                case 4:new CommericialDataManagement();break;
                case 5:new DeckOfCard();break;
                case 6:new DeckCardQueue();break;
                default:Console.WriteLine("Invalid Class Number: ");break;
            }
        }
    }
}

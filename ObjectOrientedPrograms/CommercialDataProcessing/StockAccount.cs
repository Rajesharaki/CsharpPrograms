using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace ObjectOrientedPrograms.CommercialDataProcessing
{
    class StockAccount
    {
        public string Name;
        public double Cash;
        public int NumberOfShares;
        public String [] StockSymbols ;
        public double [] ShareAmount;
        public double [] StockPrice;
        public double [] Price;
        public DateTime Timing = DateTime.Now;
        public double TotalStackPrice;
        public void Fill(String FileName)
        {
            this.Name = FileName;
            Console.Write("Enter the Cash : ");
            this.Cash = double.Parse(Console.ReadLine());
            Console.Write("Enter the Number of Shares: ");
            this.NumberOfShares = int.Parse(Console.ReadLine());
            StockSymbols = new String[NumberOfShares];
            ShareAmount = new double[NumberOfShares];
            StockPrice = new double[NumberOfShares];
            Price = new double[NumberOfShares];
            for (int i = 0; i < NumberOfShares; i++)
            {
                Console.Write("Enter the Stock Symbols: ");
                this.StockSymbols[i] = Console.ReadLine();
                Console.Write("Enter the Shareamount: ");
                this.ShareAmount[i] = double.Parse(Console.ReadLine());
                Console.Write("Enter the Price for each Share: ");
                this.Price[i] = double.Parse(Console.ReadLine());
                this.StockPrice[i] = ShareAmount[i]*Price[i];
            }
            ValueOf();
        }
        public void ValueOf()
        {
            for (int i = 0; i < StockPrice.Length; i++)
            {
                this.TotalStackPrice += StockPrice[i];
            }
        }
        public void PrintReport()
        {
            string st = "";
            Console.WriteLine($"Name:{this.Name}\nCash:{this.Cash}\nNumberOfShare:{this.NumberOfShares}"+st.PadRight(12)+ $"Date: { Timing}");
            Console.WriteLine("_______________________________________________");
            for (int i = 0; i < this.NumberOfShares; i++)
            {
                Console.WriteLine("Share Number: " + (i + 1));
                Console.WriteLine($"StockSymbols: {StockSymbols[i]}\nShareAmountPrice: {ShareAmount[i]}\nPrice: {Price[i]}\nStockPrice: {StockPrice[i]}");
                Console.WriteLine();
            }
            Console.WriteLine($"TotalStackPrice:{ TotalStackPrice}");
            Console.WriteLine("-----------------------------------------------------------------");
        }
    }
}

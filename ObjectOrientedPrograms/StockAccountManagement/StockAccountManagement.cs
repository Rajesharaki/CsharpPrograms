using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Newtonsoft.Json;

namespace ObjectOrientedPrograms.StockAccountManagement
{
    class StockAccountManagement
    {
        String FilePath = @"C:\Users\yempc72\Desktop\StockFile.json"; //StockFile.json File path

        /// <summary>
        /// Stock Account Management Constructor
        /// </summary>
        public StockAccountManagement()
        {
            Selection();
        }
        /// <summary>
        /// Choose Add stocks or Display
        /// </summary>
        public void Selection()
        {
            Console.WriteLine("1-->AddStock\n2-->DisplayStockDetails\n(Any number to Quit(Except 1&2))");
            int select = int.Parse(Console.ReadLine());
            switch (select)
            {
                case 1:
                    AddStock();
                    break;
                case 2:
                    Display();
                    break;
                default: 
                    Environment.Exit(0); 
                    break;
            }
        }
        /// <summary>
        /// Adding a stocks into json file
        /// </summary>
        public void AddStock()
        {
            Console.Write("Enter the StockName: ");
            string stock = Console.ReadLine();
            Console.Write("Enter the Number of Share: ");
            long share = long.Parse(Console.ReadLine());
            Console.Write("Enter the StockPrice: ");
            long shareprice = long.Parse(Console.ReadLine());
            //Intializing a Stock variables
            Stock obj = new Stock
            {
                StockName = stock,
                NumberOfShare = share,
                SharePrice = shareprice,
                TotalStockPrice = share * shareprice
            };
            string Read = File.ReadAllText(FilePath);//Reading all text from StockFile
            StockPortFoili Sobj = new StockPortFoili();//Creating  StockPortFoili class object
            if (Read.Length==0)//If file is empty then Intaializing GrandTotalStockPrice
            {
                Sobj.GrandTotalStockPrice = obj.TotalStockPrice;
            }
            //if File is Not Empty then Deserialize the json class information and intializing GrandTotalStockPrice
            if (Read.Length != 0)
            {
                Sobj= JsonConvert.DeserializeObject<StockPortFoili>(Read); //Deserializing
                Sobj.GrandTotalStockPrice +=obj.TotalStockPrice;
            }
            //If List is not intialized then create List object
            if (Sobj.Stocks==null)
            {
                Sobj.Stocks = new List<Stock>();//creating list object
            }
            Sobj.Stocks.Add(obj);//Adding Stock object into the List
            String serialize = JsonConvert.SerializeObject(Sobj);//Serializing the StockPortFoili into Json class information
            File.WriteAllText(FilePath, serialize);//Write all text into the StockFile
            Selection();
        }
        /// <summary>
        /// Display Stock information
        /// </summary>
        public void Display()
        {
            string Read=File.ReadAllText(FilePath);//Reading all text from Stock json file
            var Deserialize = JsonConvert.DeserializeObject<StockPortFoili>(Read);//Converting json class information to Class object
            foreach(var read in Deserialize.Stocks)
            {
                Console.WriteLine(read + "\n");//Displaying details prest inside the List<Stock> object 
            }
            Console.WriteLine("GrandTotalStockPrice: " + Deserialize.GrandTotalStockPrice);//Displaying details prest inside the class
            Selection();
        }
    }
}

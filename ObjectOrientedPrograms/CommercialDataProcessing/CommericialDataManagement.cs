using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Newtonsoft.Json;

namespace ObjectOrientedPrograms.CommercialDataProcessing
{
    class CommericialDataManagement
    {
        String FilePath = @"C:\Users\yempc72\Desktop\DataStore.json";
        public List<StockAccount> account;
        public CommericialDataManagement()
        {
            Selection();
        }
        public void Selection()
        {
            Console.WriteLine("1-->Add Stocks\n2-->Display Stocks\n3-->Remove Stocks");
            int Select = int.Parse(Console.ReadLine());
            switch (Select)
            {
                case 1: AddStock(); break;
                case 2: Display(); break;
                case 3: Remove(); break;
                default: Environment.Exit(0); break;
            }
        }
        public void AddStock()
        {
            Console.WriteLine("Enter the Name: ");
            String Name = Console.ReadLine();
            StockAccount ac = new StockAccount();
            ac.Fill(Name);
            if (account == null)
            {
                account = new List<StockAccount>();
            }
            string Read = File.ReadAllText(FilePath);
            if (Read.Length != 0)
            {
                account = JsonConvert.DeserializeObject<List<StockAccount>>(Read);
            }
            account.Add(ac);
            string ClassInformation = JsonConvert.SerializeObject(account);
            File.WriteAllText(FilePath, ClassInformation);
            Selection();
        }
        public void Remove()
        {
            string Read = File.ReadAllText(FilePath);
            if (account == null)
            {
                account=JsonConvert.DeserializeObject<List<StockAccount>>(Read);
            }
            Console.Write("Enter the Name ");
            String name = Console.ReadLine();
            StockAccount[] Copy = account.ToArray();
            List<StockAccount> NewList = new List<StockAccount>();
            for (int i = 0; i < Copy.Length; i++)
            {
                if (Copy[i].Name != name)
                {
                    NewList.Add(Copy[i]);
                }
            }
            string serialize = JsonConvert.SerializeObject(NewList);
            File.WriteAllText(FilePath, serialize);
            Selection();
        }
        public void Display()
        {
            string Read = File.ReadAllText(FilePath);
            List<StockAccount> list = new List<StockAccount>();
            list = JsonConvert.DeserializeObject<List<StockAccount>>(Read);
            foreach (var Print in list)
            {
                Print.PrintReport();
            }
            Selection();
        }
    }
}

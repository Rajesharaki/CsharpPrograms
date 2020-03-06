using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ObjectOrientedPrograms.InventoryManagementData
{
    class InventoryManagement
    {
        InventoryFactory iv;
        string FilePath = @"C:\Users\yempc72\Desktop\Inventory.json";
        public InventoryManagement()
        {
            InventoryManagements();
        }
        public void InventoryManagements()
        {
            Console.WriteLine("1--> AddItems 2--> Display 3--> quit");
            int num = int.Parse(Console.ReadLine());
            switch (num)
            {
                case 1: AddItems(); break;
                case 2: Display(); break;
                case 3: Environment.Exit(0); break;
                default:
                    Console.WriteLine("Entered wrong number ..Enter agsin");
                    InventoryManagements();
                    break;
            }

        }
        public void AddItems()
        {
            Console.WriteLine("1-->Add Rice Items\n2-->Add Pulses Items\n3-->Add Wheats items");
            int Selection = int.Parse(Console.ReadLine());
            Console.Write("Enter the Brand Name: ");
            string name = Console.ReadLine();
            Console.Write("Enter Weight: ");
            long Weight = long.Parse(Console.ReadLine());
            Console.Write("Enter the Price per Kg: ");
            long Price = long.Parse(Console.ReadLine());
            Seeds seed = new Seeds()
            {
                Name = name,
                Weight = Weight,
                Price = Price,
                TotalPrice = Price * Weight
            };
            string FilePath = @"C:\Users\yempc72\Desktop\Inventory.json";
            string Read = File.ReadAllText(FilePath);
            if (iv == null)
            {
                iv = new InventoryFactory();
            }
            if (Read.Length != 0)
            {
                iv = JsonConvert.DeserializeObject<InventoryFactory>(Read);
            }
            switch (Selection)
            {
                case 1:
                    if (iv.Rice == null)
                    {
                        iv.Rice = new List<Seeds>();
                    }
                    iv.Rice.Add(seed);
                    break;
                case 2:
                    if (iv.Pulses == null)
                    {
                        iv.Pulses = new List<Seeds>();
                    }
                    iv.Pulses.Add(seed);
                    break;
                case 3:
                    if (iv.Wheats == null)
                    {
                        iv.Wheats = new List<Seeds>();
                    }
                    iv.Wheats.Add(seed);
                    break;
                default:
                    Console.WriteLine("Entered Wrong number...Enter again....");
                    AddItems();
                    break;
            }
            string data = JsonConvert.SerializeObject(iv);
            File.WriteAllText(FilePath, data);
            InventoryManagements();
        }
        public void Display()
        {
            String Read = File.ReadAllText(FilePath);
            iv = JsonConvert.DeserializeObject<InventoryFactory>(Read);
            Console.WriteLine("1--> RiceDetails \n2--> Pulses Details\n3--> Wheats Details\n4-->All Details\n5-->AddItems\nQuit(Any number)");
            int select = int.Parse(Console.ReadLine());
            Console.Clear();
            switch (select)
            {
                case 1:
                    Console.WriteLine("...................Rice Details...............");
                    Console.WriteLine("_______________________________________________");
                    foreach (var rice in iv.Rice)
                    {
                        Console.WriteLine(rice.ToString() + "\n");
                    }
                    break;
                case 2:
                    Console.WriteLine("...................Pulses Details...............");
                    Console.WriteLine("_______________________________________________");
                    foreach (var pulses in iv.Pulses)
                    {
                        Console.WriteLine(pulses.ToString() + "\n");
                    }
                    break;
                case 3:
                    Console.WriteLine("...................Wheats Details...............");
                    Console.WriteLine("_______________________________________________");
                    foreach (var wheats in iv.Wheats)
                    {
                        Console.WriteLine(wheats.ToString() + "\n");
                    }
                    break;
                case 4:
                    Console.WriteLine("...................Rice Details...............");
                    Console.WriteLine("_______________________________________________");
                    foreach (var rice in iv.Rice)
                    {
                        Console.WriteLine(rice.ToString() + "\n");
                    }
                    Console.WriteLine("...................Pulses Details...............");
                    Console.WriteLine("_______________________________________________");
                    foreach (var pulses in iv.Pulses)
                    {
                        Console.WriteLine(pulses.ToString() + "\n");
                    }
                    Console.WriteLine("...................Wheats Details...............");
                    Console.WriteLine("_______________________________________________");
                    foreach (var wheats in iv.Wheats)
                    {
                        Console.WriteLine(wheats.ToString() + "\n");
                    }
                    break;
                case 5:
                    AddItems();
                    break;
                default:
                    Environment.Exit(0);
                    break;
            }
            Display();
        }
    }

}


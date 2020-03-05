using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ObjectOrientedPrograms.InventoryManagementData
{
    class InventoryManagement
    {
        public InventoryManagement()
        {
            Console.WriteLine("Welcome to Inventory MAnagement");
            while (true)
            {
                Console.WriteLine("Enter A to Add\tEnter D to delete an Item");
                char entered = char.Parse(Console.ReadLine());
                switch (entered)
                {
                    case 'A': Add(); break;
                    case 'D': Delete(); break;
                    default: Console.WriteLine("Enter a valid character"); break;
                }
                Console.WriteLine("enter yes/No to conitnue");
                if (Console.ReadLine() != "yes")
                {
                    break;
                }
            }
        }

        public void Add()
        {
            ////fetching the json file
            string jfile = File.ReadAllText(@"C:\Users\yempc72\Desktop\DataFile.json");
            ////creating the inventory object and assgning the deserialized value to it
            Inventory iv;
            iv = (Inventory)JsonConvert.DeserializeObject<Inventory>(jfile);
            if (iv == null)
            {
                iv = new Inventory();
            }
            int sum = 0;
            if (iv != null)
            {
                sum = iv.Sum;
            }
            ////creating a Seeds object to fill it in switch based on requirement
            Seeds item = new Seeds();
            ////asking the user to choose the given option
            Console.WriteLine("Enter 1--> for Rice\tEnter 2--> for Pulses\tEnter 3--> for Wheats\t");
            int entered = int.Parse(Console.ReadLine());
            ////filling the details
            Console.Write("Enter the name of the Product: ");
            item.brand = Console.ReadLine();
            Console.Write("Enter the Price per Kg: ");
            item.PricePerKg = int.Parse(Console.ReadLine());
            Console.Write("Enter the Weight: ");
            item.Weight = int.Parse(Console.ReadLine());
            item.TotalPrice = item.PricePerKg * item.Weight;
            if (iv != null)
            {
                sum += item.TotalPrice;
            }
            else
            {
                sum = item.TotalPrice;
            }
            ////running a  based on user
            switch (entered)
            {
                case 1:
                    if (iv.Rice == null)
                    {
                        iv.Rice = new List<Seeds>();
                    }
                    iv.Rice.Add(item);
                    break;
                case 2:
                    if (iv.Pulses == null)
                    {
                        iv.Pulses = new List<Seeds>();
                    }
                    iv.Pulses.Add(item);
                    break;
                case 3:
                    if (iv.Wheats == null)
                    {
                        iv.Wheats = new List<Seeds>();
                    }
                    iv.Wheats.Add(item);
                    break;
                default:
                    Console.WriteLine("Invalid Entry try Again...");
                    break;
            }
            iv.Sum = sum;
            ////now serializing and writing to file directly 
            using (System.IO.StreamWriter writer = File.CreateText(@"C:\Users\yempc72\Desktop\DataFile.json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(writer, iv);
                Console.WriteLine("new Product Added to the Inventory");
            }
        }
        public void Delete()
        {
            Console.WriteLine("Are you sure you Want to delete...items from Inventory: ");
            string jfile = File.ReadAllText(@"C:\Users\yempc72\Desktop\DataFile.json");
            Inventory iv = JsonConvert.DeserializeObject<Inventory>(jfile);
            Console.WriteLine("Enter 1--> for Rice\tEnter 2--> for Pulses\tEnter 3--> for Wheats\t");
            int entered = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the name of the brand");
            string brand = Console.ReadLine();
            int sum = iv.Sum;
            switch (entered)
            {
                case 1:
                    foreach (Seeds s in iv.Rice)
                    {
                        if (s.brand.Equals(brand))
                        {
                            sum -= s.TotalPrice;
                            iv.Rice.Remove(s);
                            break;
                        }
                    }
                    break;
                case 2:
                    foreach (Seeds s in iv.Pulses)
                    {
                        if (s.brand.Equals(brand))
                        {
                            sum -= s.TotalPrice;
                            iv.Rice.Remove(s);
                            break;
                        }
                    }
                    break;
                case 3:
                    foreach (Seeds s in iv.Wheats)
                    {
                        if (s.brand.Equals(brand))
                        {
                            sum -= s.TotalPrice;
                            iv.Rice.Remove(s);
                            break;
                        }
                    }
                    break;
                default:
                    Console.WriteLine("there is no such brand available in Inventory");
                    break;
            }
            using (StreamWriter stream = File.CreateText(@"C:\Users\yempc72\Desktop\DataFile.json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(stream, iv);
            }
        }
    }
}

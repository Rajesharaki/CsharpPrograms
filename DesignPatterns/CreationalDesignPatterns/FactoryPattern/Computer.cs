using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.CreationalDesignPatterns.FactoryPattern
{
    public abstract class Computer
    {
        public string BrandName;
        public String Processor;
        public string RAM;
        public abstract void Produce();
    }
    public class PC : Computer
    {
     
        public override void Produce()
        {
            this.BrandName = "Lenovo";
            this.Processor = "Intelcore";
            this.RAM = "8GB";
            Console.WriteLine($"PC\nBrandName: {BrandName}\nProcessor: {Processor}\nRAM: {RAM}");
        }
    }
    public class Loptop : Computer
    {
        public override void Produce()
        {

            this.BrandName = "HP";
            this.Processor = "Intelcore";
            this.RAM = "12GB";
            Console.WriteLine($"LOPTOP\nBrandName: {BrandName}\nProcessor: {Processor}\nRAM: {RAM}");
        }
    }
    public class Server : Computer
    {
        public override void Produce()
        {

            this.BrandName = "DELL Power Edge";
            this.Processor = "Intel Xeon";
            this.RAM = "16GB";
            Console.WriteLine($"SERVER\nBrandName: {BrandName}\nProcessor: {Processor}\nRAM: {RAM}");
        }
    }
    public class ComputerFactory
    {
        public static Computer GetInstance(string ProductName)
        {
            Computer Instance = null;
            if (ProductName.ToUpper() == "PC")
            {
                Instance = new PC();
            }
            else if (ProductName.ToUpper() == "LOPTOP")
            {
                Instance = new Loptop();
            }
            else if (ProductName.ToUpper() == "SERVER")
            {
                Instance = new Server();
            }
            else
            {
                Console.WriteLine("Product Not available");
            }
            return Instance;
        }
    }
}

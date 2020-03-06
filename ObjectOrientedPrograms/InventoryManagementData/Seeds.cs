using System;
using System.Collections.Generic;
using System.Text;

namespace ObjectOrientedPrograms.InventoryManagementData
{
    public class InventoryFactory
    {

        public List<Seeds> Rice;
        public List<Seeds> Pulses;
        public List<Seeds> Wheats;
      
    }
    public class Seeds
    {
        public String Name;
        public long Weight;
        public long Price;
        public long TotalPrice;
        public string ToString()
        {
            string st = $"Name:{Name}\nWeight:{Weight}\nPrice:{Price}\nTotalPrice{TotalPrice}";
            return st;
        }
    }
}


using System;
using System.Collections.Generic;
using System.Text;

namespace CsharpPrograms.JUnitTestingPrograms
{
    class VendingMachine
    {
        public VendingMachine()
        {
            GiveChange();
        }
         static void GiveChange()
        {
            Utility u = new Utility();
            Console.Write("Enter the Amount: ");
            int Money = u.ReadInt();
            int Tcount = 0, Fcount = 0, Hcount = 0, Ftcount = 0, Ten = 0, Five = 0, Two = 0, One = 0; 
                while(Money>0)
              {
                if (Money == 1000) { Tcount++; }
                else if (Money > 1000){ Money -= 1000; Tcount++; }
                else if (Money == 500) { Money -= 500; Fcount++; }
                else if (Money > 500) {  Money -= 500;Fcount++; }
                else if (Money==100) { Money -= 100; Hcount++; }
                else if (Money > 100) { Money -= 100;Hcount++; }
                else if (Money == 50) { Money -= 50; Ftcount++; }
                else if (Money > 50) { Money -=50;Ftcount++; }
                else if (Money == 10) { Money -= 10; Ten++; }
                else if (Money > 10) { Money -= 10;Ten++; }
                else if (Money == 5) { Money -= 5; Five++; }
                else if (Money > 5) { Money -= 5;Five++; }
                else if (Money == 2) { Money -= 2; Two++; }
                else if (Money > 2) { Money -= 2;Two++; }
                else if (Money == 1) { Money -= 1; One++; }
                else if (Money > 1) { Money -= 1;One++; }
              }
            if (Tcount != 0) { Console.WriteLine(1000 + " rupees " + Tcount + " Notes"); }
            if (Fcount != 0) { Console.WriteLine(500 + " rupees " + Fcount + " Notes"); }
            if (Hcount != 0) { Console.WriteLine(100 + " rupees " + Hcount + " Notes"); }
            if (Ftcount != 0) { Console.WriteLine(50 + " rupees " + Ftcount + " Notes"); }
            if (Ten != 0) { Console.WriteLine(10 + " rupees " + Ten + " Notes"); }
            if (Five != 0) { Console.WriteLine(5 + " rupees " + Five + " Notes"); }
            if (Two != 0) { Console.WriteLine(2 + " rupees " + Two + " Notes"); }
            if (One != 0) { Console.WriteLine(1 + " rupees " + One + " Notes"); }
        }
    }
}

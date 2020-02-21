using System;
using System.Collections.Generic;
using System.Text;

namespace CsharpPrograms.JUnitTestingPrograms
{
    class MonthlyPayment
    {
        public MonthlyPayment()
        {
            Payment();
        }
        static void Payment()
        {
            Utility u = new Utility();
            Console.Write("Enter the Amount: ");
            double p = u.ReadDouble();
            Console.Write("Enter the Year: ");
            double year = u.ReadInt();
            Console.Write("Enter the interest: ");
            double R= u.ReadInt();
            double n = 12 * year;
            double r = (R/100)/12;
            double Payment = (p * r) /(1 - Math.Pow(1 + r, -n));
            Console.WriteLine("Monthly you have to pay: "+Payment);
            Console.WriteLine("Total Interest: " + ((Payment*(year*12))-p));
            Console.WriteLine("Totally you have to pay : " + (Payment * (year * 12)));
        }
    }
}

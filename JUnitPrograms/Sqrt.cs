using System;
using System.Collections.Generic;
using System.Text;

namespace CsharpPrograms.JUnitTestingPrograms
{
    class Sqrt
    {
        public Sqrt()
        {
            FindRoot();
        }
        static void FindRoot()
        {
            Utility u = new Utility();
            Console.Write("Enter the number: ");
            double c = u.ReadDouble();
            Double t = c;
            double epsilon = 1 * Math.Pow(10, -15);
            while (Math.Abs(t - c / t) > epsilon * t)
            {
                t = (t + c / t)/2;
            }
            Console.WriteLine("Square root of " + c + " is: " + t);

        }
    }
}

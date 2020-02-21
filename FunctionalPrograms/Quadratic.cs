using System;

namespace CsharpPrograms.FunctionalPrograms
{
    class Quadratic
    {
        public Quadratic()
        {
            IsEquation();
        }
        static void IsEquation()
        {
            Utility u = new Utility();
            Console.Write("Enter the value of a : ");
            int a = u.ReadInt();
            Console.Write("Enter the value of b: ");
            int b = u.ReadInt();
            Console.Write("Enter the value of c : ");
            int  c = u.ReadInt();
            double delta = (b * b - 4 * a * c);
            if (delta > 0)
            {
                double x1 = (-b + Math.Sqrt(delta)) / (2 * a);
                double x2 = (-b - Math.Sqrt(delta)) / (2 * a);
                Console.WriteLine("Root of x1 is :" + x1 + " and Root of x2 is: " + x2);
            }
            else if (delta == 0)
            {
                double root = (-b) / (2 * a);
                Console.WriteLine("Root is: " + root);
            }
            else
            {
                double actual= (-b) / (2 * a);
                double imaginary = (Math.Sqrt(delta))/(2*a);
                Console.WriteLine("Actual root is " + actual + " imaginary root is " + imaginary);
            }
        }
    }
}

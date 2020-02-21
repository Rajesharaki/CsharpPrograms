using System;

namespace CsharpPrograms.FunctionalPrograms
{
    class WindChill
    {
    public WindChill()
        {
            CheckWind();
        }
        static void CheckWind()
        {
            Utility u = new Utility();
            Console.Write("Enter the Temperture: ");
            double t = u.ReadDouble();
            Console.Write("Enter the Wind Speed: ");
            double v = u.ReadDouble();
            if (v < 120 || v >= 3)
            {
                double w = 35.74 + (0.6215 * t) + ((0.4275 * t) - 35.75) * Math.Pow(v, 0.16);
                Console.WriteLine("Effective temperature is: " + w);
            }
            else
            {
                Console.WriteLine("Not valid Wind Speed....");
            }
        }
        
    }
}

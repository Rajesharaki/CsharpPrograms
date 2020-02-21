using System;
using System.Collections.Generic;
using System.Text;

namespace CsharpPrograms.JUnitTestingPrograms
{
    class TemperaturConversion
    {
        public TemperaturConversion()
        {
            ConvertTemp();
        }
        static void ConvertTemp()
        {
            Utility u = new Utility();
            Console.Write("Enter the Temperatur: ");
            double t = u.ReadInt();
            Console.Write("Enter the degree of Temperatur: ");
            char c = u.ReadChar();
            while (true)
            {
                if (c == 'c' || c == 'C')
                {
                    double far = (t * (9.0/5.0)) + 32;
                    Console.WriteLine("Celsius to Fahrenheit temperatur is: " + far);
                    break;
                }
                else if (c == 'f' || c == 'F')
                {
                    double cel = (t - 32) * (5.0 / 9);
                    Console.WriteLine("Fahrenheit to Celsius temperatur is : " + cel);
                    break;
                }
                else
                {
                    Console.WriteLine("Not valid Degree of Temperatur....Enter again... ");
                    c = u.ReadChar();
                }
            }
        }
    }
}

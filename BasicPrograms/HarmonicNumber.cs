using System;
using System.Collections.Generic;
using System.Text;

namespace CsharpPrograms.BasicPrograms
{
    class HarmonicNumber
    {
        public HarmonicNumber()
        {
            IsHarmonic();
        }
        static void IsHarmonic()
        {
            Utility u = new Utility();
            Console.Write("Enter the  n th number: ");
            int num = u.ReadInt();
            if (num > 0)
            {
                double sum = 0.0;
                for(double i = 1; i <= num; i++)
                {
                    sum += 1 / i;
                }
                Console.WriteLine(num + " th Harmonic number is = " + sum);
            }
        }
    }
}

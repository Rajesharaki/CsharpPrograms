using System;

namespace CsharpPrograms.BasicPrograms
{
    class PowerOf2
    {
        public PowerOf2()
        {
            PrintPower();
        }
        static void PrintPower()
        {
            Utility u = new Utility();
            Console.Write("Enter the number: ");
            int num = u.ReadInt();
            for(int i = 1; i <= num; i++)
            {
                Console.WriteLine(Math.Pow(2, i));
            }
        }
    }
}

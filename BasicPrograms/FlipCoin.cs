using System;
using System.Collections.Generic;
using System.Text;

namespace CsharpPrograms.BasicPrograms
{
    class FlipCoin
    {
        public FlipCoin()
        {
            FlipGame();
        }
        static void FlipGame()
        {
            Utility u = new Utility();
            Console.Write("Enter how many times you want to flip coin: ");
            int t = u.ReadInt();
            Random rc = new Random();
            int head = 0, tail = 0;
            if (t > 0)
            {
                for(int i = 1; i <= t; t--)
                {
                    double rf = rc.NextDouble();
                    Console.WriteLine("ramdom number id:" + rf);
                    if (rf < 0.5)
                    {
                        Console.WriteLine("Tail");
                        tail++;

                    }
                    else
                    {
                        Console.WriteLine("Head");
                        head++;
                    }
                }
            }
            else
            {
                Console.WriteLine("Coin not Flipped.............");
            }
            Console.WriteLine("Percentage of Head/tail is:" + (head / tail));
        }
    }
}

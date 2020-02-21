using System;
using System.Collections.Generic;
using System.Text;

namespace CsharpPrograms.LogicalPrograms
{
    class Gambler
    {
        public Gambler()
        {
            GamblerGame();

        }
        public static void GamblerGame()
        {
            Utility u = new Utility();
            Console.Write("Enter amount how much you have: ");
            int amount = u.ReadInt();
            Console.Write("Enter your Goal amount: ");
            int goal = u.ReadInt();
            int stake = 1;
            Random rc = new Random();
            if (amount < goal)
            {
                while (amount != 0 && amount < goal)
                {
                    Console.Write("Enter the Stake amount: ");
                    stake = u.ReadInt();
                    int rn = rc.Next(2);
                    if (stake == 0)
                    {
                        Console.WriteLine("you Entered " + stake + " rs you can't play in this amount Enter again: ");
                    }
                    else if (rn == 0)
                    {
                        Console.WriteLine("Lol....you loss " + stake + " rs");
                        amount -= stake;
                        Console.WriteLine("Now...you have " + amount + " rs");
                    }
                    else
                    {
                        Console.WriteLine("Ohhh!!....you won " + stake + " rs ");
                        amount += stake;
                        Console.WriteLine("Now...you have " + amount + " rs");
                    }
                }


            }
            else
            {
                Console.WriteLine("Your enter some amount to your goal.....");
            }


        }
    }
}

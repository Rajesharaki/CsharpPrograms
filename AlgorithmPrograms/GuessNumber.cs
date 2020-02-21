using System;
using System.Collections.Generic;
using System.Text;

namespace CsharpPrograms.AlgorithmPrograms
{
    class GuessNumber
    {
        public GuessNumber()
        {
            Game();
        }
        static void Game()
        {
            Utility u = new Utility();
            Console.Write("Enter the number: ");
            int num = u.ReadInt();
            int range=(int)Math.Pow(2, num);
            Console.WriteLine("Choose a Number Between 0 to "+ (range-1));
           int number= Guess(0,range);
            Console.WriteLine("Your number is : " + number);
        }
        static int Guess(int f,int l)
        {
            if ((l - f) == 1)
            {
                return f;
            }
            int mid = f+(l-f) / 2;
            Console.WriteLine("Is it your number is less than (true/false) " + mid+"?");
            if (bool.Parse(Console.ReadLine()))
            {
                return Guess (f, mid);
            }
            else
            {
               return  Guess(mid, l);  
            }
        }
    }
}

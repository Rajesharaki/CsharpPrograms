using System;
using System.Collections.Generic;
using System.Text;

namespace CsharpPrograms.AlgorithmPrograms
{
    class Anagram
    {
        public Anagram()
        {
            Check();
        }
        static void Check()
        {
            Console.Write("Enter the First word: ");
            string First = Console.ReadLine();
            Console.Write("Enter the Second Word: ");
            string Second = Console.ReadLine();
            if (First.Length != Second.Length)
            {
                Console.WriteLine(First + " and " + Second + " are not a Anagram word................");
                Environment.Exit(0);
            }
            char [] fa=First.ToCharArray();
            Array.Sort(fa);
            char[] sa = Second.ToCharArray();
            Array.Sort(sa);
            for(int i = 0; i < fa.Length; i++)
            {
                if (fa[i] != sa[i])
                {
                  Console.WriteLine(First + " and " + Second + " are not a Anagram word................");
                    Environment.Exit(0);
                }
            }
            Console.WriteLine(First + " and " + Second + "  both are  Anagram word..................");
        }
    }
}

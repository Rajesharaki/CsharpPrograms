using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructurePrograms
{
    class PalindromeChecker
    {
        public PalindromeChecker()
        {
            Check();
        }
        public static void Check()
        {
            Console.Write("Enter the  String: ");
            String Word = Console.ReadLine();
            DeQueue<char> list = new DeQueue<char>(Word.Length);

            //add char into the que
            for(int i = 0; i < Word.Length; i++)
            {
                list.AddRear(Word[i]);
            }
            //Check Palindrome
            while (!(list.IsEmpty()))
            {
                if (list.Size() == 1)
                {
                    break;
                }
                if (!(list.RemoveFront().Equals(list.RemoveRear())))
                {
                    Console.WriteLine("'"+Word + "' is not a Palindrome word.....");
                    Environment.Exit(0);
                }
            }
            Console.WriteLine("'"+Word + "' is a Palindrome Word......");
        }
    }
}

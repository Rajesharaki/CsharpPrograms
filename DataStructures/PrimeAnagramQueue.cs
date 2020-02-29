using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructurePrograms
{
    class PrimeAnagramQueue
    {
        public PrimeAnagramQueue()
        {
            UnOrderedList<int> list = new UnOrderedList<int>();
            Console.WriteLine("Enter the range: ");
            Console.Write("Enter the Low range: ");
            int Low = int.Parse(Console.ReadLine());
            Console.Write("Enter the high range: ");
            int High = int.Parse(Console.ReadLine());
            while (Low <= High)
            {
                if (Anagram.IsPrime(Low))  //Check prime number
                {
                    bool flag = true;
                    int num = Anagram.CheckAnagram(Low); //make Anagram number
                    if (Anagram.IsPrime(num) && num >= 10 && !(Anagram.CheckPalindrome(num))) //check annagram number is prime or not
                    {
                        if (list.CheckRepeat(num) || list.CheckRepeat(Low))
                        {
                            flag = false;
                        }
                    }
                    if (flag && Anagram.IsPrime(num) && num >= 10 && !(Anagram.CheckPalindrome(num)))
                    {
                        list.Add(Low);
                        list.Add(num);
                    }
                }
                Low++;
            }
            Queue<int> queue = new Queue<int>(list.Size());
            for (int i = 0; i <list.Size(); i++)  //Fetching data in reverse
            {
                queue.Enqueue(list.Peek(i));
            }
            Console.WriteLine(queue);
        }
    }
}

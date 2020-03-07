using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructurePrograms
{
    class Anagram
    {
        public Anagram()
        {
            Console.WriteLine("Enter the range: ");
            Console.Write("Enter the Low range: ");
            int Low = int.Parse(Console.ReadLine());
            Console.Write("Enter the hogh range: ");
            int High = int.Parse(Console.ReadLine());
            int Col = Check(Low,High);
            Console.WriteLine("COl: " + Col);
            int[,] a = new int[2, Col];int i=0,j=0,k=0;
            while (Low <= High)
            {
                if (IsPrime(Low))  //Check prime number
                {
                    int num=CheckAnagram(Low); //make Anagram number
                    if (IsPrime(num)&&num>=10&&!(CheckPalindrome(num))) //check annagram number is prime or not
                    {
                        bool flag = true;
                        for(int m = 0; m < a.GetLength(1)&&a[0,m]!=0; m++)
                        {
                            if (a[0, m] == num || a[0, m] == Low) //check repeated value in 2D array
                            {
                                flag = false;
                                break;
                            }
                        }
                        if (flag)    //not repeated the added Prime and anagram number into the 2D array first row
                        {
                            a[0, j++] = Low;
                            a[0, j++] = num;
                        }
                    }
                    else  //fill only prime number without anagram number into 2D array second row
                    {
                        a[1, k++] = Low;
                    }
                }
                Low++;
            }
            Display(a); //Display Array
            
        }
        //Checking number is Prime or not
        static bool IsPrime(int num)
        {
            bool Flag = true;
            for(int i = 2; i < num / 2; i++)
            {
                if (num % i == 0)
                {
                    Flag = false;
                }
            }
            return Flag;
        }
        //making prime number to anangram number
        static int CheckAnagram(int num)
        {
            int Prod = 0;
            while (num != 0)
            {
                int rem = num % 10;
                Prod = Prod * 10 + rem;
                num /= 10;
            }
            return Prod;
        }
        //finding  the Column size
        static int Check(int Low,int High)
        {
            int Count = 0;
            for (int i = Low; i <= High; i++)
            {
                if (IsPrime(i))
                {
                    Count++;
                }
            }
            return Count;
        }
        //Display 2D array
        static void Display(int[,] a)
        {
            Console.WriteLine("Prime And Anagram numbers..........");
            for(int i = 0; i < a.GetLength(0); i++)
            {
                for(int j = 0; j < a.GetLength(1); j++)
                {
                    if (a[i, j] != 0)
                    {
                        Console.Write(a[i, j] + " ");
                    }
                }
                if (i == (a.GetLength(0)-1)) { break; }
                Console.WriteLine();
                Console.WriteLine("Prime numbers without Anagram numbers......");
            }
        }
        //Checking Prime number is Palindrome or not
        static bool CheckPalindrome(int num)
        {
            int temp = num, Prod = 0;
            while (num != 0)
            {
                int rem = num % 10;
                Prod = Prod * 10 + rem;
                num /= 10;
            }
            return temp == Prod;
        }
    }
}

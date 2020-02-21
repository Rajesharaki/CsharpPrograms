using CsharpPrograms.AlgorithmPrograms;
using System;


namespace CsharpPrograms.BasicPrograms
{
    class Program
    {
        static void Main(string[] args)
        {
            Utility u = new Utility();
            Console.Write("Enter the Class Number: ");
                int num = u.ReadInt();
            switch (num)
            {
                case 1: new Anagram();break;
                case 2: new BinarySearch();break;
                case 3: new BubbleSort();break;
                case 4: new CheckPrimePalindromeAndAnagram();break;
                case 5: new GuessNumber();break;
                case 6: new InsertionSort();break;
                case 7: new MakeStringPalindrome();break;
                case 8: new MergeSort();break;
                case 9: new PermutationString();break;
                case 10: new PrimeRange();break;
                case 11: new RegexExpression();break;
                default: Console.WriteLine("No such Class Name: ");
                    break;
            }
        }
    }
}

using System;

namespace DataStructurePrograms
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the Class Number: ");
            int ClassNumber = int.Parse(Console.ReadLine());
            switch (ClassNumber)
            {

                case 1: new FileReadNumber();break;
                case 2: new FileRead();break;
                case 3: new BalancedParthesis();break;
                case 4: new PalindromeChecker();break;
                case 5: new HashFunction();break;
                case 6: new PrimeNumber2D();break;
                case 7: new Anagram();break;
                case 8: new PrimeAnagramInStack();break;
                case 9: new PrimeAnagramQueue();break;
                case 10: new Calender2DArray();break;
                case 11: new Demo();break;
                default:Console.WriteLine("Class Not Found....");break;
            }
        }
    }
}

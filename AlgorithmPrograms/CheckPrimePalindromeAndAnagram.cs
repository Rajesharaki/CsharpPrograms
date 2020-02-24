using System;
namespace CsharpPrograms.AlgorithmPrograms
{
    class CheckPrimePalindromeAndAnagram
    {
        public CheckPrimePalindromeAndAnagram()
        {
            PrintPrime();
        }
     static void PrintPrime()
        {
            Utility u = new Utility();
            Console.WriteLine("Enter the range: ");
            Console.Write("Enter First range value: ");
            int Low = u.ReadInt();
            Console.Write("Enter the Second range value: ");
            int High = u.ReadInt();
         //If Low is greater than high then swapp
            if (Low > High)
            {
              
                int temp = Low;
                Low = High;
                High = temp;
            }

            for (int i = Low; i <= High; i++)
            {
                if (IsPrime(i))  //check Paindrome
                {
                    if (i >= 100) // Enter If Prime number is more than 100
                    {
                        if (Palindrome(i)) //check Prime number is palindrome or not  if false then enter
                        {
                            int num = MakePali(i); //Make palindrome
                            if (IsPrime(num)) // check palindrome is prime or not
                            {
                                Console.WriteLine("'" + i + "' and " + "'" + num + "'  both are prime Number along with Palindrome and anagram number.....");
                            }
                        }
                    }
                }
            }
        }
        // Check Prime
        static bool IsPrime(int num)
        {
            bool flag = true;
            for(int i = 2; i <= num / 2; i++)
            {
                if (num % i == 0)
                {
                    flag = false;
                }
            }
            return flag;
        }
        // Make string
        static int MakePali(int num)
        {
            int temp = num, j = 0;
            int count = Count(num);
            int[] a = new int[count];
            while (temp != 0)
            {
                int rem = temp % 10;
                a[j] = rem;
                temp /= 10;
                j++;
            }
            Array.Sort(a);
            if (a.Length < 4)
            {
                int[] b = new int[count]; int n = a.Length - 1;
                //Make palindrome
                for (int i = 0; i < a.Length / 2; i++)
                {
                    if (a[i] == a[i + 1])
                    {
                        b[a.Length - 1 - i] = a[i + 1];
                        b[i] = a[i];
                    }
                    b[i + 1] = a[a.Length - 1];
                    i++;
                }
                //Fetching array values
                string st = "";
                for (int k = 0; k < b.Length; k++)
                {
                    st += b[k];
                }
                return int.Parse(st);
            }
            return 4; 
        }
        //Count digit
        static int Count(int num)
        {
            int count = 0;
            while (num != 0)
            {
                num /= 10;
                count++;
            }
            return count;
        }
        //check palindrome
        static bool Palindrome(int num)
        {
            int temp = num;
            int sum = 0;
            while (num != 0)
            {
                int rem = num % 10;
                sum = sum * 10 + rem;
                num /= 10;
            }
            if (temp == sum)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}



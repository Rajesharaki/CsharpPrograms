using System;
using System.Collections.Generic;
using System.Text;

namespace CsharpPrograms.JUnitTestingPrograms
{
    class ToBinary
    {
        public ToBinary()
        {
            Show();
        }
        static void Show()
        {
            Utility u = new Utility();
            Console.Write("Enter the number: ");
            int num = u.ReadInt();
            int temp = num;
            string st = " ";
            while (num !=0)
            {
                int rem=num % 2;
                st= rem+st;
                num /= 2;
            }
            Console.WriteLine(temp + " Binary value is: " + st);
        }
    }
}

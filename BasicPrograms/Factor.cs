using System;
using System.Collections.Generic;
using System.Text;

namespace CsharpPrograms.BasicPrograms
{
    class Factor
    {
        public Factor()
        {
            IsFactor();
        }
        static void IsFactor()
        {
            Utility u = new Utility();
            Console.Write("Enter the Number: ");
            int num = u.ReadInt();
            for(int i=2;i<=num;i++)
            {
                while(num%2==0)
                {
                    Console.Write(i+" ");
                    num /= 2;
                }
                if(num>0)
                {
                    Console.WriteLine(num);
                }
            }
        }
    }
}

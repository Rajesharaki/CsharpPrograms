using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructurePrograms
{
    class BalancedParthesis
    {
        public BalancedParthesis()
        {
           if(Check())
            {
                Console.WriteLine("Entered Expression is Balanced......");      
            }
            else
            {
                Console.WriteLine("Entered Expression is not Balanced......");
            }
        }

        static bool Check()
        {
            Console.Write("Enter the arthametic Expression: ");
            String exp = Console.ReadLine();
            Stack<char> list = new Stack<char>(exp.Length);
            for(int i = 0; i < exp.Length; i++)
            {
                char ch = exp[i];
                if (ch == '(' || ch == '[' || ch == '{')
                {

                    list.Push(ch);
                }
                else if (ch == ')' || ch == ']' || ch == '}')
                {
                    if (list.IsEmpty())
                    {
                        return false;
                    }
                    else
                    {
                        char c = list.Pop();
                        if(ch==')'&&c!='('|| ch == ']' && c != '[' ||ch == '}' && c != '{')
                        {
                            return false;
                        }
                    }
                }
            }
            return list.IsEmpty();

        }
    }
}

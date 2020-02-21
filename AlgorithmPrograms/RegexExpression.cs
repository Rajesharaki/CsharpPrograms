using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace CsharpPrograms.AlgorithmPrograms
{
    class RegexExpression
    {
        public RegexExpression()
        {
            Validation();
        }
        static void Validation()
        {
            Console.Write("FirstName: ");
            String FirstName = Console.ReadLine();
            Regex FN = new Regex(@"^[A-Z]{1}[a-z]*$");
            while (true)
            {
                if (FN.IsMatch(FirstName))
                {
                    break;
                }
                else
                {
                    Console.Write("Enterd Word not matched pattern Enter again....");
                    FirstName = Console.ReadLine();
                }
            }
            Console.Write("Lastname: ");
            string LastName = Console.ReadLine();
            Regex LN = new Regex(@"^[A-Za-z\s]*$");
            while (true)
            {
                if (LN.IsMatch(LastName))
                {
                    break;
                }
                else
                {
                    Console.Write("Enterd Word not matched pattern Enter again....");
                    LastName = Console.ReadLine();

                }
            }
            String FullName = FirstName+" " + LastName;
            Console.Write("Mobile number: ");
            String MobileNo = Console.ReadLine();
            Regex MN = new Regex(@"^(\+?)(91)?\s?[6-9]{1}[0-9]{9}$");
            while (true)
            {
                if (MN.IsMatch(MobileNo))
                {
                    break;
                }
                else
                {
                    Console.Write("Entered Number is Not matched pattern.... Enter again.......");
                    MobileNo = Console.ReadLine();
                }
            }
            Console.Write("Date: ");
            String date = Console.ReadLine();
            Regex d = new Regex(@"^[0-9]{1,2}/{1}[0-9]{1,2}/[0-9]{4}$");
            while (true)
            {
                if (d.IsMatch(date))
                {
                    break;
                }
                else
                {
                    Console.Write("Entered Number is Not matched pattern.... Enter again.......");
                    date = Console.ReadLine();
                }
            }
            Console.WriteLine("Hello '" + FirstName + "' ,\nWe have your full name as '" + FullName + "' in our system.\nyour Contact number is '" + MobileNo + "' \n" +
                "Please,Let us know in case of any clarification.\n" +
                "Thank you BridgeLabz '" + date + "'.");
        }
    }
}

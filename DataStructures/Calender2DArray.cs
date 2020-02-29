using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructurePrograms
{
    class Calender2DArray
    {
        public Calender2DArray()
        {
            Console.Write("Enter the Month: ");
            int m = int.Parse(Console.ReadLine());
            Console.Write("Enter the Year: ");
            int y = int.Parse(Console.ReadLine());
            int day=DayOfWeek(m, y);
            Console.Clear();
            DisplayCalender(day,y,m);

        }
        static int DayOfWeek(int m,int y)
        {
            int d = 1;
            int y0 = y - (14 - m) / 12;
            int x = y0 + y0 / 4 - y0 / 100 + y0 / 400;
            int m0 = m + 12 * ((14 - m) / 12) - 2;
            int d0 = (d + x + 31 * m0 / 12) % 7;
            return d0;
        }
        static void DisplayCalender(int day,int year,int m)
        {
            String[] b = { " ", "Jan", "Feb", "March", "April", "May", "June", "July", "August", "Sep", "Oct", "Nov", "Dec" };
            Console.WriteLine(b[m] + "  " + year);
            Console.WriteLine("__________________________________________________________________________________________________");
            String[] days = { " S ", " M ", " T ", " W ", " Th ", " F ", "S " };
            for(int i = 0; i < days.Length; i++)
            {
                Console.Write(days[i]);
            }
            Console.WriteLine();
            int[] Month = { 0, 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
            if (year % 400 == 0 || year % 4 == 0 && year % 100 != 0)
            {
                Month[2] = 29;
            }
            int[,] a = new int[5, 7];
            int k = 1, l = 0;
            for(int i = 0; i < a.GetLength(0); i++)
            {
                for(int j = 0; j < a.GetLength(1); j++)
                {
                    if (l == 0)
                    {
                        while (j < day)
                        {
                            Console.Write("   ");
                            j++;
                            l++;
                        }
                    }
                    if (k <= Month[m])
                    {
                        if (k < 10)
                        {
                            Console.Write(" " + (k++)+" ");
                        }
                        else
                        {
                            Console.Write((k++) + " ");
                        }
                    }
                }
                Console.WriteLine();
            }
        }
    }
}

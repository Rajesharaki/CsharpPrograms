using System;
using System.Collections.Generic;
using System.Text;

namespace CsharpPrograms.LogicalPrograms
{
    class TicTacGameByUsingOneDArray
    {
        public TicTacGameByUsingOneDArray()
        {
            PlayGame();
        }
        static void PlayGame()
        {
            Utility u = new Utility();
            char[] a = new char[12];
            for (int i = 1; i < 10; i++)
            {
                a[i] = '_';
            }
            DisplayBoard(a);
            int k = 0;
            while (k<1)
            {
                int j = 0;
                while (j <= 5)
                {
                    Console.WriteLine("'X' turn.....");
                    Console.Write("Enter the position: ");
                    int Position = u.ReadInt();
                    while (true)
                    {
                        if (a[Position] == '_')
                        {
                            a[Position] = 'X';
                            break;
                        }
                        else
                        {
                            Console.WriteLine(Position + " th position already entered.....'X' player Enter the position again......... ");
                            Position = u.ReadInt();
                        }
                    }
                    Console.Clear();
                    DisplayBoard(a);
                    CheckWin(a);
                    if (j == 4) { break; }
                    Console.WriteLine("'O' turn.....");
                    Console.Write("Enter the position: ");
                    int Pos = u.ReadInt();
                    while (true)
                    {
                        if (a[Pos] == '_')
                        {
                            a[Pos] = 'O';
                            break;
                        }
                        else
                        {
                            Console.WriteLine(Position + " th position already entered.....'O' player Enter the position again......... ");
                            Pos = u.ReadInt();
                        }
                    }
                    Console.Clear();
                    DisplayBoard(a);
                    CheckWin(a);
                    j++;
                }
                Console.WriteLine("Match Tie..........");
            }
        }
        static void DisplayBoard(char[] a)
        {
            Console.WriteLine( "|" + a[1] + "|" + a[2] + "|"+a[3]+"|" );
            Console.WriteLine( "|" + a[4] + "|" + a[5] + "|"+a[6]+"|");
            Console.WriteLine( "|" + a[7] + "|" + a[8] + "|"+a[9]+"|" );
        }
        static void CheckWin(char[] a)
        {
            String XR1 ="" + a[1] + a[2] + a[3];
            String XR2 ="" + a[4] + a[5] + a[6];
            String XR3 ="" + a[7] + a[8] + a[9];
            String Xd1 ="" + a[1] + a[5] + a[9];
            String Xd2 =""  + a[3] + a[5] + a[7];
            if (XR1=="XXX"||XR2=="XXX"||XR3=="XXX"||Xd1=="XXX"||Xd2=="XXX")
            {
                Console.WriteLine("'X' Player Won.......");
                Environment.Exit(0);
            }
            String R1 = "" + a[1] + a[2] + a[3];
            String R2 = "" + a[4] + a[5] + a[6];
            String R3 = "" + a[7] + a[8] + a[9];
            String d1 = "" + a[1] + a[5] + a[9];
            String d2 = "" + a[3] + a[5] + a[7];
            if (R1 == "OOO" || R2 == "OOO" || R3 == "OOO" || d1 == "OOO" || d2 == "OOO")
            {
                Console.WriteLine("'O' Player Won.......");
                Environment.Exit(0);
            }
        }

    }
}

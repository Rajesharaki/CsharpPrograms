using System;
using System.Collections.Generic;
using System.Text;

namespace CsharpPrograms.LogicalPrograms
{
    class TicTacGame
    {
        public TicTacGame()
        {
            Play();
        }
        static void Play()
        {
            char[,] dis= DisplayBoard();
            PlayGame(dis);
        }
        static char[,] DisplayBoard()
        {
            char[,] a = new char[4, 8];
            for (int i = 1; i <4; i++)
            {
                a[i, 0] = '|';
                for(int j=1;j<7;j++)
                {
                    a[i, j] = '_';
                    a[i, j + 1] = '|';
                    j++;
                }
            }
            for (int i = 1; i < 4; i++)
            {
                Console.Write(a[i, 0]);
                for (int j = 1; j < 7; j++)
                {
                    Console.Write(a[i, j]);
                    Console.Write(a[i, j + 1]);
                    j++;
                }
                Console.WriteLine();
            }
            return a;
        }
        static void PlayGame(char[,] dis)
        {
            int k = 1;
            while (k<=5)
            {
                Utility u = new Utility();
                Console.WriteLine("Player 'X' turn..... ");
                Console.Write("Enter the number: ");
                int num = u.ReadInt();
                int row = 0;
                int col = 0;
                while (true)
                {
                    if (num == 1 || num == 2 || num == 3)
                    {
                        row = 1; if (num == 1) { col = num; } else if (num == 2) { col = 3; } else { col = 5; } break;
                    }
                    else if (num == 4 || num == 5 || num == 6)
                    {
                        row = 2; if (num == 4) { col = 1; } else if (num == 5) { col = 3; } else { col = 5; }break;
                    }
                    else if (num == 7 || num == 8 || num == 9)
                    {
                        row = 3; if (num == 7) { col = 1; } else if (num == 8) { col = 3; } else { col = 5; }break;
                    }
                    else
                    {
                        Console.Write("Enter vaild number");
                        num = u.ReadInt();
                    }
                }
                while (true)
                { 
                    if (dis[row, col] == '_')
                    {
                        dis[row, col] = 'X';
                        break;
                    }
                    else
                    {
                        Console.WriteLine("This Place is already filled Enter Again......");
                        Console.WriteLine("Player 'X' turn..... ");
                        Console.Write("Enter the number: ");
                        num = u.ReadInt();
                        row = 0;
                        col = 0;
                        while (true)
                        {
                            if (num == 1 || num == 2 || num == 3)
                            {
                                row = 1; if (num == 1) { col = num; } else if (num == 2) { col = 3; } else { col = 5; }
                                break;
                            }
                            else if (num == 4 || num == 5 || num == 6)
                            {
                                row = 2; if (num == 4) { col = 1; } else if (num == 5) { col = 3; } else { col = 5; }
                                break;
                            }
                            else if (num == 7 || num == 8 || num == 9)
                            {
                                row = 3; if (num == 7) { col = 1; } else if (num == 8) { col = 3; } else { col = 5; }
                                break;
                            }
                            else
                            {
                                Console.Write("Enter vaild number");
                                num = u.ReadInt();
                            }
                        }

                    } 
                }
                Console.Clear();
                //display Board x 
                for (int i = 1; i < 4; i++)
                {
                    Console.Write(dis[i, 0]);
                    for (int j = 1; j < 7; j++)
                    {
                        Console.Write(dis[i, j]);
                        Console.Write(dis[i, j + 1]);
                        j++;
                    }
                    Console.WriteLine();
                }
                CheckWin(dis);
                if (k == 5)
                {
                    break;
                }
                Console.WriteLine("Player 'O'turn.....");
                Console.Write("Enter the number: ");
                int n = u.ReadInt();
                int r = 0;
                int c = 0;
                while (true)
                {
                    if (n == 1 || n == 2 || n == 3)
                    {
                        r = 1; if (n == 1) { c = n; } else if (n == 2) { c = 3; } else { c = 5; }
                        break;
                    }
                    else if (n == 4 || n == 5 || n == 6)
                    {
                        r = 2; if (n == 4) { c = 1; } else if (n == 5) { c = 3; } else { c = 5; }
                        break;
                    }
                    else if (n == 7 || n == 8 || n == 9)
                    {
                        r = 3; if (n == 7) { c = 1; } else if (n == 8) { c = 3; } else { c = 5; }
                        break;
                    }
                    else
                    {
                        Console.Write("Enter vaild number");
                        n = u.ReadInt();
                    }
                }
                while (true)
                {
                    if (dis[r, c] == '_')
                    {
                        dis[r, c] = 'O';
                        break;
                    }
                    else
                    {
                        Console.WriteLine("This Place is already filled Enter Again......");
                        Console.WriteLine("Player 'O' turn..... ");
                        Console.Write("Enter the number: ");
                         n = u.ReadInt();
                         r = 0;
                         c = 0;
                        while (true)
                        {
                            if (n == 1 || n == 2 || n == 3)
                            {
                                r = 1; if (n == 1) { c = n; } else if (n == 2) { c = 3; } else { c = 5; }
                                break;
                            }
                            else if (n == 4 || n == 5 || n == 6)
                            {
                                r = 2; if (n == 4) { c = 1; } else if (n == 5) { c = 3; } else { c = 5; }
                                break;
                            }
                            else if (n == 7 || n == 8 || n == 9)
                            {
                                r = 3; if (n == 7) { c = 1; } else if (n == 8) { c = 3; } else { c = 5; }
                                break;
                            }
                            else
                            {
                                Console.Write("Enter vaild number");
                                n = u.ReadInt();
                            }
                        }
                    }
                }
                Console.Clear();
                ///displayBoard O
                for (int i = 1; i < 4; i++)
                {
                    Console.Write(dis[i, 0]);
                    for (int j = 1; j < 7; j++)
                    {
                        Console.Write(dis[i, j]);
                        Console.Write(dis[i, j + 1]);
                        j++;
                    }
                    Console.WriteLine();
                }
                CheckWin(dis);
                k++;
            }
            CheckTie();
        }
            static void CheckWin(char[,] a)
            {
                string xh1 = "" + a[1, 1] + a[1, 3] + a[1, 5];
                string xh2 = "" + a[2, 1] + a[2, 3] + a[2, 5]; 
            string xh3 = "" + a[3, 1] + a[3, 3] + a[3, 5]; 
            string xv1 = "" + a[1, 1] + a[2, 1] + a[3, 1]; 
            string xv2 = "" + a[1, 2] + a[2, 2] + a[3, 2]; 
            string xv3 = "" + a[1, 3] + a[2, 3] + a[3, 3]; 
            string vd1 = "" + a[1, 1] + a[2, 3] + a[3, 5];
            string vd2 = "" + a[1, 5] + a[2, 3] + a[3, 1];
            if (xh1=="XXX"||xh2=="XXX"|| xh3 == "XXX" || xv1 == "XXX"||xv2 == "XXX" || xv3 == "XXX" || vd1 == "XXX"||vd2=="XXX")
                {
                    Console.WriteLine("Player 'X' Won...............");
                    System.Environment.Exit(0);
                }
                string h1 = "" + a[1, 1] + a[1, 3] + a[1, 5];
                string h2 = "" + a[2, 1] + a[2, 3] + a[2, 5];
                string h3 = "" + a[3, 1] + a[3, 3] + a[3, 5];
                string v1 = "" + a[1, 1] + a[2, 1] + a[3, 1];
                string v2 = "" + a[1, 2] + a[2, 2] + a[3, 2];
                string v3 = "" + a[1, 3] + a[2, 3] + a[3, 3];
                string d1 = "" + a[1, 1] + a[2, 3] + a[3, 5];
                string d2 = "" + a[1, 5] + a[2, 3] + a[3, 1];
                if (h1 == "OOO" || h2 == "OOO" || h3 == "OOO" || v1 == "OOO" || v2 == "OOO" || xv3 == "OOO"||d1=="O"||d2=="OOO")
                {
                    Console.WriteLine("Player 'O' Won...............");
                    System.Environment.Exit(0);
                }
            }
        static void CheckTie()
        {
            Console.WriteLine("Match Tie........................");
        }
    }
}

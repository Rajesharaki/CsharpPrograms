using System;
using System.Diagnostics;
using System.Threading;

namespace CsharpPrograms.LogicalPrograms
{
    class StopWatch
    {
      public StopWatch()
        {
            EalpsedTime();
        }
        static void EalpsedTime()
        {
            Stopwatch timer = new Stopwatch();
            Console.WriteLine("to start stopwatch press 's'//to close press c");
            char s=char.Parse(Console.ReadLine());
            if (s == 's' || s == 'S')
            {
                Console.WriteLine("stopwatch started... to close press c");
                timer.Start();
                    char c = char.Parse(Console.ReadLine());
                    if (c == 'c' || c == 'C')
                    {
                        Console.WriteLine("StopWatch closed");
                        timer.Stop();
                        Console.WriteLine("Elapsed time: " + timer.Elapsed);
                        System.Environment.Exit(0);
                    }
                
            }
        }
    }
}

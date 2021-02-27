using System;
using System.Threading;
using System.Timers;

namespace TimerSample
{
    class Program
    {

        static void Main(string[] args)
        {
            System.Timers.Timer timer = new System.Timers.Timer(1000);
            timer.Elapsed += DoIt;
            timer.Start();
            Console.WriteLine("main: " + Thread.CurrentThread.ManagedThreadId);
            Thread.Sleep(10000);
        }

        private static void DoIt(object sender, ElapsedEventArgs e)
        {
            Console.WriteLine("doit: " + Thread.CurrentThread.ManagedThreadId);

        }
    }
}

using System;
using System.Threading;

namespace TestApp
{
    class Program
    {
        static void DoIt()
        {
            Console.WriteLine("test");
            while (true)
            {
                Console.WriteLine("doit: " + Thread.CurrentThread.ManagedThreadId);
            }
        }
        static void Main(string[] args)
        {
            ThreadStart ts = new ThreadStart(DoIt);

            Thread t = new Thread(ts);

            
            while (true)
            {
                Console.WriteLine("main: " + Thread.CurrentThread.ManagedThreadId);
            }
        }
    }
}

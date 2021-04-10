using System;
using System.Threading;

namespace DelegateSample
{
    delegate int MyDelegate(int a, int b);

    class Calc
    {
        MyDelegate md;
        public Calc(MyDelegate md)
        {
            this.md = md;
        }

        public void DoIt()
        {
            foreach (var x in md.GetInvocationList())
            {
                Console.WriteLine(x.DynamicInvoke(2, 3));
            }
        }
    }
    class Program
    {
        static int apb(int a, int b)
        {
            return a + b;
        }

        static int amb(int a, int b)
        {
            return a - b;
        }

        static void Main(string[] args)
        {
            MyDelegate md = new MyDelegate(apb);
            md += amb;
            //DoIt(md);

            Calc c = new Calc(md);
            
            c.DoIt();

            Console.WriteLine("***");

            md -= amb;
            Calc c2 = new Calc(md);
            c2.DoIt();

        }

        static void DoIt(MyDelegate md)
        {
            Thread.Sleep(10000);
            Console.WriteLine(md.Invoke(2, 3));
        }
    }
}

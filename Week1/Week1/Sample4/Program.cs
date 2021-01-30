using System;

namespace Sample4
{
    class Student
    {
        protected void DoIt()
        {
            Console.WriteLine("done!");
        }

        public virtual string DoItX()
        {
            return "X";
        }
    }

    class SubStudent : Student
    {
        public void DoIt2()
        {
            DoIt();
        }

        public override string DoItX()
        {
            return "SSX";
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            SubStudent ss = new SubStudent();
            Console.WriteLine(ss.DoItX());
        }
    }
}

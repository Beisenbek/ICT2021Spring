using System;

namespace TestApp
{
    class Student
    {

        public string name;
        public string aname;

        public override string ToString()
        {
            return name + " " + aname;
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            Student s = new Student();
            s.aname = "Smith";
            s.name = "Bob";

            Console.WriteLine(s);
        }
    }
}

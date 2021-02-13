using System;

namespace Example1
{

    //public fields
    class Student 
    {
        public string name;
        public double gpa;
    }


    //private fields + public getters and setters
    class Student2
    {
        string name;
        double gpa;

        public void SetName(string name)
        {
            this.name = name;
        }

        public void SetGPA(double gpa)
        {
            if (gpa > 0)
            {
                this.gpa = gpa;
            }
        }

        public string GetName()
        {
            return name;
        }

        public double GetGPA()
        {
            return gpa;
        }
    }

    //public properties
    class Student3
    {
        public string Name { get; set; }

        double gpa;
        public double Gpa 
        {
            set
            {
                if (value > 0)
                {
                    gpa = value;
                }
            }
            get
            {
                return gpa;
            }
        }

        public override string ToString()
        {
            return Name + " " + gpa;
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            F4();
        }

        static void F4()
        {
            Student3 s = new Student3 { Gpa = 3.5, Name = "John" };
            Console.WriteLine(s);
        }


        static void F3()
        {
            Student3 s = new Student3();
            s.Gpa = -4;
            s.Name = "Bob";
            Console.WriteLine(s);
        }

        static void F2()
        {
            Student2 s = new Student2();
            s.SetGPA(3);
            s.SetName("BOb");

            s.SetGPA(-20);
            Console.WriteLine(s.GetGPA());
        }
        static void F1()
        {
            Student s = new Student();
            s.gpa = 3;
            s.name = "Bob";

            s.gpa = 2;
            Console.WriteLine(s.gpa);
        }
    }


}

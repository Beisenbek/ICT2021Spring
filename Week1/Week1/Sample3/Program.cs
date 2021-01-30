using System;
using Y;

namespace X
{
    class Student
    {
        public string name;
        public string surname;
        public double gpa;

        public override string ToString()
        {
            return string.Format("{0} {1} {2}", name, surname, gpa);
        }

    }
}


namespace Y
{
    class Student
    {
        public string name;
        public string surname;
        public double gpa;

        public override string ToString()
        {
            //return string.Format("{0} {1} {2}", gpa, name, surname);
            return $"{name} {surname}:{gpa}";
            //return $"{name} {surname}: {gpa}";
        }
    }
}

namespace Sample3
{

    class Program
    {
        static void Main(string[] args)
        {
            Student student = new Student();
            student.name = "A";
            student.surname = "B";
            student.gpa = 23;

            Console.WriteLine(student);

        }
    }
}

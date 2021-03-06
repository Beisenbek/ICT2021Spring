using System;
using System.Collections.Generic;
using System.Text;

namespace CloningSample
{

    class Student : ICloneable
    {
        public string Name { get; set; }
        public double GPA { get; set; }

        public object Clone()
        {
            return this;
        }

        public override string ToString()
        {
            return Name + " " + GPA;
        }
    }

    class Faculty
    {
        public List<Student> Students { get; set; }
        public string Title { get; set; }
        public Faculty(string title)
        {
            Students = new List<Student>();
            Title = title;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(Title + ":");
            foreach (var s in Students)
            {
                sb.AppendLine(s.ToString());
            }
            return sb.ToString();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Faculty f = new Faculty("FIT");

            Student s1 = new Student { Name = "Bob", GPA = 3.5 };
            Student s2 = new Student { Name = "John", GPA = 2.5 };
            Student s3 = s1.Clone() as Student;

            f.Students.Add(s1);
            f.Students.Add(s2);
            f.Students.Add(s3);

            s1.GPA = 3.7;

            Console.WriteLine(f);

        }
    }
}

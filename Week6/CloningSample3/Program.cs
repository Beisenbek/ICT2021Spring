using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace CloningSample3
{
    public class Student
    {
        public string Name { get; set; }
        public double GPA { get; set; }

        public override string ToString()
        {
            return Name + " " + GPA;
        }

        public Student DeepClone()
        {
            Student res = null;
            //deep cloning

            using (MemoryStream ms = new MemoryStream())
            {
                XmlSerializer xs = new XmlSerializer(typeof(Student));
                xs.Serialize(ms, this);
                ms.Seek(0, SeekOrigin.Begin);
                res = xs.Deserialize(ms) as Student;
            }

            return res;
        }
    }

    public class Faculty
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
            Student s3 = s1.DeepClone();

            f.Students.Add(s1);
            f.Students.Add(s2);
            f.Students.Add(s3);

            s1.GPA = 4.0;

            Console.WriteLine(f);


        }
    }
}

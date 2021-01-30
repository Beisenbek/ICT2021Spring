using System;

namespace Sample6
{
    class Program
    {
        static void Main(string[] args)
        {
            string line = Console.ReadLine();
            string[] parts = line.Split(' ');
            int sum = 0;
            for(int i = 0; i < parts.Length; ++i)
            {
                sum += int.Parse(parts[i]);
            }
            Console.WriteLine(sum);
        }
    }
}

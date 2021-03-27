using System;

namespace Example3
{
    class Program
    {
        static void Main(string[] args)
        {
            DisplayMessage d = new DisplayMessage(SetText);
            Brain brain = new Brain(d);
            while (true)
            {
                string line = Console.ReadLine();
                brain.ProcessSignal(line);
            }
        }

        static void SetText(string msg)
        {
            Console.WriteLine(msg);
        }
    }
}

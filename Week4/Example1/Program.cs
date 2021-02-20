using System;
using System.Collections.Generic;

namespace Example1
{
    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();

            while (game.IsRunning)
            {
                game.KeyPressed(Console.ReadKey());
            }
        }
    }
}

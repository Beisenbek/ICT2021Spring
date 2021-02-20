using System;
using System.Collections.Generic;
using System.Text;

namespace Example1
{
    class Game
    {

        public static int Width { get { return 40; } }
        public static int Height { get { return 40; } }

        Worm w = new Worm('@', ConsoleColor.Green);
        Food f = new Food('$', ConsoleColor.Yellow);
        Wall wall = new Wall('#', ConsoleColor.DarkYellow, @"Levels/Level2.txt");

        public bool IsRunning { get; set; }
        public Game()
        {
            IsRunning = true;
            Console.CursorVisible = false;
            Console.SetWindowSize(Width, Width);
            Console.SetBufferSize(Width, Width);
        }

        bool CheckCollisionFoodWithWorm()
        {
            return w.body[0].X == f.body[0].X && w.body[0].Y == f.body[0].Y;
        }

        public void KeyPressed(ConsoleKeyInfo pressedKey)
        {
            switch (pressedKey.Key)
            {
                case ConsoleKey.UpArrow:
                    w.Move(0, -1);
                    break;
                case ConsoleKey.DownArrow:
                    w.Move(0, 1);
                    break;
                case ConsoleKey.LeftArrow:
                    w.Move(-1, 0);
                    break;
                case ConsoleKey.RightArrow:
                    w.Move(1, 0);
                    break;
                case ConsoleKey.Escape:
                    IsRunning = false;
                    break;
            }
            if (CheckCollisionFoodWithWorm())
            {
                w.Increase(w.body[0]);
                f.Generate();
            }
        }

    }
}

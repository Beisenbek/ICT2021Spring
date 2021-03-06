using System;
using System.Collections.Generic;
using System.Text;
using System.Timers;

namespace SnakeWithTimer
{
    class Game
    {
        Timer wormTimer = new Timer(100);
        Timer gameTimer = new Timer(1000);

        public static int Width { get { return 40; } }
        public static int Height { get { return 40; } }

        Worm w = new Worm('@', ConsoleColor.Green);
        Food f = new Food('$', ConsoleColor.Yellow);
        Wall wall = new Wall('#', ConsoleColor.DarkYellow, @"Levels/Level2.txt");

        public bool IsRunning { get; set; }

        bool pause = false;

        public Game()
        {
            gameTimer.Elapsed += GameTimer_Elapsed;
            gameTimer.Start();
            wormTimer.Elapsed += Move2;
            wormTimer.Start();

            pause = false;
            IsRunning = true;
            Console.CursorVisible = false;
            Console.SetWindowSize(Width, Width);
            Console.SetBufferSize(Width, Width);
        }

        private void GameTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            Console.Title = DateTime.Now.ToLongTimeString();
        }

        bool CheckCollisionFoodWithWorm()
        {
            return w.body[0].X == f.body[0].X && w.body[0].Y == f.body[0].Y;
        }

        void Move2(object sender, ElapsedEventArgs e)
        {
            w.Move();
            if (CheckCollisionFoodWithWorm())
            {
                w.Increase(w.body[0]);
                f.Generate();
            }
        }

        public void KeyPressed(ConsoleKeyInfo pressedKey)
        {
            switch (pressedKey.Key)
            {
                case ConsoleKey.UpArrow:
                    w.ChangeDirection(0, -1);
                    break;
                case ConsoleKey.DownArrow:
                    w.ChangeDirection(0, 1);
                    break;
                case ConsoleKey.LeftArrow:
                    w.ChangeDirection(-1, 0);
                    break; 
                case ConsoleKey.RightArrow:
                    w.ChangeDirection(1, 0);
                    break;
                case ConsoleKey.S:
                    w.Save("worm");
                    break;
                case ConsoleKey.L:
                    wormTimer.Stop();
                    w.Clear();
                    f = new Food('$', ConsoleColor.Yellow);
                    wall = new Wall('#', ConsoleColor.DarkYellow, @"Levels/Level2.txt");
                    w = Worm.Load("worm");
                    wormTimer.Start();
                    break;
                case ConsoleKey.Escape:
                    IsRunning = false;
                   // wormTimer.Stop();
                    break;
                case ConsoleKey.Spacebar:
                    if (!pause)
                    {
                        wormTimer.Stop();
                        pause = true;
                    }
                    else
                    {
                        wormTimer.Start();
                        pause = false;
                    }
                    break;
            }
            
        }

    }
}

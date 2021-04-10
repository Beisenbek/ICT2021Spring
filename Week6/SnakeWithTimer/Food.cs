using System;
using System.Collections.Generic;
using System.Text;

namespace SnakeWithTimer
{
    class Food : GameObject
    {
        Random rnd = new Random();
        public Food(char sign, ConsoleColor color) : base(sign, color)
        {
            Point location = new Point { X = rnd.Next(1, Game.Width), Y = rnd.Next(1, Game.Height) };
            body.Add(location);
            Draw();
        }
        public void Generate()
        {
            body[0].X = rnd.Next(1, 39);
            body[0].Y = rnd.Next(1, 39);
            Draw();
        }
    }
}

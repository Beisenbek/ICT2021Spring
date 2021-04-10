using System;
using System.Collections.Generic;
using System.Text;

namespace SnakeWithTimer
{
    abstract class GameObject
    {
        protected char sign;
        protected ConsoleColor color;
        public List<Point> body;
        public GameObject(char sign, ConsoleColor color)
        {
            this.sign = sign;
            this.color = color;
            this.body = new List<Point>();
        }
        protected void Draw()
        {
            Console.ForegroundColor = color;
            for (int i = 0; i < body.Count; ++i)
            {
                Console.SetCursorPosition(body[i].X, body[i].Y);
                Console.Write(sign);
            }
        }
        protected void Clear()
        {
            for (int i = 0; i < body.Count; ++i)
            {
                Console.SetCursorPosition(body[i].X, body[i].Y);
                Console.Write(' ');
            }
        }
    }
}

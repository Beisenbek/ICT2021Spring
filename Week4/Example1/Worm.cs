using System;
using System.Collections.Generic;
using System.Text;

namespace Example1
{
    class Worm : GameObject
    {
        public Worm(char sign, ConsoleColor color) : base(sign, color)
        {
            Point head = new Point { X = 20, Y = 20 };
            body.Add(head);
            Draw();
        }
        public void Move(int dx, int dy)
        {
            Clear();

            for (int i = body.Count - 1; i > 0; --i)
            {
                body[i].X = body[i - 1].X;
                body[i].Y = body[i - 1].Y;
            }

            body[0].X += dx;
            body[0].Y += dy;

            Draw();
        }
        public void Increase(Point point)
        {
            body.Add(new Point { X = point.X, Y = point.Y });
        }
    }
}

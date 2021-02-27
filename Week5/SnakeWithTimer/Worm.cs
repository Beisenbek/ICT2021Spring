using System;
using System.Collections.Generic;
using System.Text;
using System.Timers;

namespace SnakeWithTimer
{
    class Worm : GameObject
    {
        public int Dx { get; set; }
        public int Dy { get; set; }

        public Worm(char sign, ConsoleColor color) : base(sign, color)
        {
            Point head = new Point { X = 20, Y = 20 };
            body.Add(head);
            Draw();
        }

        public void ChangeDirection(int dx, int dy)
        {
            Dx = dx;
            Dy = dy;
        }
        public void Move()
        {
            Clear();

            for (int i = body.Count - 1; i > 0; --i)
            {
                body[i].X = body[i - 1].X;
                body[i].Y = body[i - 1].Y;
            }

            body[0].X += Dx;
            body[0].Y += Dy;



            Draw();
        }
        public void Increase(Point point)
        {
            body.Add(new Point { X = point.X, Y = point.Y });
        }
    }
}

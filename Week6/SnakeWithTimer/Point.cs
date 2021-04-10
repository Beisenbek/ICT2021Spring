using System;
using System.Collections.Generic;
using System.Text;

namespace SnakeWithTimer
{
    public class Point
    {
        int x;
        int y;
        public int X
        {
            get
            {
                return x;
            }
            set
            {
                if (value < 0)
                {
                    x = Game.Width - 1;
                }
                else if (value >= Game.Width)
                {
                    x = 0;
                }
                else
                {
                    x = value;
                }
            }
        }
        public int Y
        {
            get
            {
                return y;
            }
            set
            {
                if (value < 0)
                {
                    y = Game.Height - 1;
                }
                else if (value >= Game.Height)
                {
                    y = 0;
                }
                else
                {
                    y = value;
                }
            }
        }
    }
}

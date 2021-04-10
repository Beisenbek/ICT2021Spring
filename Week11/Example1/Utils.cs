using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example1
{
    class Utils
    {
        static void Step(
            int x,
            int y,
            int w,
            int h,
            Bitmap bmp,
            Color originColor,
            Color fillColor,
            Queue<Point> q)
        {
            if (x >= 0 && y >= 0 && x < w && y < h)
            {
                if (bmp.GetPixel(x, y) == originColor)
                {
                    bmp.SetPixel(x, y, fillColor);
                    q.Enqueue(new Point(x, y));
                }
            }
        }
        public static Bitmap Fill(
            Bitmap bmp,
            Point originPoint,
            Color originColor,
            Color fillColor)
        {
            Queue<Point> q = new Queue<Point>();
            bmp.SetPixel(originPoint.X, originPoint.Y, fillColor);
            q.Enqueue(originPoint);
            while (q.Count > 0)
            {
                Point cur = q.Dequeue();
                Step(cur.X + 1, cur.Y, bmp.Width, bmp.Height, bmp, originColor, fillColor, q);
                Step(cur.X - 1, cur.Y, bmp.Width, bmp.Height, bmp, originColor, fillColor, q);
                Step(cur.X, cur.Y + 1, bmp.Width, bmp.Height, bmp, originColor, fillColor, q);
                Step(cur.X, cur.Y - 1, bmp.Width, bmp.Height, bmp, originColor, fillColor, q);
            }
            return bmp;
        }
    }
}

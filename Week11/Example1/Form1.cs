using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Example1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            gfx = Graphics.FromImage(bmp);
            pictureBox1.Image = bmp;
            gfx.Clear(Color.White);
        }

        bool isMouseDown = false;
        Point prevPoint = default(Point);
        Point currentPoint = default(Point);
        Graphics gfx = default(Graphics);
        Pen p = new Pen(Color.Black);
        //0 - pen, 1 - fill, 2 - gdi32 fill
        int currentTool = 0;
        Bitmap bmp = default(Bitmap);


        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
           
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            
        }



        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (isMouseDown)
            {
                if (currentTool == 0)
                {
                    prevPoint = currentPoint;
                    currentPoint = e.Location;
                    gfx.DrawLine(p, prevPoint, currentPoint);
                    pictureBox1.Refresh();
                }
            }
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            isMouseDown = true;
            currentPoint = e.Location;
            if (currentTool == 1)
            {
                currentPoint = e.Location;
                bmp = Utils.Fill(bmp, currentPoint, bmp.GetPixel(e.X, e.Y), Color.Blue);
                gfx = Graphics.FromImage(bmp);
                pictureBox1.Image = bmp;
                pictureBox1.Refresh();
            }
            else if (currentTool == 2)
            {
                MapFill mf = new MapFill();
                mf.Fill(gfx, currentPoint, Color.Red, ref bmp);
                gfx = Graphics.FromImage(bmp);
                pictureBox1.Image = bmp;
                pictureBox1.Refresh();
            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            isMouseDown = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            currentTool = 0;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            currentTool = 1;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            currentTool = 2;
        }
    }
}

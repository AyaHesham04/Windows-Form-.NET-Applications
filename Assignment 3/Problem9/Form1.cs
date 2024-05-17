using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Problem9
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            this.MouseDown += Form1_MouseDown;
            this.BackColor = Color.White;
        }

        int x1 = 0, y1 = 0, x2 = 0, y2 = 0;
        int ctClicks = 0;

        void DrawEllipse(int x, int y, int width, int height, int ctClicks)
        {
            Graphics g = this.CreateGraphics();
            if (ctClicks == 1)
            {
                g.Clear(Color.White);
            }

            SolidBrush brush = new SolidBrush(Color.Blue);
            g.FillEllipse(brush, x, y, width, height);

        }
        void DrawShape(int firstX, int firsty, int w, int h)
        {
            Graphics g = this.CreateGraphics();

            Pen P = new Pen(Color.Green);
            g.DrawRectangle(P, firstX, firsty, w, h);

            SolidBrush brush = new SolidBrush(Color.Green);
            g.FillRectangle(brush, firstX, firsty, w, h);
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            ctClicks++;
            if (ctClicks == 1)
            {
                x1 = e.X; 
                y1 = e.Y;
                DrawEllipse(x1, y1, 10, 10, 1);
            }

            if (ctClicks == 2)
            {
                x2 = e.X; 
                y2 = e.Y;

                int dx = x2 - x1;
                int dy = y2 - y1;

                if (dx < 0 && dy > 0)
                {
                    dx = x1 - x2;
                    DrawShape(x2, y1, dx, dy);
                }
                else if (dx < 0 && dy < 0)
                {
                    dx = x1 - x2;
                    dy = y1 - y2;
                    DrawShape(x2, y2, dx, dy);
                }
                else if (dx > 0 && dy < 0)
                {
                    dy = y1 - y2;
                    DrawShape(x1, y2, dx, dy);

                }
                else if (dx > 0 && dy > 0)
                {
                    DrawShape(x1, y1, dx, dy);
                }

                DrawEllipse(x2, y2, 10, 10, 2);
                ctClicks = 0;
            }
        }
    }
}

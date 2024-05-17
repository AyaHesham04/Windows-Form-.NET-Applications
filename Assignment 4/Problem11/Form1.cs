using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Problem11
{
    public partial class Form1 : Form
    {
        bool isDrag = false;
        int xOld = 0, yOld = 0, dx = 0, dy = 0;
        int draw = 0;

        public class CActor
        {
            public int X, Y;
            public int W, H;
            public Color cl;
        }

        List<CActor> Circles = new List<CActor> ();

        public Form1()
        {
            this.MouseDown += Form1_MouseDown;
            this.MouseUp += Form1_MouseUp;
            this.MouseMove += Form1_MouseMove;
            this.Paint += Form1_Paint;
            this.BackColor = Color.LightGray;
            this.KeyDown += Form1_KeyDown;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch(e.KeyCode)
            {
                case Keys.Space:
                    draw = 1;
                    DrawScene();
                    break;
            }
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            if (draw == 1)
            {
               DrawScene();
            }
        }

        private void DrawScene()
        {
            Graphics g = CreateGraphics();
            g.Clear(Color.LightGray);

            for (int i = 0; i < 4; i++)
            {
                CActor pnn = new CActor();
                pnn.X = 120 + 20 * i;
                pnn.W = 20;
                pnn.Y = 200;
                pnn.H = 20;
                pnn.cl = Color.RoyalBlue;
                Circles.Add(pnn);
                SolidBrush brush = new SolidBrush(pnn.cl);
                g.FillEllipse(brush, pnn.X + dx * i, pnn.Y + dy, pnn.W, pnn.H);
            }

            for (int i = 0; i < 4; i++)
            {
                CActor pnn = new CActor();
                pnn.X = 400 + 20 * i;
                pnn.W = 20;
                pnn.Y = 200;
                pnn.H = 20;
                pnn.cl = Color.RoyalBlue;
                Circles.Add(pnn);
                SolidBrush brush = new SolidBrush(pnn.cl);
                g.FillEllipse(brush, pnn.X + dx * i, pnn.Y + dy, pnn.W, pnn.H);
            }

            for (int i = 0; i < 8; i++)
            {
                CActor pnn = new CActor();
                pnn.X = 220 + 20 * i;
                pnn.W = 20;
                pnn.Y = 110;
                pnn.H = 20;
                pnn.cl = Color.LightPink;
                Circles.Add(pnn);
                SolidBrush brush = new SolidBrush(pnn.cl);
                g.FillEllipse(brush, pnn.X + dx * i, pnn.Y + dy, pnn.W, pnn.H);
            }

            for (int i = 0; i < 8; i++)
            {
                CActor pnn = new CActor();
                pnn.X = 220 + 20 * i;
                pnn.W = 20;
                pnn.Y = 280;
                pnn.H = 20;
                pnn.cl = Color.LightPink;
                Circles.Add(pnn);
                SolidBrush brush = new SolidBrush(pnn.cl);
                g.FillEllipse(brush, pnn.X + dx * i, pnn.Y + dy, pnn.W, pnn.H);
            }

        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            isDrag = false;
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDrag == true)
            {
                dx = e.X - xOld;
                dy = e.Y - yOld;

                Graphics g = CreateGraphics();
                g.Clear(Color.LightGray);

                for (int i = 0; i < Circles.Count; i++)
                {
                    Circles[i].X += dx;
                    Circles[i].Y += dy;
                    SolidBrush brush = new SolidBrush(Circles[i].cl);
                    g.FillEllipse(brush, Circles[i].X + dx * i, Circles[i].Y + dy, Circles[i].W, Circles[i].H);

                }

                xOld = e.X;
                yOld = e.Y;

            }
        }

       
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDrag = true;
                xOld = e.X;
                yOld = e.Y;

            }

        }
    }
}

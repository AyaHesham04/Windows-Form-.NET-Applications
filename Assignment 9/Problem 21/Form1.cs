using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Problem_21
{
    public partial class Form1 : Form
    {
        private class CActorImage
        {
            public int X, Y, W, H;
            public List<Bitmap> imgs;
            public int shrink;
            public int iFrame;
        }

        public Form1()
        {
            this.WindowState = FormWindowState.Maximized;
            this.Load += Form1_Load;
            this.Paint += Form1_Paint;
            this.MouseDown += Form1_MouseDown;

            tt.Interval = 100;
            tt.Start();
            tt.Tick += Tt_Tick;
        }

        Bitmap off;
        Timer tt = new Timer();
        List<CActorImage> LImages = new List<CActorImage>();
        int ctTick=0;
        private void Tt_Tick(object sender, EventArgs e)
        {
            if (ctTick % 10 == 0)
            {
                CreateImage();
            }

            for (int i = 0; i < LImages.Count; i++)
            {
                if (LImages[i].shrink == 1 && LImages[i].W > 0 && LImages[i].H > 0)
                {
                    LImages[i].W -= 3;
                    LImages[i].H -= 3;
                    if (LImages[i].W <= 0 || LImages[i].H <= 0)
                    {
                        LImages.RemoveAt(i);
                    }
                }

            }

            ctTick++;

            DrawDubb(this.CreateGraphics());
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                for (int i = 0; i < LImages.Count; i++)
                {
                    if (e.X >= LImages[i].X && e.X <= LImages[i].X + 50 && e.Y >= LImages[i].Y && e.Y <= LImages[i].Y + 50)
                    {
                        LImages[i].iFrame = 1;
                        LImages[i].shrink = 1;
                        DrawDubb(this.CreateGraphics());
                        break;
                    }
                }
            }

        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            DrawDubb(this.CreateGraphics());
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            off = new Bitmap(this.ClientSize.Width, this.ClientSize.Height);
        }
        
        void CreateImage()
        {
            Random rr = new Random();
            CActorImage pnn=new CActorImage();
            pnn.X = rr.Next(50,this.ClientSize.Width - 50);
            pnn.Y = rr.Next(50, this.ClientSize.Height - 50);
            pnn.W = 50;
            pnn.H = 50;
            pnn.imgs = new List<Bitmap>();
            for (int i = 0; i < 2; i++)
            {
                Bitmap im = new Bitmap("image_" + (i + 1) + ".bmp");
                pnn.imgs.Add(im);
            }
            pnn.iFrame = 0;
            pnn.shrink = 0;
            LImages.Add(pnn);
        }
        void DrawScene(Graphics g)
        {
            g.Clear(Color.Black);

            for (int i = 0; i < LImages.Count; i++)
            {
                g.DrawImage(LImages[i].imgs[LImages[i].iFrame], LImages[i].X, LImages[i].Y, LImages[i].W, LImages[i].H);
            }
        }

        private void DrawDubb(Graphics g)
        {
            Graphics g2 = Graphics.FromImage(off);
            DrawScene(g2);
            g.DrawImage(off, 0, 0); 
        }
    }
}

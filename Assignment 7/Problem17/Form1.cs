using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Problem17
{
    public partial class Form1 : Form
    {
        public class CActorRocket
        {
            public int X, Y;
            public bool isAcceleration;
            public int dir;
            public Bitmap im;

        }

        public class CActorLaser
        {
            public int X1, Y1, X2, Y2;
            public int visible;
        }
        public class CActorStar
        {
            public int X, Y;
            public Bitmap im;
            public int speed;
        }

        Bitmap off;
        Timer tt = new Timer();
        int ctTick = 0;
        int rocketAcc = 5;
        int count = 0;

        List<CActorLaser> LLaser = new List<CActorLaser>();
        List<CActorRocket> LRocket = new List<CActorRocket>();
        List<CActorStar> LStars = new List<CActorStar>();
        public Form1()
        {
            this.WindowState = FormWindowState.Maximized;
            this.Load += Form1_Load;
            this.Paint += Form1_Paint;
            this.KeyDown += Form1_KeyDown;
            this.MouseDown += Form1_MouseDown;

            tt.Interval = 100;
            tt.Start();
            tt.Tick += Tt_Tick;
        }

        private void Tt_Tick(object sender, EventArgs e)
        {
            if (ctTick % 15 == 0)
            {
                CreateStar();
                rocketAcc += 5;
            }

            MoveStars();
            for (int i=0; i < LLaser.Count; i++)
            {
                LLaser[i].visible--;
            }
            if (LRocket[0].isAcceleration)
            {
                if (count > 0)
                {
                    if (LRocket[0].dir == 1)
                    {
                        LRocket[0].X += count+ 5;
                    }
                    else
                    {
                        LRocket[0].X -= count+5;

                    }
                }
                count--;
            }
          
            ctTick++;

            DrawDubb(this.CreateGraphics());
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            DrawDubb(this.CreateGraphics());
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right)
            {
                if (LRocket[0].X + 170 < this.ClientSize.Width)
                {
                    LRocket[0].X += rocketAcc;
                    LRocket[0].dir = 1;
                    LRocket[0].isAcceleration = true;
                    count = 5;
                }

            }
            else if (e.KeyCode == Keys.Left)
            {
                if (LRocket[0].X > 0)
                {
                    LRocket[0].X -= rocketAcc;
                    LRocket[0].dir = -1;
                    LRocket[0].isAcceleration = true;
                    count = 5;
                }

            }
            else if (e.KeyCode == Keys.Space)
            {
                CActorLaser pnn=new CActorLaser();
                pnn.X1 = LRocket[0].X + 170/2;
                pnn.Y1 = LRocket[0].Y;
                pnn.X2 = LRocket[0].X + 160 / 2;
                pnn.Y2 = 0;
                pnn.visible = 2 ;

                LLaser.Add(pnn);

                HitStar();
                
            }

        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            DrawDubb(e.Graphics);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            off = new Bitmap(this.ClientSize.Width, this.ClientSize.Height);
            CreateRocket();
        }

        void CreateRocket()
        {
            CActorRocket pnn=new CActorRocket();
            pnn.isAcceleration = false;
            pnn.dir = 0;
            pnn.im = new Bitmap("rocket.png");
            pnn.im.MakeTransparent();
            pnn.X = 150;
            pnn.Y = this.ClientSize.Height - 172;

            LRocket.Add(pnn);

        }

        void CreateStar()
        {
            Random rr = new Random();
            CActorStar pnn = new CActorStar();
            pnn.im = new Bitmap("star.bmp");
            pnn.im.MakeTransparent();
            pnn.X = rr.Next(80, this.ClientSize.Width - 80);
            pnn.Y = 0;
            pnn.speed = 5;

            LStars.Add(pnn);
        }
        int check = 0;
        int moveDirection = 1;
        void MoveStars()
        {
            check++;

            for (int i = 0; i < LStars.Count; i++)
            {
                LStars[i].Y += LStars[i].speed;

                if (check % 10 == 0)
                {
                    moveDirection *= -1;
                }
                else if (check % 17 == 1)
                {
                    moveDirection *= -1;
                }

                LStars[i].X += 5 * moveDirection;
            }

            if (check == 20)
            { 
                check = 0;
            }

        }

        void HitStar()
        {
            for (int j = 0; j < LLaser.Count; j++)
            {

                for (int i = 0; i < LStars.Count; i++)
                {
                    if (LLaser[j].X1 > LStars[i].X && LLaser[j].X1 < LStars[i].X + 50)
                    {
                        LStars.RemoveAt(i);
                    }
                }
            }

        }
        void DrawScene(Graphics g)
        {
            g.Clear(Color.Black);

            for (int i = 0; i < LRocket.Count; i++)
            {
                g.DrawImage(LRocket[i].im, LRocket[i].X, LRocket[i].Y, 170, 170);
            }

            for (int i = 0; i < LLaser.Count; i++)
            {
                if (LLaser[i].visible > 0)
                {

                    Pen p = new Pen(Color.Yellow, 3);
                    g.DrawLine(p, LLaser[i].X1, LLaser[i].Y1, LLaser[i].X2, LLaser[i].Y2);
                }
            }

            for (int i = 0; i < LStars.Count; i++)
            {
                g.DrawImage(LStars[i].im, LStars[i].X, LStars[i].Y, 50, 50);

            }

        }

        void DrawDubb(Graphics g)
        {
            Graphics g2 = Graphics.FromImage(off);
            DrawScene(g2);
            g.DrawImage(off, 0, 0);

        }
    }
}

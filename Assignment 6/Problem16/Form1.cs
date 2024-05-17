using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Problem16
{
    public partial class Form1 : Form
    {
        public class CActorBall
        {
            public int X, Y;
            public Bitmap im;
        }

        public class CActorHero
        {
            public int X, Y;
            public List<Bitmap> im;
            public int iFrame;
        }

        public Form1()
        {
            this.WindowState = FormWindowState.Maximized;
            this.Load += Form1_Load;
            this.Paint += Form1_Paint;
            this.KeyDown += Form1_KeyDown;

        }

        Bitmap off;
        List<CActorBall> LBallsUp = new List<CActorBall>();
        List<CActorBall> LBallsDown = new List<CActorBall>();
        List<CActorBall> LBallsHero = new List<CActorBall>();


        CActorHero hero;


        private void Form1_Load(object sender, EventArgs e)
        {
            off = new Bitmap(this.ClientSize.Width, this.ClientSize.Height);
            CreateBalls();
            CreateHero();

        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            DrawDubb(e.Graphics);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch(e.KeyCode)
            {
                case Keys.Up:
                    hero.Y -= 5;
                    if(hero.iFrame < 10)
                    {
                        hero.iFrame++;
                    }
                    else
                    {
                        hero.iFrame = 0;
                    }
                    if (LBallsHero.Count > 0)
                    {
                        LBallsHero[0].Y = hero.Y + 20;
                    }
                    break;

                case Keys.Down:
                    hero.Y += 5;
                    if (hero.iFrame > 1)
                    {
                        hero.iFrame--;
                    }
                    else
                    {
                        hero.iFrame = 9;
                    }
                    if (LBallsHero.Count > 0)
                    {
                        LBallsHero[0].Y = hero.Y + 20;
                    }
                    break;

                case Keys.Enter:
                    if (hero.Y <= 75)
                    {
                        CActorBall pnn2 = new CActorBall();
                        pnn2.X = hero.X - 20;
                        pnn2.Y = hero.Y + 20;
                        pnn2.im = new Bitmap("ball.bmp");
                        pnn2.im.MakeTransparent();
                        LBallsUp.Add(pnn2);
                        LBallsHero.RemoveAt(0);
                    }
                    break;

                case Keys.Space:
                    if (hero.Y >= 605)
                    {  
                        CActorBall pnn = new CActorBall();
                        pnn.X = hero.X - 20;
                        pnn.Y = hero.Y + 20;
                        pnn.im = new Bitmap("ball.bmp");
                        pnn.im.MakeTransparent();

                        LBallsHero.Add(pnn);
                        LBallsDown.RemoveAt(LBallsDown.Count - 1);
                    }
                    break;
            }

            DrawDubb(this.CreateGraphics());

        }

        void CreateHero()
        {
            hero = new CActorHero();
            hero.X = 810;
            hero.Y = 150;
            hero.iFrame = 0;
            hero.im = new List<Bitmap>();

            for (int k = 0; k < 8; k++)
            {
                Bitmap im = new Bitmap("hero" + (k + 1) + ".bmp");
                im.MakeTransparent();
                hero.im.Add(im);
            }
        }

        void CreateBalls()
        {
            Random rr = new Random();
            int ballNum = rr.Next(5, 10);
            int xBall = 640;
            int yBall = this.ClientSize.Height - 75;
            for (int i = 0; i < ballNum; i++)
            {
                CActorBall pnn = new CActorBall();
                pnn.X = xBall;
                pnn.Y = yBall;
                pnn.im = new Bitmap("ball.bmp");
                pnn.im.MakeTransparent();

                if (xBall < 740)
                {
                    xBall += 20;
                }
                else
                {
                    xBall = 640;
                    yBall += 20;
                }

                LBallsDown.Add(pnn);
            }

        }

        void DrawScene(Graphics g)
        {
            g.Clear(Color.Yellow);

            SolidBrush brush = new SolidBrush(Color.Orange);
            g.FillRectangle(brush, 630, 0, 300, 80);

            brush = new SolidBrush(Color.Green);
            g.FillRectangle(brush, 630, this.ClientSize.Height - 90, 300, 90);


            if (hero.im != null && hero.im.Count > 0)
            {
                int index = hero.iFrame % hero.im.Count; //choose bitmap based on current frame index
                g.DrawImage(hero.im[index], hero.X, hero.Y, 102, 100);
            }

            for (int i = 0; i < LBallsDown.Count; i++)
            {
                CActorBall ptrav = LBallsDown[i];
                g.DrawImage(ptrav.im, ptrav.X, ptrav.Y, 20, 20);
            }

            for (int i = 0; i < LBallsUp.Count; i++)
            {
                CActorBall ptrav= LBallsUp[i];
                g.DrawImage(ptrav.im, ptrav.X, ptrav.Y, 20, 20);
            }

            for (int i = 0; i < LBallsHero.Count; i++)
            {
                CActorBall ptrav = LBallsHero[i];
                g.DrawImage(ptrav.im, ptrav.X, ptrav.Y, 20, 20);
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

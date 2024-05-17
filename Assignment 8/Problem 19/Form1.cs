using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Problem_19
{
    public partial class Form1 : Form
    {
        Bitmap off;
        Timer tt = new Timer();

        public class CActorHelicopter
        {
            public int X, Y;
            public Bitmap im;
        }

        public class CActorLand
        {
            public int X, Y;
            public Bitmap im;
            public int dirX;
        }

        public class CActorBird
        {
            public int X, Y;
            public List<Bitmap> imgs;
            public int iFrame;
            public int dirX;
            public int pos;

        }

        List<CActorHelicopter> LHelicopter = new List<CActorHelicopter>();
        List<CActorBird> LBirdsHeli = new List<CActorBird>();
        List<CActorBird> LBirdsLand = new List<CActorBird>();
        List<CActorLand> LLandsMoving = new List<CActorLand>();
        List<CActorLand> LLandsStable = new List<CActorLand>();

        int near = -1;
        bool upKey = false;
        bool leftKey = false;
        bool rightKey = false;
        public Form1()
        {
            this.WindowState = FormWindowState.Maximized;
            this.Load += Form1_Load;
            this.Paint += Form1_Paint;
            this.KeyDown += Form1_KeyDown;
            this.KeyUp += Form1_KeyUp;

            tt.Interval = 100;
            tt.Start();
            tt.Tick += Tt_Tick;

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                    upKey = true;
                    break;
                case Keys.Left:
                    leftKey = true;
                    break;
                case Keys.Right:
                    rightKey = true;
                    break;
                case Keys.Space:
                    if (near != -1 && near < LBirdsLand.Count)
                    {
                        CActorBird pnn = new CActorBird();
                        pnn.X = LBirdsLand[near].X;
                        pnn.Y = LHelicopter[0].Y + 80;
                        pnn.imgs = new List<Bitmap>();
                        for (int i = 0; i < 2; i++)
                        {
                            Bitmap im = new Bitmap("bird2.bmp");
                            im.MakeTransparent();
                            pnn.imgs.Add(im);
                        }
                        pnn.iFrame = 1;
                        LBirdsHeli.Add(pnn);
                        LBirdsLand.RemoveAt(near);
                    }
                    break;
            }
        }
        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                    upKey = false;
                    break;
                case Keys.Left:
                    leftKey = false;
                    break;
                case Keys.Right:
                    rightKey = false;
                    break;
            }
        }
        private void Tt_Tick(object sender, EventArgs e)
        {
            MoveLandsandBirds();

            if (upKey == false)
            {
                MoveHelicopter();
            }
            else
            {
                LHelicopter[0].Y -= 8;
                if (LBirdsHeli.Count > 0)
                {
                    for (int i = 0; i < LBirdsHeli.Count; i++)
                    {
                        LBirdsHeli[i].Y -= 8;
                    }
                }
            }
            if (leftKey)
            {
                LHelicopter[0].X -= 3;
                if (LBirdsHeli.Count > 0)
                {
                    for (int i = 0; i < LBirdsHeli.Count; i++)
                    {
                        LBirdsHeli[i].X -= 3;
                    }
                }
            }

            if (rightKey)
            {
                LHelicopter[0].X += 3;
                if (LBirdsHeli.Count > 0)
                {
                    for (int i = 0; i < LBirdsHeli.Count; i++)
                    {
                        LBirdsHeli[i].X += 3;
                    }
                }
            }

            ChangeBird();

            DrawDubb(this.CreateGraphics());
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            DrawDubb(e.Graphics);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            off = new Bitmap(this.ClientSize.Width, this.ClientSize.Height);
            CreateHelicopter();
            CreateLandsMoving();
            CreateLandsStable();
            CreateBirdsLand();
        }

        void CreateHelicopter()
        {
            CActorHelicopter pnn = new CActorHelicopter();
            pnn.im = new Bitmap("helicopter.png");
            pnn.X = this.ClientSize.Width - this.ClientSize.Width / 2;
            pnn.Y = 200;
            LHelicopter.Add(pnn);

        }

        void MoveHelicopter()
        {
            LHelicopter[0].Y += 3;
            if (LBirdsHeli.Count > 0)
            {
                for (int i = 0; i < LBirdsHeli.Count; i++)
                {
                    LBirdsHeli[i].Y += 3;
                }
            }
        }
        void CreateLandsMoving()
        {
            Random rr = new Random();
            int xLands = 400;
            for (int i = 0; i < 4; i++)
            {
                CActorLand pnn = new CActorLand();
                pnn.im = new Bitmap("Land.bmp");
                pnn.X = xLands;
                pnn.Y = this.ClientSize.Height - 200;
                if (i == 0 || i == 1)
                {
                    pnn.dirX = -1;
                }
                else
                {
                    pnn.dirX = 1;
                }

                xLands += 200;

                LLandsMoving.Add(pnn);

            }

        }
        void CreateLandsStable()
        {
            CActorLand pnn = new CActorLand();
            pnn.im = new Bitmap("Land.bmp");
            pnn.X = 0;
            pnn.Y = this.ClientSize.Height - 200;
            LLandsStable.Add(pnn);

            pnn = new CActorLand();
            pnn.im = new Bitmap("Land.bmp");
            pnn.X = this.ClientSize.Width - 200; ;
            pnn.Y = this.ClientSize.Height - 200;
            LLandsStable.Add(pnn);

        }

        void CreateBirdsLand()
        {
            int xBirds = 410;
            for (int j = 0; j < 4; j++)
            {
                CActorBird pnn = new CActorBird();
                pnn.imgs = new List<Bitmap>();

                for (int i = 0; i < 2; i++)
                {
                    Bitmap im = new Bitmap("bird" + (i + 1) + ".bmp");
                    im.MakeTransparent();
                    pnn.imgs.Add(im);

                }

                pnn.X = xBirds;
                pnn.Y = this.ClientSize.Height - 250;
                if (j == 0 || j == 1)
                {
                    pnn.dirX = -1;
                }
                else
                {
                    pnn.dirX = 1;
                }
                pnn.pos = j;
                xBirds += 200;
                pnn.iFrame = 0;

                LBirdsLand.Add(pnn);
            }
        }

        void MoveLandsandBirds()
        {
            for (int i = 0; i < LLandsMoving.Count; i++)
            {
                if (LLandsMoving[i].dirX == 1)
                {
                    LLandsMoving[i].X += 5;
                }
                else
                {
                    LLandsMoving[i].X -= 5;
                }
            }

            for (int i = 0; i < LBirdsLand.Count; i++)
            {
                if (LBirdsLand[i].dirX == 1)
                {
                    LBirdsLand[i].X += 5;
                }
                else
                {
                    LBirdsLand[i].X -= 5;
                }
            }

            CollideLandsandBirds();
        }

        void CollideLandsandBirds()
        {
            for (int i = 0; i < LLandsMoving.Count; i++)
            {
                if (i == 0)
                {
                    if (LLandsMoving[i].X == 70)
                    {
                        LLandsMoving[i].dirX = 1;
                        for (int k = 0; k < LBirdsLand.Count; k++)
                        {
                            if (LBirdsLand[k].pos == i)
                            {
                                LBirdsLand[k].dirX = LLandsMoving[LBirdsLand[k].pos].dirX;

                            }
                        }
                    }
                    else if (LLandsMoving[i].X + 70 == LLandsMoving[i + 1].X)
                    {

                        LLandsMoving[i].dirX = -1;
                        LLandsMoving[i + 1].dirX = 1;

                        for (int k = 0; k < LBirdsLand.Count; k++)
                        {
                            if (LBirdsLand[k].pos == i)
                            {
                                LBirdsLand[k].dirX = LLandsMoving[LBirdsLand[k].pos].dirX;

                            }

                        }

                    }
                }
                else if (i == LLandsMoving.Count - 1)
                {
                    if (LLandsMoving[i].X + 70 >= this.ClientSize.Width - 200)
                    {
                        LLandsMoving[i].dirX = -1;
                        for (int k = 0; k < LBirdsLand.Count; k++)
                        {
                            if (LBirdsLand[k].pos == i)
                            {
                                LBirdsLand[k].dirX = LLandsMoving[LBirdsLand[k].pos].dirX;
                            }
                        }
                    }
                    else if (LLandsMoving[i].X == LLandsMoving[i - 1].X + 70)
                    {
                        LLandsMoving[i].dirX = 1;
                        LLandsMoving[i - 1].dirX = -1;

                        for (int k = 0; k < LBirdsLand.Count; k++)
                        {
                            if (LBirdsLand[k].pos == i)
                            {
                                LBirdsLand[k].dirX = LLandsMoving[LBirdsLand[k].pos].dirX;
                            }
                        }

                    }
                }
                else
                {
                    if (LLandsMoving[i].X + 70 == LLandsMoving[i + 1].X)
                    {
                        LLandsMoving[i].dirX = -1;
                        LLandsMoving[i + 1].dirX = 1;
                        for (int k = 0; k < LBirdsLand.Count; k++)
                        {
                            if (LBirdsLand[k].pos == i)
                            {
                                LBirdsLand[k].dirX = LLandsMoving[LBirdsLand[k].pos].dirX;

                            }
                        }
                    }
                    else if (LLandsMoving[i].X == LLandsMoving[i - 1].X + 70)
                    {
                        LLandsMoving[i].dirX = 1;
                        LLandsMoving[i - 1].dirX = -1;
                        for (int k = 0; k < LBirdsLand.Count; k++)
                        {
                            if (LBirdsLand[k].pos == i)
                            {
                                LBirdsLand[k].dirX = LLandsMoving[LBirdsLand[k].pos].dirX;

                            }
                        }
                    }

                }
            }

        }

        void ChangeBird()
        {
            for (int i = 0; i < LBirdsLand.Count; i++)
            {
                int birdX = LBirdsLand[i].X + 25;

                if (birdX >= LHelicopter[0].X && birdX <= LHelicopter[0].X + 80 &&
                    LBirdsLand[i].Y >= LHelicopter[0].Y - 100 && LBirdsLand[i].Y <= LHelicopter[0].Y + 100)
                {
                    LBirdsLand[i].iFrame = 1;
                    near = i;
                }
                else
                {
                    LBirdsLand[i].iFrame = 0;
                }
            }
        }

        void DrawScene(Graphics g)
        {
            g.Clear(Color.GreenYellow);

            for (int i = 0; i < LHelicopter.Count; i++)
            {
                g.DrawImage(LHelicopter[i].im, LHelicopter[i].X, LHelicopter[i].Y, 80, 80);
            }

            for (int i = 0; i < LBirdsLand.Count; i++)
            {
                int index = LBirdsLand[i].iFrame % LBirdsLand[i].imgs.Count;
                if (index == 0)
                    g.DrawImage(LBirdsLand[i].imgs[index], LBirdsLand[i].X, LBirdsLand[i].Y, 50, 50);
                else
                    g.DrawImage(LBirdsLand[i].imgs[index], LBirdsLand[i].X, LBirdsLand[i].Y, 40, 40);
            }

            for (int i = 0; i < LBirdsHeli.Count; i++)
            {
                int index = LBirdsHeli[i].iFrame % LBirdsHeli.Count;
                g.DrawImage(LBirdsHeli[i].imgs[index], LBirdsHeli[i].X, LBirdsHeli[i].Y, 40, 40);
            }

            for (int i = 0; i < LLandsMoving.Count; i++)
            {
                g.DrawImage(LLandsMoving[i].im, LLandsMoving[i].X, LLandsMoving[i].Y, 70, 50);
            }

            for (int i = 0; i < LLandsStable.Count; i++)
            {
                g.DrawImage(LLandsStable[i].im, LLandsStable[i].X, LLandsStable[i].Y, 70, 50);
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

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.LinkLabel;

namespace Problem14
{
    public class CLine
    {
        public int X, Y, W, H;
        public Color cl;
    }
    public class CActorEgg
    {
        public int X, Y;
        public Bitmap im;
    }

    public class CActorMickey
    {
        public int X, Y;
        public List<Bitmap> img;
        public int iFrame;
    }

    public class CActorCoin
    {
        public int coinX, coinY;
        public Bitmap im;
        public int lineX, lineY;
        public int lineH, lineW;
    }


    public partial class Form1 : Form
    {
        public Form1()
        {
            this.WindowState = FormWindowState.Maximized;
            this.Load += Form1_Load;
            this.Paint += Form1_Paint;
            this.KeyDown += Form1_KeyDown;
            this.MouseDown += Form1_MouseDown;

        }


        List<CLine> Llines = new List<CLine>();
        List<CActorEgg> LEggsLeft = new List<CActorEgg>();
        List<CActorEgg> LEggsRight = new List<CActorEgg>();
        List<CActorCoin> LCoin = new List<CActorCoin>();

        int flag = 0;
        int k = 0;
        bool check;

        Bitmap off;
        CActorMickey mickey;

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                for (int i = 0; i < LCoin.Count; i++)
                {
                    if (isClick(LCoin[i], e.X, e.Y) != -1)
                    {
                        CActorEgg egg = new CActorEgg();
                        egg.X = LCoin[i].coinX;
                        egg.im = new Bitmap("egg1.bmp");
                        if (i == 0 || i == 2)
                        {
                            egg.Y = this.ClientSize.Height / 2 - 13;

                        }
                        else if (i == 1 || i == 3)
                        {
                            egg.Y = this.ClientSize.Height / 2 - 13 + 50;

                        }

                        if (i == 0 || i == 1)
                        {
                            LEggsLeft.Add(egg);
                        }
                        else if (i == 2 || i == 3)
                        {
                            LEggsRight.Add(egg);
                        }

                        DrawNewCoin(i);
                        break;
                    }
                }
            }

            DrawDubb(this.CreateGraphics());

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Space:
                    check = CheckEggs();
                    if (check == false)
                    {
                        flag = MoveEggs(flag);
                    }
                    break;

                case Keys.Up:
                    if (mickey.iFrame == 2)
                    {
                        mickey.iFrame = 0;
                    }
                    else if (mickey.iFrame == 3)
                    {
                        mickey.iFrame = 1;
                    }
                    break;

                case Keys.Down:
                    if (mickey.iFrame == 0)
                    {
                        mickey.iFrame = 2;
                    }
                    else if (mickey.iFrame == 1)
                    {
                        mickey.iFrame = 3;
                    }
                    break;

                case Keys.Right:
                    if (mickey.iFrame == 0)
                    {
                        mickey.iFrame = 1;
                    }
                    else if (mickey.iFrame == 2)
                    {
                        mickey.iFrame = 3;
                    }
                    break;

                case Keys.Left:
                    if (mickey.iFrame == 1)
                    {
                        mickey.iFrame = 0;
                    }
                    else if (mickey.iFrame == 3)
                    {
                        mickey.iFrame = 2;
                    }
                    break;
            }

            DrawDubb(this.CreateGraphics());
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            CreateLines();
            DrawDubb(e.Graphics);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CreateLines();
            CreateEggs();
            off = new Bitmap(this.ClientSize.Width, this.ClientSize.Height);
            CreateMickey();
        }

        void CreateEggs()
        {
            Random rr = new Random();
            int xEggs;
            int yEggs = this.ClientSize.Height / 2 - 22;

            for (int i = 0; i < 2; i++)
            {
                CActorEgg pnn = new CActorEgg();
                pnn.X = rr.Next(0, this.ClientSize.Width / 2 - 150);
                pnn.Y = yEggs;
                pnn.im = new Bitmap("egg1.bmp");
                LEggsLeft.Add(pnn);
                yEggs += 60;
            }

            yEggs = this.ClientSize.Height / 2 - 22;

            for (int i = 0; i < 2; i++)
            {
                CActorEgg pnn = new CActorEgg();
                pnn.X = rr.Next(this.ClientSize.Width / 2 + 200, this.ClientSize.Width - 40);
                pnn.Y = yEggs;
                pnn.im = new Bitmap("egg1.bmp");
                LEggsRight.Add(pnn);
                yEggs += 60;
            }
        }

        void CreateLines()
        {
            int xLine = 0;
            int yLine = this.ClientSize.Height / 2;

            for (int i = 0; i < 2; i++)
            {
                CLine pnn = new CLine();
                pnn.X = xLine;
                pnn.Y = yLine;
                pnn.W = this.ClientSize.Width / 2 - 60;
                pnn.H = 20;
                pnn.cl = Color.DarkRed;
                Llines.Add(pnn);

                yLine += 55;
            }

            xLine = this.ClientSize.Width / 2 + 55;
            yLine = this.ClientSize.Height / 2;

            for (int i = 0; i < 2; i++)
            {
                CLine pnn = new CLine();
                pnn.X = xLine;
                pnn.Y = yLine;
                pnn.W = this.ClientSize.Width / 2;
                pnn.H = 20;
                pnn.cl = Color.DarkRed;
                Llines.Add(pnn);

                yLine += 55;
            }

        }

        void CreateMickey()
        {
            mickey = new CActorMickey();
            Random RR = new Random();
            mickey.img = new List<Bitmap>();

            for (int k = 0; k < 4; k++)
            {
                Bitmap img = new Bitmap("mickey" + (k + 1) + ".bmp");
                img.MakeTransparent(img.GetPixel(0, 0));
                mickey.img.Add(img);
            }

            mickey.X = this.ClientSize.Width / 2 - 50;
            mickey.Y = this.ClientSize.Height / 2 - 10;
            mickey.iFrame = RR.Next(0, 3);
        }

        int MoveEggs(int flag)
        {
            for (int i = 0; i < LEggsLeft.Count; i++)
            {
                CActorEgg ptrav = LEggsLeft[i];
                ptrav.X += 5;
                if (flag == 0)
                {
                    ptrav.im = new Bitmap("egg1.bmp");
                }
                else if(flag==1)
                {
                    ptrav.im = new Bitmap("egg3.bmp");

                }
                else if(flag==2)
                {
                    ptrav.im = new Bitmap("egg2L.bmp");

                }

            }

            for (int i = 0; i < LEggsRight.Count; i++)
            {
                CActorEgg ptrav = LEggsRight[i];
                ptrav.X -= 5;
                if (flag == 0)
                {
                    ptrav.im = new Bitmap("egg1.bmp");
                }
                else if (flag == 1)
                {
                    ptrav.im = new Bitmap("egg3.bmp");

                }
                else if (flag == 2)
                {
                    ptrav.im = new Bitmap("egg2R.bmp");

                }
            }

            if (flag == 0)
            {
                flag = 1;
            }
            else if (flag == 1)
            {
                flag = 2;
            }
            else if (flag == 2)
            {
                flag = 0;
            }

            return flag;

        }

        bool CheckEggs()
        {
            int mickeyLeft = mickey.X - 5; // Left boundary of mickey
            int mickeyRight = mickey.X + 90; // Right boundary of mickey (90 is mickey's width)

            for (int i = 0; i < LEggsLeft.Count; i++)
            {
                CActorEgg ptrav = LEggsLeft[i];
                if (ptrav.X >= mickeyLeft && ptrav.X <= mickeyRight)
                {
                    MessageBox.Show("An egg has reached Mickey!");
                    if (LCoin == null || LCoin.Count == 0)
                    {
                        CreateCoins();
                    }
                    else if(LCoin.Count>0)
                    {
                        for (int z = 0; z < LCoin.Count; z++)
                        {
                            LCoin.RemoveAt(z);
                        }
                        LCoin.Clear();
                        CreateCoins();
                    
                    }
                    return true;
                }
            }
            for (int i = 0; i < LEggsRight.Count; i++)
            {
                CActorEgg ptrav = LEggsRight[i];
                if (ptrav.X >= mickeyLeft && ptrav.X <= mickeyRight)
                {
                    MessageBox.Show("An egg has reached Mickey!");
                    if (LCoin == null || LCoin.Count == 0)
                    {
                        CreateCoins();
                    }
                    else if (LCoin.Count > 0)
                    {
                        for (int z = 0; z < LCoin.Count; z++)
                        {
                            LCoin.RemoveAt(z);
                        }
                        LCoin.Clear();
                        CreateCoins();
                    
                    }
                    return true;
                }
            }
            return false;
        }

        void CreateCoins()
        {
            Random rr = new Random();
            
            int yCoins = this.ClientSize.Height / 2 - 170;
            int yLine = this.ClientSize.Height / 2 - 100;

            for (int i = 0; i < 2; i++)
            {
                CActorCoin pnn = new CActorCoin();
                pnn.coinX = rr.Next(0, this.ClientSize.Width / 2 - 150);
                pnn.coinY = yCoins;
                pnn.lineX = pnn.coinX + 45/2;
                pnn.lineY = yLine;
                pnn.lineH = 80;
                pnn.lineW = 2;

                if (i == 0)
                {
                    pnn.im = new Bitmap("coinUp1.bmp");
                    pnn.im.MakeTransparent();


                }
                else
                {
                    pnn.im = new Bitmap("coinDown1.bmp");
                    pnn.im.MakeTransparent(pnn.im.GetPixel(0,0));

                }

                LCoin.Add(pnn);
                yCoins += 350;
                yLine += 200;

            }

            yCoins = this.ClientSize.Height / 2 - 170;
            yLine = this.ClientSize.Height / 2 - 100;

            for (int i = 0; i < 2; i++)
            {
                CActorCoin pnn = new CActorCoin();
                pnn.coinX = rr.Next(this.ClientSize.Width / 2 + 200, this.ClientSize.Width - 80);
                pnn.coinY = yCoins;
                pnn.lineX = pnn.coinX + 45/2;
                pnn.lineY = yLine;
                pnn.lineH = 80;
                pnn.lineW = 2;
                if (i == 0)
                {
                    pnn.im = new Bitmap("coinUp2.bmp");
                    pnn.im.MakeTransparent(pnn.im.GetPixel(0,0));
                }
                else
                {
                    pnn.im = new Bitmap("coinDown2.bmp");
                    pnn.im.MakeTransparent();

                }
                LCoin.Add(pnn);
                yCoins += 350;
                yLine += 200;

            }

            for (int i = 0; i < LEggsLeft.Count; i++) { LEggsLeft.RemoveAt(i); }
            for (int i = 0; i < LEggsRight.Count; i++) { LEggsRight.RemoveAt(i); }

            LEggsLeft.Clear();
            LEggsRight.Clear();

        }

        void DrawNewCoin(int i)
        {
            Random rr = new Random();

            if (i == 0 || i == 1)
            {
                LCoin[i].coinX = rr.Next(0, this.ClientSize.Width / 2 - 150);
                LCoin[i].lineX = LCoin[i].coinX + 45/2;
            }
            else if (i == 2 || i == 3)
            {
                LCoin[i].coinX = rr.Next(this.ClientSize.Width / 2 + 200, this.ClientSize.Width - 80);
                LCoin[i].lineX = LCoin[i].coinX + 45/2;

            }

        }
        int isClick(CActorCoin ptrav, int xMouse, int yMouse)
        {
            if (xMouse > ptrav.coinX && xMouse < (ptrav.coinX + 90) && yMouse > ptrav.coinY && yMouse < (ptrav.coinY + 150))
            {
                return 1;
            }

            return -1;
        }



        void DrawScene(Graphics g)
        {
            g.Clear(Color.Goldenrod);
            for (int i = 0; i < Llines.Count; i++)
            {
                CLine ptrav = Llines[i];
                SolidBrush brsh = new SolidBrush(ptrav.cl);
                g.FillRectangle(brsh, ptrav.X, ptrav.Y, ptrav.W, ptrav.H);
            }

            for (int i = 0; i < LEggsLeft.Count; i++)
            {
                CActorEgg ptrav = LEggsLeft[i];
                g.DrawImage(ptrav.im, ptrav.X, ptrav.Y);
            }

            for (int i = 0; i < LEggsRight.Count; i++)
            {
                CActorEgg ptrav = LEggsRight[i];
                g.DrawImage(ptrav.im, ptrav.X, ptrav.Y);
            }

            if (mickey.img != null && mickey.img.Count > 0)
            {
                int index = mickey.iFrame % mickey.img.Count; //choose bitmap based on current frame index
                g.DrawImage(mickey.img[index], mickey.X, mickey.Y, 90, 90);
            }

            for (int i = 0; i < LCoin.Count; i++)
            {
                CActorCoin ptrav = LCoin[i];
                g.DrawImage(ptrav.im, ptrav.coinX, ptrav.coinY, 45, 70);
                g.DrawRectangle(new Pen(Color.Green), LCoin[i].lineX, LCoin[i].lineY, LCoin[i].lineW, LCoin[i].lineH);
                g.FillRectangle(new SolidBrush(Color.Green), LCoin[i].lineX, LCoin[i].lineY, LCoin[i].lineW, LCoin[i].lineH);


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

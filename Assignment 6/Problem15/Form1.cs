using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Problem15
{
    public partial class Form1 : Form
    {
        public class CActorChicken
        {
            public int X, Y;
            public Bitmap im;
        }
        public class CActorBasket
        {
            public int X, Y;
            public Bitmap im;
        }

        public class CActorEgg
        {
            public int X, Y;
            public Bitmap im;
        }
       
        public Form1()
        {
            this.WindowState = FormWindowState.Maximized;
            this.Load += Form1_Load;
            this.Paint += Form1_Paint;
            this.KeyDown += Form1_KeyDown;
            this.MouseDown += Form1_MouseDown;
            this.MouseMove += Form1_MouseMove;
            this.MouseUp += Form1_MouseUp;

        }

        bool isDrag = false;
        int xOld, yOld;
        int move = -1;

        Bitmap off;

        List<CActorBasket> LBaskets = new List<CActorBasket>();
        CActorChicken chicken;
        List<CActorEgg> LEggs1 = new List<CActorEgg>();
        List<CActorEgg> LEggs2 = new List<CActorEgg>();
        List<CActorEgg> LEggs3 = new List<CActorEgg>();
        List<CActorEgg> LEggsNoBasket = new List<CActorEgg>();
        

        CActorEgg egg;


        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            isDrag = false;
            DrawDubb(this.CreateGraphics());

        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDrag == true)
            {
                if (move != -1)
                {
                    int dx = e.X - xOld;
                    int dy = e.Y - yOld;

                    LBaskets[move].X += dx;
                    LBaskets[move].Y += dy;

                    if (move == 0)
                    {
                        if (LEggs1.Count > 0)
                        {
                            for (int k = 0; k < LEggs1.Count; k++)
                            {
                                LEggs1[k].X += dx;
                                LEggs1[k].Y += dy;  
                            }
                        }
                    }
                    else if(move == 1)
                    {
                        if (LEggs2.Count > 0)
                        {
                            for (int k = 0; k < LEggs2.Count; k++)
                            {
                                LEggs2[k].X += dx;
                                LEggs2[k].Y += dy;
                            }
                        }
                    }
                    else if(move == 2)
                    {
                        if (LEggs3.Count > 0)
                        {
                            for (int k = 0; k < LEggs3.Count; k++)
                            {
                                LEggs3[k].X += dx;
                                LEggs3[k].Y += dy;
                            }
                        }
                    }


                    xOld = e.X;
                    yOld = e.Y;
                }
            }

            DrawDubb(this.CreateGraphics());

        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                for (int i = 0; i < LBaskets.Count; i++)
                {
                    if(isClick(LBaskets[i],e.X,e.Y) != -1)
                    {
                        move = i;
                        xOld = e.X;
                        yOld = e.Y;
                        isDrag = true;
                        break;
                    }
                    else
                    {
                        move = -1;
                    }
                
                }

            }

            DrawDubb(this.CreateGraphics());

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch(e.KeyCode)
            {
                case Keys.Right:
                    chicken.X += 5;
                    break;

                case Keys.Left:
                    chicken.X -= 5;
                    break;

                case Keys.Enter:
                    egg = new CActorEgg();
                    egg.X = chicken.X + 20;
                    egg.im = new Bitmap("egg.bmp");
                    egg.im.MakeTransparent();
                    int b = CheckEgg(egg);
                    if (b != -1)
                    {
                        if (b == 0)
                        {
                            egg.Y = LBaskets[b].Y - 5;
                            LEggs1.Add(egg);
                        }
                        else if (b == 1)
                        {
                            egg.Y = LBaskets[b].Y - 5;
                            LEggs2.Add(egg);
                        }
                        else if (b == 2)
                        {
                            egg.Y = LBaskets[b].Y - 5;
                            LEggs3.Add(egg);
                        }

                    }
                    else
                    {
                        egg.Y = this.ClientSize.Height - 50;

                        LEggsNoBasket.Add(egg);
                    }
                    break;

            }

            DrawDubb(this.CreateGraphics());
        }

        int isClick(CActorBasket ptrav, int xMouse, int yMouse)
        {
            if (xMouse > ptrav.X && xMouse < (ptrav.X + 80) && yMouse > ptrav.Y && yMouse < (ptrav.Y + 50))
            {
                return 1;
            }
                return -1;
        }

        int CheckEgg(CActorEgg ptrav)
        {
            for (int j = 0; j < LBaskets.Count; j++)
            {
                CActorBasket basket = LBaskets[j];
                if (ptrav.X >= basket.X - 5 && ptrav.X <= basket.X + 80)
                {
                    return j;
                }
            }

            return -1;
        }


        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            DrawDubb(e.Graphics);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DrawBaskets();
            off = new Bitmap(this.ClientSize.Width, this.ClientSize.Height);
            DrawChicken();
        }

        void DrawBaskets()
        {
            int xBasket= this.ClientSize.Width / 2 - 100;
            for (int i = 0; i < 3; i++)
            {
                CActorBasket pnn = new CActorBasket();
                pnn.im = new Bitmap("basket.bmp");
                pnn.X = xBasket;
                pnn.Y = 600;
                xBasket += 300;

                LBaskets.Add(pnn);
            }
        }
        
        void DrawChicken()
        {
            chicken = new CActorChicken();
            chicken.im = new Bitmap("chicken.bmp");
            chicken.X = 800;
            chicken.Y = 150;
        }

        void DrawScene(Graphics g)
        {
            g.Clear(Color.Black);
            for (int i = 0; i < LBaskets.Count; i++)
            {
                CActorBasket ptrav = LBaskets[i];
                g.DrawImage(ptrav.im, ptrav.X, ptrav.Y, 80, 50);

            }

            g.DrawImage(chicken.im, chicken.X, chicken.Y, 50, 70);

            

            for (int i = 0; i < LEggsNoBasket.Count; i++)
            {
                CActorEgg ptrav = LEggsNoBasket[i];
                g.DrawImage(ptrav.im, ptrav.X, ptrav.Y, 10, 15);

            }

            for (int i = 0; i < LEggs1.Count; i++)
            {
                CActorEgg ptrav = LEggs1[i];
                g.DrawImage(ptrav.im, ptrav.X, ptrav.Y, 10, 15);

            }

            for (int i = 0; i < LEggs2.Count; i++)
            {
                CActorEgg ptrav = LEggs2[i];
                g.DrawImage(ptrav.im, ptrav.X, ptrav.Y, 10, 15);

            }

            for (int i = 0; i < LEggs3.Count; i++)
            {
                CActorEgg ptrav = LEggs3[i];
                g.DrawImage(ptrav.im, ptrav.X, ptrav.Y, 10, 15);

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

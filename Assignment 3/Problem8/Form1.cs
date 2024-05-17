using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Problem7
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            this.KeyDown += Form1_KeyDown;
        }

        int ctEnter = 0;
        int f1 = 0, f2 = 0;
        int forwards = 0;
        int posx0 = 0, posx2 = 0, posy2 = 0;

        List<Form1> L = new List<Form1>();

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    ctEnter++;
                    if(ctEnter == 1)
                    { 
                        this.Location = new Point(600,270);
                    }
                    if (ctEnter == 2)
                    {
                        //up left 0
                        Form1 pnn = new Form1();
                        pnn.Show();
                        pnn.BackColor = Color.Orange;
                        pnn.Size = new Size(150, 150);
                        pnn.Location = new Point(this.Location.X, this.Location.Y - 150);
                        forwards = 0;
                        posx0 = this.Location.X;
                        pnn.Opacity = 0.7;
                        L.Add(pnn);

                        //up right 1
                        pnn = new Form1();
                        pnn.Show();
                        pnn.BackColor = Color.Green;
                        pnn.Size = new Size(150, 150);
                        pnn.Location = new Point(this.Location.X + 150, this.Location.Y - 150);
                        forwards = 0;
                        pnn.Opacity = 0.7;
                        L.Add(pnn);

                        //right up 2
                        pnn = new Form1();
                        pnn.Show();
                        pnn.BackColor = Color.Yellow;
                        pnn.Size = new Size(150, 150);
                        pnn.Location = new Point(this.Location.X + this.ClientSize.Width + 10, this.Location.Y);
                        forwards = 0;
                        posx2 = this.Location.X + this.ClientSize.Width + 10;
                        posy2 = this.Location.Y;
                        pnn.Opacity = 0.7;
                        L.Add(pnn);

                        //right down 3
                        pnn = new Form1();
                        pnn.Show();
                        pnn.BackColor = Color.Maroon;
                        pnn.Size = new Size(150, 150);
                        pnn.Location = new Point(this.Location.X + this.ClientSize.Width + 150, this.Location.Y + 140);
                        forwards = 0;
                        pnn.Opacity = 0.7;
                        L.Add(pnn);

                        //down right 4
                        pnn = new Form1();
                        pnn.Show();
                        pnn.BackColor = Color.Maroon;
                        pnn.Size = new Size(150, 150);
                        pnn.Location = new Point(this.Location.X + 150, this.Location.Y + this.ClientSize.Height + 40);
                        forwards = 0;
                        pnn.Opacity = 0.7;
                        L.Add(pnn);

                        //down left 5
                        pnn = new Form1();
                        pnn.Show();
                        pnn.BackColor = Color.Yellow;
                        pnn.Size = new Size(150, 150);
                        pnn.Location = new Point(this.Location.X, this.Location.Y + this.ClientSize.Height + 40);
                        forwards = 0;
                        pnn.Opacity = 0.7;
                        L.Add(pnn);

                        //left down 6
                        pnn = new Form1();
                        pnn.Show();
                        pnn.BackColor = Color.Green;
                        pnn.Size = new Size(150, 150);
                        pnn.Location = new Point(this.Location.X - 285, this.Location.Y + 140);
                        forwards = 0;
                        pnn.Opacity = 0.7;
                        L.Add(pnn);

                        //left up 7
                        pnn = new Form1();
                        pnn.Show();
                        pnn.BackColor = Color.Orange;
                        pnn.Size = new Size(150, 150);
                        pnn.Location = new Point(this.Location.X - 145, this.Location.Y);
                        forwards = 0;
                        pnn.Opacity = 0.7;
                        L.Add(pnn);
                    }
                    break;

                case Keys.D1:
                    f1 = 1;
                    f2 = 0;
                    break;

                case Keys.D2:
                    f2 = 1;
                    f1 = 0;
                    break;

                case Keys.Space:
                    if (f1 == 1)
                    {
                        if (forwards == 0)
                        {
                            L[2].Location = new Point(L[2].Location.X + 1, L[2].Location.Y + 1);
                            L[3].Location = new Point(L[3].Location.X - 1, L[3].Location.Y - 1);
                       
                            L[6].Location = new Point(L[6].Location.X + 1, L[6].Location.Y - 1);
                            L[7].Location = new Point(L[7].Location.X - 1, L[7].Location.Y + 1);
                        }

                        if (forwards == 1)
                        {
                            L[2].Location = new Point(L[2].Location.X - 1, L[2].Location.Y - 1);
                            L[3].Location = new Point(L[3].Location.X + 1, L[3].Location.Y + 1);
                        
                            L[6].Location = new Point(L[6].Location.X - 1, L[6].Location.Y + 1);
                            L[7].Location = new Point(L[7].Location.X + 1, L[7].Location.Y - 1);
                        }

                        if (L[3].Location.X == posx2 && L[3].Location.Y == posy2)
                        {
                            forwards = 1;
                        }
                        if (L[2].Location.X == posx2 && L[2].Location.Y == posy2)
                        {
                            forwards = 0;
                        }

                    }
                    if (f2 == 1)
                    {
                        if (forwards == 0 )
                        {
                            L[0].Location = new Point(L[0].Location.X + 1, L[0].Location.Y);
                            L[1].Location = new Point(L[1].Location.X - 1, L[1].Location.Y);
                      
                            L[4].Location = new Point(L[4].Location.X - 1, L[4].Location.Y);
                            L[5].Location = new Point(L[5].Location.X + 1, L[5].Location.Y);
                        }

                        if (forwards == 1 )
                        {
                            L[0].Location = new Point(L[0].Location.X - 1, L[0].Location.Y);
                            L[1].Location = new Point(L[1].Location.X + 1, L[1].Location.Y);
                        
                            L[4].Location = new Point(L[4].Location.X + 1, L[4].Location.Y);
                            L[5].Location = new Point(L[5].Location.X - 1, L[5].Location.Y);
                        }

                        if (L[1].Location.X == posx0)
                        {
                            forwards = 1;
                        }
                        if (L[0].Location.X == posx0)
                        {
                            forwards = 0;
                        }

                    }
                    break;


            }
        }

    }
}



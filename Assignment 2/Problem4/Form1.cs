using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Problem4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            this.BackColor = Color.White;
            this.MouseDown += Form1_MouseDown;

        }

        int ctLeft = 0;
        int x1 = 0, y1 = 0; //left top
        int x2 = 0, y2 = 0; //left bottom
        int x3 = 0, y3 = 0; //right top
        int x4 = 0, y4 = 0; //right bottom

        public int deltaX = 0;
        public int deltaY = 0;

        List<Form1> L = new List<Form1>();

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ctLeft++;

                if(ctLeft == 1)
                {
                    Form1 pnn = new Form1();
                    pnn.Show();
                    pnn.Location = new Point(this.Location.X - this.ClientSize.Width, this.Location.Y - this.ClientSize.Height - 20);
                    pnn.BackColor = Color.Red;
                    x1 = this.Location.X - this.ClientSize.Width;
                    y1 = this.Location.Y - this.ClientSize.Height - 20;
                    pnn.deltaX = 0;
                    pnn.deltaY = -1;
                    L.Add(pnn);
                }
                if (ctLeft == 2)
                {
                    Form1 pnn = new Form1();
                    pnn.Show();
                    pnn.Location = new Point(this.Location.X - this.ClientSize.Width, this.Location.Y + this.ClientSize.Height + 20);
                    pnn.BackColor = Color.Yellow;
                    x2 = this.Location.X - this.ClientSize.Width;
                    y2 = this.Location.Y + this.ClientSize.Height + 20;
                    pnn.deltaX = 1;
                    pnn.deltaY = 0;
                    L.Add(pnn);
                }
                if (ctLeft == 3)
                {
                    Form1 pnn = new Form1();
                    pnn.Show();
                    pnn.Location = new Point(this.Location.X + this.ClientSize.Width, this.Location.Y - this.ClientSize.Height - 20);
                    pnn.BackColor = Color.Orange;
                    x3 = this.Location.X + this.ClientSize.Width;
                    y3 = this.Location.Y - this.ClientSize.Height - 20;
                    pnn.deltaX = -1;
                    pnn.deltaY = 0;
                    L.Add(pnn);

                }
                if (ctLeft == 4)
                {
                    Form1 pnn = new Form1();
                    pnn.Show();
                    pnn.Location = new Point(this.Location.X + this.ClientSize.Width, this.Location.Y + this.ClientSize.Height + 20);
                    pnn.BackColor = Color.Green;
                    x4 = this.Location.X + this.ClientSize.Width;
                    y4 = this.Location.Y + this.ClientSize.Height + 20;
                    pnn.deltaX = 0;
                    pnn.deltaY = 1;
                    L.Add(pnn);

                }
            }
            else
            {
                for (; ;)
                {
                    for (int i = 0; i < 4; i++)
                    {

                        if(L[i].deltaX == 1 && L[i].deltaY == 0)
                        {
                            L[i].Location = new Point(L[i].Location.X + 1, L[i].Location.Y);
                       
                        }
                        else if(L[i].deltaX == -1 && L[i].deltaY == 0)
                        {
                            L[i].Location = new Point(L[i].Location.X - 1, L[i].Location.Y);

                        }
                        else if(L[i].deltaY == 1 && L[i].deltaX == 0)
                        {
                            L[i].Location = new Point(L[i].Location.X, L[i].Location.Y - 1);

                        }
                        else if(L[i].deltaY == -1 && L[i].deltaX == 0)
                        {
                            L[i].Location = new Point(L[i].Location.X, L[i].Location.Y + 1);

                        }


                        if (L[i].Location.X == x1 && L[i].Location.Y == y1)
                        {
                            L[i].deltaX = 0;
                            L[i].deltaY = -1;
                        }
                        if (L[i].Location.X == x2 && L[i].Location.Y == y2)
                        {
                            L[i].deltaX = 1;
                            L[i].deltaY = 0;
                        }
                        if (L[i].Location.X == x3 && L[i].Location.Y == y3)
                        {
                            L[i].deltaX = -1;
                            L[i].deltaY = 0;
                        }
                        if (L[i].Location.X == x4 && L[i].Location.Y == y4)
                        {
                            L[i].deltaX = 0;
                            L[i].deltaY = 1;
                        }

                    }
                }
            }

        }

    }
}

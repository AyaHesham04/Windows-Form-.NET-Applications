using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Problem6
{
    public partial class Form1 : Form
    {
        bool isDrag = false;
        int yOld = -1;
        int ctRight=0;

        public Form1()
        {
            this.BackColor = Color.Black;
            this.MouseDown += Form1_MouseDown;
            this.MouseMove += Form1_MouseMove;
            this.MouseUp += Form1_MouseUp;

        }

        List<Form> LRight = new List<Form>();
        List<Form> LLeft = new List<Form>();



        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            isDrag = false;
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDrag = true;
                yOld = e.Y;

            }
            else
            {
                ctRight++;

                if (ctRight == 1)
                {
                    for (int i = 0; i < 4; i++)
                    {
                        Form pnn = new Form();
                        pnn.Show();
                        pnn.BackColor = Color.Orange;
                        pnn.Size = new Size(150, 120);
                        int posY = this.Location.Y + (i * 120);
                        pnn.Location = new Point(this.Location.X - 150, posY);
                        LLeft.Add(pnn);
                    }
                }
                else if(ctRight==2)
                {
                    for (int i = 0; i < 4; i++)
                    {
                        Form pnn = new Form();
                        pnn.Show();
                        pnn.BackColor = Color.Red;
                        pnn.Size = new Size(150, 120);
                        int posY = this.Location.Y + (i * 120);
                        pnn.Location = new Point(this.Location.X + this.ClientSize.Width + 15, posY);
                        LRight.Add(pnn);
                    }
                }
            }

        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDrag == true)
            {
                int dy = e.Y - yOld;

                for (int i = 0; i < 4; i++)
                {
                    Form pTravR = LRight[i];
                    pTravR.Location = new Point(pTravR.Location.X, dy + (i * 120));

                    Form pTravL = LLeft[i];
                    pTravL.Location = new Point(pTravL.Location.X, dy + (i * 120));
                }

            }

        }

    }
}

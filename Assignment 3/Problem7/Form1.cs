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
        public class CNode
        {
            public int R, G, B;
        }


        List<CNode> LColor = new List<CNode>();
        int ctClicks = 0;
        int posi = 0;
        CNode pnn;


        public Form1()
        {
            this.MouseDown += Form1_MouseDown;
            this.KeyDown += Form1_KeyDown;

        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (e.X < 255)
                {
                    ctClicks++;

                    if (ctClicks == 1)
                    {
                        pnn = new CNode();
                        pnn.R = e.X;
                    }
                    if (ctClicks == 2)
                    {
                        pnn.G = e.X;
                    }
                    if (ctClicks == 3)
                    {
                        pnn.B = e.X;
                    
                        this.Text = pnn.R.ToString() + "," + pnn.G.ToString() + "," + pnn.B.ToString();
                        LColor.Add(pnn);
                        ctClicks = 0;
                    }

                }

            }
        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {

            this.BackColor = Color.FromArgb(LColor[posi].R, LColor[posi].G, LColor[posi].B);
            
            switch (e.KeyCode)
            {
                case Keys.Up:
                    posi++;
                    if(posi == LColor.Count)
                    {
                        posi = 0;
                    }
                    break;

                case Keys.Down:
                    posi--;
                    if (posi < 0)
                    {
                        posi = LColor.Count - 1;
                    }
                    break;

            }


        }

    }
}

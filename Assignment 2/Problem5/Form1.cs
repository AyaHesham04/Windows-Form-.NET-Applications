using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Problem5
{
    public partial class Form1 : Form
    {
        bool isDrag = false;
        int xOld = -1;
        int yOld = -1;

        public Form1()
        {
            this.BackColor = Color.Black;
            this.MouseDown += Form1_MouseDown;
            this.MouseMove += Form1_MouseMove;
            this.MouseUp += Form1_MouseUp;

        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            isDrag = false;
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDrag = true;
                xOld = e.X;
                yOld = e.Y;
                this.BackColor = Color.Black;
            }
            
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDrag == true)
            {
                int dx = e.X - xOld;
                int dy = e.Y - yOld;

                // Do
       
                if (dx < 0)
                {
                    dx = 0; 
                }
                else if(dx > 255)
                {
                    dx = 255;
                }

                if (dy < 0)
                {
                    dy = 0;
                }
                else if (dy > 255)
                {
                    dy = 255;
                }

                this.BackColor = Color.FromArgb(dx % 255, dy % 255, 0);

                
            }

        }

    }
}

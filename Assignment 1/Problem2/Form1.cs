using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Problem2
{
    public partial class Form1 : Form
    {
        int ct = 0;
        int num = 9;
        double opacity;

        public Form1()
        {
            this.BackColor = Color.FromArgb(0, 0, 0);
            this.MouseDown += MyMouseDown;
        }

        private void MyMouseDown(object sender, MouseEventArgs e)
        {
            ct++;

            if (ct < num)
            {
                opacity = this.Opacity - 0.1;
                this.Opacity = opacity;

            }
            else if (ct < num*2)
            {
                opacity = this.Opacity + 0.1;
                this.Opacity = opacity;
            }
            else if( ct == num*2)
            {
                ct = 0;
            }
        }
    }

}

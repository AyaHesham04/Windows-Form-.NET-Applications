using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Problem1
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            this.BackColor = Color.FromArgb(0, 255, 0);
            this.MouseMove += MyMouseMove;
        }

        private void MyMouseMove(object sender, MouseEventArgs e)
        {
            if (e.X < (this.ClientSize.Width) / 4)
            {
                this.Show();
                this.Location = new Point(this.Location.X, this.Location.Y);
                this.BackColor = Color.FromArgb(0, 255, 0);
            }
            if ((e.X > (this.ClientSize.Width) / 4) && (e.X < (this.ClientSize.Width) / 2))
            {
                this.Show();
                this.Location = new Point(this.Location.X, this.Location.Y);
                this.BackColor = Color.FromArgb(255, 0, 0);
            }
            if ((e.X > (this.ClientSize.Width) / 2) && (e.X < (this.ClientSize.Width) * 3 / 4))
            {
                this.Show();
                this.Location = new Point(this.Location.X, this.Location.Y);
                this.BackColor = Color.FromArgb(0, 0, 255);
            }
            if (e.X > (this.ClientSize.Width) * 3 / 4)
            {
                this.Show();
                this.Location = new Point(this.Location.X, this.Location.Y);
                this.BackColor = Color.FromArgb(0, 0, 0);
            }

        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Problem10
{
    public class CNode
    {
        public int X, Y;
    }
    public partial class Form1 : Form
    {
        List<CNode> LTop = new List<CNode>();
        List<CNode> LBottom = new List<CNode>();

        int flag = 0;
        int pos = 0;
        int up = 0; //up not clicked
        int top = 0;
        int bottom = 0;
        int line = 0;
        public Form1()
        {
            this.BackColor = Color.FromArgb(255, 255, 255);
            this.MouseDown += MyMouseDown;
            this.Paint += Form1_Paint;
            this.KeyDown += Form1_KeyDown;
        }

        int posUp=0, posDown=0;
        int prevUp=0, prevDown=0;int z = 0;
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            MoveUp(posUp, prevUp);
            MoveDown(posDown,prevDown);
            switch (e.KeyCode)
            {
                case Keys.Up:
                    prevDown = posDown;
                    posDown++;
                    if (posDown == LBottom.Count)
                    {
                        posDown = 0;
                    }
                    break;

                case Keys.Down:
                    prevDown = posDown;
                    posDown--;
                    if (posDown < 0)
                    {
                        posDown = LBottom.Count - 1;
                    }
                    break;


                case Keys.Right:
                    prevUp = posUp;
                    posUp++;
                    if (posUp == LTop.Count)
                    {
                        posUp = 0;
                    }
                    break;

                case Keys.Left:
                    prevUp = posUp;
                    posUp--;
                    if (posUp < 0)
                    {
                        posUp = LTop.Count - 1;
                    }
                    break;

            }

        }

        private void MyMouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (flag == 0)
                {
                    pos = e.Y;
                    this.Text = pos.ToString();
                    flag = 1;
                    line = 1;

                }
                else
                {

                    if (up == 0 && e.Y < pos)
                    {
                        CNode pnn = new CNode();
                        pnn.X = e.X;
                        pnn.Y = e.Y;
                        LTop.Add(pnn);
                        up = 1; //up clicked
                        DrawEllipse(e.X,e.Y,up);

                    }
                    else if (up == 1 && e.Y > pos)
                    {
                        CNode pnn = new CNode();
                        pnn.X = e.X;
                        pnn.Y = e.Y;
                        LBottom.Add(pnn);
                        up = 0; //remove up click to make it not clicked
                        DrawEllipse(e.X, e.Y, up);

                    }
                    else
                    {
                        MessageBox.Show("Error");
                    }

                }

            }
            else
            {
                if (top == 0)
                {
                    MessageBox.Show("Top Points: ");
                }
                while (top < LTop.Count)
                {
                    MessageBox.Show($"{LTop[top].X}, {LTop[top].Y}");
                    top++;
                }

                if (bottom == 0)
                {
                    MessageBox.Show("Bottom Points: ");
                }
                while (bottom < LBottom.Count)
                {
                    MessageBox.Show($"{LBottom[bottom].X}, {LBottom[bottom].Y}");
                    bottom++;
                }
            }

        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            if (line == 1)
            {
                Graphics g = e.Graphics;
                Pen p = new Pen(Color.Black, 3); //3 for width
                g.DrawLine(p, 0, pos, this.ClientSize.Width, pos);
            }
        }

        void DrawEllipse(int x, int y, int up)
        {
            Graphics g = this.CreateGraphics();
            SolidBrush brush;
            if (up == 1)
            {
                brush = new SolidBrush(Color.RoyalBlue);
            }
            else
            {
                brush = new SolidBrush(Color.Maroon);
            }

            g.FillEllipse(brush, x, y, 10, 10);

        }

        void MoveUp(int currentPos, int prevPos)
        {
            Graphics g = this.CreateGraphics();
            SolidBrush brushCurrent = new SolidBrush(Color.Gray);
            SolidBrush brushPrev = new SolidBrush(Color.RoyalBlue);

            g.FillEllipse(brushCurrent, LTop[currentPos].X, LTop[currentPos].Y, 10, 10);
            g.FillEllipse(brushPrev, LTop[prevPos].X, LTop[prevPos].Y, 10, 10);

        }
        void MoveDown(int currentPos, int prevPos)
        {
            Graphics g = this.CreateGraphics();
            SolidBrush brushCurrent = new SolidBrush(Color.Gray);
            SolidBrush brushPrev = new SolidBrush(Color.Maroon);

            g.FillEllipse(brushCurrent, LBottom[currentPos].X, LBottom[currentPos].Y, 10, 10);
            g.FillEllipse(brushPrev, LBottom[prevPos].X, LBottom[prevPos].Y, 10, 10);

        }

    }
}

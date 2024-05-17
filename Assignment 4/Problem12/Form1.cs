using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Problem12
{
    public partial class Form1 : Form
    {
        public class CActor
        {
            public int X, Y;
            public int W, H;
            public Color cl;
        }

        List<CActor> Circles = new List<CActor>();
        List<CActor> SquaresLeft = new List<CActor>();
        List<CActor> SquaresRight = new List<CActor>();

        int i = 0;
        int ctLastRow = 0;
        int row = 0;
        int numBlocks1, numBlocks2;

        public Form1()
        {
            InitializeComponent();
            this.KeyDown += Form1_KeyDown;
            this.Paint += Form1_Paint;
            this.BackColor = Color.Black;

            Random rr = new Random();
            numBlocks1 = rr.Next(5, 15);
            numBlocks2 = rr.Next(5, 10);
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = CreateGraphics();

            Pen p = new Pen(Color.Orange);

            g.DrawLine(p, 20, 30, 300, 30); //up
            g.DrawLine(p, 20, 300, 300, 300); //down
            g.DrawLine(p, 20, 30, 20, 300); //left
            g.DrawLine(p, 300, 30, 300, 300); //right

            g.DrawLine(p, 350, 30, 630, 30); //up
            g.DrawLine(p, 350, 300, 630, 300); //down
            g.DrawLine(p, 350, 30, 350, 300); //left
            g.DrawLine(p, 630, 30, 630, 300); //right

            int xPos = 20;
            int yPos = 30;

            for (int j = 0; j < numBlocks1; j++)
            {
                CActor square = new CActor();
                square.X = xPos;
                square.Y = yPos;
                square.W = 20;
                square.H = 20;
                square.cl = Color.Orange;

                if (xPos + square.W > 265)
                {
                    row++;
                    xPos = 20;
                    yPos = 30 + row * 25;
                }
                else
                {
                    xPos += 25;
                }

                SquaresLeft.Add(square);
                Pen P = new Pen(square.cl);
                g.DrawRectangle(P, square.X, square.Y, square.W, square.H);
                SolidBrush brush = new SolidBrush(square.cl);
                g.FillRectangle(brush, square.X, square.Y, square.W, square.H);
            }

            row = 0;
            xPos = 350;
            yPos = 30;
            ctLastRow = 0;

            for (int j = 0; j < numBlocks2; j++)
            {
                CActor square = new CActor();
                square.X = xPos;
                square.Y = yPos;
                square.W = 20;
                square.H = 20;
                square.cl = Color.Pink;

                if (xPos + square.W > 595)
                {
                    row++;
                    ctLastRow = 0;
                    xPos = 350;
                    yPos = 30 + row * 25;
                }
                else
                {
                    xPos += 25;
                    ctLastRow++;
                }

                SquaresRight.Add(square);
                Pen P = new Pen(square.cl);
                g.DrawRectangle(P, square.X, square.Y, square.W, square.H);
                SolidBrush brush = new SolidBrush(square.cl);
                g.FillRectangle(brush, square.X, square.Y, square.W, square.H);
            }
        }


        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            Graphics g = CreateGraphics();
            int startX = 350 + (ctLastRow * 25);
            int startY = 30 + row * 25;

            switch (e.KeyCode)
            {
                case Keys.Enter:
                    if (startX + 25 * i < 600)
                    {
                        CActor pnn = new CActor();
                        pnn.X = startX + 25 * i;
                        pnn.W = 20;
                        pnn.Y = startY;
                        pnn.H = 20;
                        pnn.cl = Color.RoyalBlue;
                        Circles.Add(pnn);
                        SolidBrush brush = new SolidBrush(pnn.cl);
                        g.FillEllipse(brush, pnn.X, pnn.Y, pnn.W, pnn.H);
                        i++;
                    }
                    else
                    {
                        row++;
                        ctLastRow = 0;
                        startX = 350;
                        startY = 30 + row * 25;
                        i = 0;
                    }
                    break;

                case Keys.Space:
                    if (SquaresLeft.Count == SquaresRight.Count + Circles.Count)
                    {
                        MessageBox.Show("Correct");

                    }
                    else
                    {
                        MessageBox.Show("Error");
                    }
                    break;

            }
        }

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

namespace Lab3
{
    public partial class Form1 : Form
    {
        private ArrayList coordinates = new ArrayList();
        bool showLines = false;
        public Form1()
        {
            InitializeComponent();
            this.Text = "Lab 3 by Qintian Huang";
            AutoScrollMinSize = new Size(300, 250);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            int scrollX = this.AutoScrollPosition.X;
            int scrollY = this.AutoScrollPosition.Y;
            const int diameter = 15;
            Graphics g = e.Graphics;
            int counter = 0;
            int x1 = 0, x2, y1 = 0, y2;

            e.Graphics.Clear(Color.White);

            foreach (Point p in this.coordinates)
            {
                x2 = p.X;
                y2 = p.Y;
                if(showLines == true)
                {
                    if (counter != 0)
                    {
                        g.DrawLine(new Pen(Color.Black), x1 + scrollX, y1 + scrollY, x2 + scrollX, y2 + scrollY);
                    }
                }


                g.FillEllipse(Brushes.Red, p.X - diameter / 2 + scrollX, p.Y - diameter / 2 + scrollY, diameter, diameter);
                x1 = p.X;
                y1 = p.Y;
                counter++;
                base.OnPaint(e);
            }

            foreach (Point p in this.coordinates)
            {
                x2 = p.X;
                y2 = p.Y;

                g.FillEllipse(Brushes.Red, p.X - diameter / 2 + scrollX, p.Y - diameter / 2 + scrollY, diameter, diameter);
                x1 = p.X;
                y1 = p.Y;
                counter++;
                base.OnPaint(e);
            }

        }

        private void button1_MouseClick(object sender, MouseEventArgs e)
        {

            if(showLines == false && e.Button == MouseButtons.Left)
            {
                button1.Text = "Hide Lines";
                showLines = true;
                this.Invalidate();
            }
            else if(showLines == true && e.Button == MouseButtons.Left)
            {
                button1.Text = "Show Lines";
                showLines = false;
                this.Invalidate();
            }

        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Point p = new Point(e.X, e.Y);
                this.coordinates.Add(p);
                this.Invalidate();
            }
            else if (e.Button == MouseButtons.Right)
            {
                this.coordinates.Clear();
                this.Invalidate();
            }
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {

            


        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}

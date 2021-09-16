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

namespace Lab2
{
    public partial class Form1 : Form
    {
        private ArrayList coordinates = new ArrayList();
        public Form1()
        {
            InitializeComponent();
            this.Text = "Lab 2 by Qintian Huang";
        } 

        private void Form1_Load(object sender, EventArgs e)
        {

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

        private void Form1_Paint_1(object sender, PaintEventArgs e)
        {
            const int diameter = 20;
            const int radius = 10;
            Graphics g = e.Graphics;
            foreach (Point p in this.coordinates)
            {
                string xcoordinate = p.X.ToString();
                string ycoordinate = p.Y.ToString(); 
                string s = "{X=" + xcoordinate + ",Y=" + ycoordinate + "}";
                g.FillEllipse(Brushes.Red, p.X - radius, p.Y - radius, diameter, diameter);
                g.DrawString(s, Font, Brushes.Black , p.X - radius + 25, p.Y - radius + 3);
            }
        }
    }
}

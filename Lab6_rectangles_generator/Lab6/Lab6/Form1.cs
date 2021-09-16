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

namespace Lab6
{
    public partial class Form1 : Form
    {
        //variables
        public struct Rectangle
        {
            public Point pt1;
            public Point pt2;
            public int width;
            public Color border;
            public Color fill;
        }

        List<Rectangle> rectangles = new List<Rectangle>();
        List<Point> points = new List<Point>();
        private bool isCreate = true;

        private int currentWidth = 0;
        private Color currentBorder = Color.White;
        private Color currentFill = Color.White;
        

        public Form1()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.ResizeRedraw = true;
        }

        protected override void OnShown(EventArgs e)
        {
            Settings st = new Settings();
            st.StartPosition = FormStartPosition.CenterParent;
            st.listBox1.SetSelected(0, true);
            st.listBox2.SetSelected(0, true);
            st.listBox3.SetSelected(0, true);

            if (st.ShowDialog() == DialogResult.OK)
            {
                if (st.listBox1.SelectedIndex == 0)
                {
                    currentBorder = Color.White;
                }
                else if (st.listBox1.SelectedIndex == 1)
                {
                    currentBorder = Color.Black;
                }
                else if (st.listBox1.SelectedIndex == 2)
                {
                    currentBorder = Color.Red;
                }
                else if (st.listBox1.SelectedIndex == 3)
                {
                    currentBorder = Color.Blue;
                }
                else if (st.listBox1.SelectedIndex == 4)
                {
                    currentBorder = Color.Green;
                }

                if (st.listBox2.SelectedIndex == 0)
                {
                    currentFill = Color.White;
                }
                else if (st.listBox2.SelectedIndex == 1)
                {
                    currentFill = Color.Black;
                }
                else if (st.listBox2.SelectedIndex == 2)
                {
                    currentFill = Color.Red;
                }
                else if (st.listBox2.SelectedIndex == 3)
                {
                    currentFill = Color.Blue;
                }
                else if (st.listBox2.SelectedIndex == 4)
                {
                    currentFill = Color.Green;
                }

                if (st.listBox3.SelectedIndex == 0)
                {
                    currentWidth = 1;
                }
                else if (st.listBox3.SelectedIndex == 1)
                {
                    currentWidth = 1;
                }
                else if (st.listBox3.SelectedIndex == 2)
                {
                    currentWidth = 3;
                }
                else if (st.listBox3.SelectedIndex == 3)
                {
                    currentWidth = 4;
                }
                else if (st.listBox3.SelectedIndex == 4)
                {
                    currentWidth = 5;
                }
                else if (st.listBox3.SelectedIndex == 5)
                {
                    currentWidth = 6;
                }
                else if (st.listBox3.SelectedIndex == 6)
                {
                    currentWidth = 7;
                }
                else if (st.listBox3.SelectedIndex == 7)
                {
                    currentWidth = 8;
                }
                else if (st.listBox3.SelectedIndex == 8)
                {
                    currentWidth = 9;
                }
                else if (st.listBox3.SelectedIndex == 9)
                {
                    currentWidth = 10;
                }
            }

            }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Settings st = new Settings();
            st.StartPosition = FormStartPosition.CenterParent;

            if (st.ShowDialog() == DialogResult.OK)
            {
                if(st.listBox1.SelectedIndex == 0)
                {
                    currentBorder = Color.White;
                }
                else if(st.listBox1.SelectedIndex == 1)
                {
                    currentBorder = Color.Black;
                }
                else if (st.listBox1.SelectedIndex == 2)
                {
                    currentBorder = Color.Red;
                }
                else if (st.listBox1.SelectedIndex == 3)
                {
                    currentBorder = Color.Blue;
                }
                else if (st.listBox1.SelectedIndex == 4)
                {
                    currentBorder = Color.Green;
                }

                if (st.listBox2.SelectedIndex == 0)
                {
                    currentFill = Color.White;
                }
                else if (st.listBox2.SelectedIndex == 1)
                {
                    currentFill = Color.Black;
                }
                else if (st.listBox2.SelectedIndex == 2)
                {
                    currentFill = Color.Red;
                }
                else if (st.listBox2.SelectedIndex == 3)
                {
                    currentFill = Color.Blue;
                }
                else if (st.listBox2.SelectedIndex == 4)
                {
                    currentFill = Color.Green;
                }

                if(st.listBox3.SelectedIndex == 0)
                {
                    currentWidth = 1;
                }
                else if(st.listBox3.SelectedIndex == 1)
                {
                    currentWidth = 1;
                }
                else if (st.listBox3.SelectedIndex == 2)
                {
                    currentWidth = 3;
                }
                else if (st.listBox3.SelectedIndex == 3)
                {
                    currentWidth = 4;
                }
                else if (st.listBox3.SelectedIndex == 4)
                {
                    currentWidth = 5;
                }
                else if (st.listBox3.SelectedIndex == 5)
                {
                    currentWidth = 6;
                }
                else if (st.listBox3.SelectedIndex == 6)
                {
                    currentWidth = 7;
                }
                else if (st.listBox3.SelectedIndex == 7)
                {
                    currentWidth = 8;
                }
                else if (st.listBox3.SelectedIndex == 8)
                {
                    currentWidth = 9;
                }
                else if (st.listBox3.SelectedIndex == 9)
                {
                    currentWidth = 10;
                }

            }
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(rectangles.Count == 0)
            {

            }
            else if(rectangles.Count > 0)
            {
                rectangles.RemoveAt(rectangles.Count - 1);
                this.Invalidate();
            }
        }

        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.rectangles.Clear();
            isCreate = true;
            this.Invalidate();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            if(isCreate == true)
            {
                if (e.Button == MouseButtons.Left || e.Button == MouseButtons.Right || e.Button == MouseButtons.Middle)
                {
                    isCreate = false;
                    Point p1 = new Point(e.X, e.Y);
                    //Point p2 = new Point(-1, -1);

                    Rectangle a = new Rectangle();
                    a.pt1 = p1;
                    //a.pt2 = p2;
                    //a.width = currentWidth;
                    //a.border = currentBorder;
                    //a.fill = currentFill;
                    this.points.Add(p1);
                    this.rectangles.Add(a);
                    this.Invalidate();
                }
            }
            else if(isCreate == false)
            {

                if (e.Button == MouseButtons.Left || e.Button == MouseButtons.Right || e.Button == MouseButtons.Middle)
                {
                    if(currentBorder == Color.White && currentFill == Color.White)
                    {
                        MessageBox.Show("Please select a color for outline and fill in Menu->Settings. Outline and fill cannot both be no color.");
                        isCreate = true;
                        rectangles.RemoveAt(rectangles.Count - 1);
                        points.Clear();
                        this.Invalidate();
                    }
                    else
                    {
                        isCreate = true;
                        int x1 = rectangles[rectangles.Count - 1].pt1.X;
                        int y1 = rectangles[rectangles.Count - 1].pt1.Y;
                        rectangles.RemoveAt(rectangles.Count - 1);
                        /////
                        points.Clear();
                        Point p1 = new Point(x1, y1);
                        Point p2 = new Point(e.X, e.Y);
                        Rectangle a = new Rectangle();
                        a.pt1 = p1;
                        a.pt2 = p2;
                        a.width = currentWidth;
                        a.border = currentBorder;
                        a.fill = currentFill;
                        this.rectangles.Add(a);
                        this.Invalidate();
                    }
                }
            }
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            int x1, x2, y1, y2, rectWidth, rectHeight;
            
            if(isCreate == false)
            {
                g.FillEllipse(Brushes.Black, points[0].X - 4, points[0].Y - 4, 8, 8);
            }

            foreach (Rectangle r in this.rectangles)
            {

                if (r.pt1.X < r.pt2.X)
                {
                    x1 = r.pt1.X;
                    x2 = r.pt2.X;
                }
                else
                {
                    x1 = r.pt2.X;
                    x2 = r.pt1.X;
                }

                if (r.pt1.Y < r.pt2.Y)
                {
                    y1 = r.pt1.Y;
                    y2 = r.pt2.Y;
                }
                else
                {
                    y1 = r.pt2.Y;
                    y2 = r.pt1.Y;
                }

                rectWidth = x2 - x1;
                rectHeight = y2 - y1;

                if(r.fill != Color.White)
                {
                    g.FillRectangle(new SolidBrush(r.fill), x1, y1, rectWidth, rectHeight);
                }
                if(r.border != Color.White)
                {
                    g.DrawRectangle(new Pen(r.border, r.width), x1, y1, rectWidth, rectHeight);
                }

            }

        }
    }
}

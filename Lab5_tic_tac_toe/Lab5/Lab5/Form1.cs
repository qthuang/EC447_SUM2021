using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab5
{
    public partial class Form1 : Form
    {

        //dimensions
        private const float clientSize = 100;
        private const float lineLength = 80;
        private const float block = lineLength / 3;
        private const float offset = 10;
        private const float delta = 5;

        public enum CellSelection { N = 0, 
                                    O = 1, 
                                    X = -1};
        public CellSelection[,] grid = new CellSelection[3, 3] { { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } };
        public CellSelection[,] recordGrid = new CellSelection[3, 3] { { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } };


        private bool nextIsUser = true;

        private float scale;    //current scale factor

        private int[,] drawn = new int[3, 3] { { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } };

        private int[] OPosition = new int[2] { 0, 0 };

        private bool messageBoxInd = true;

        private bool finalO = false;
        private int Ox = 0, Oy = 0;

        public Form1()
        {
            InitializeComponent();
            ResizeRedraw = true;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            ApplyTransform(g);
             
            //draw board
            g.DrawLine(Pens.Black, block, 0, block, lineLength);
            g.DrawLine(Pens.Black, 2 * block, 0, 2 * block, lineLength);
            g.DrawLine(Pens.Black, 0, block, lineLength, block);
            g.DrawLine(Pens.Black, 0, 2 * block, lineLength, 2 * block);


            for (int i = 0; i < 3; ++i)
            {
                for (int j = 0; j < 3; ++j)
                {

                    if (grid[i, j] == CellSelection.X)
                    {
                        DrawX(i, j, g);
                        computerFirstToolStripMenuItem.Enabled = false;
                        recordGrid[i, j] = CellSelection.X;
                    }
                    else if(grid[i, j] == CellSelection.O)
                    {
                        DrawO(i, j, g);
                        computerFirstToolStripMenuItem.Enabled = false;
                        recordGrid[i, j] = CellSelection.O;
                    }
                    if (finalO == true)
                    {
                        DrawO(Ox, Oy, g);
                    }
                }
            }

        }

        private void ApplyTransform(Graphics g)
        {
            scale = Math.Min(ClientRectangle.Width / clientSize,
                ClientRectangle.Height / clientSize);
            if (scale == 0f) return;
            g.ScaleTransform(scale, scale);
            g.TranslateTransform(offset, offset);
        }
        private void DrawX(int i, int j, Graphics g)
        {
            g.DrawLine(Pens.Black, i * block + delta, j * block + delta,
                (i * block) + block - delta, (j * block) + block - delta);
            g.DrawLine(Pens.Black, (i * block) + block - delta, j * block + delta,
               (i * block) + delta, (j * block) + block - delta);
        }
        private void DrawO(int i, int j, Graphics g)
        {
            g.DrawEllipse(Pens.Black, i * block + delta, j * block + delta,
                block - 2 * delta, block - 2 * delta);
        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            Graphics g = CreateGraphics();
            ApplyTransform(g);
            PointF[] p = { new Point(e.X, e.Y) };
            g.TransformPoints(System.Drawing.Drawing2D.CoordinateSpace.World, System.Drawing.Drawing2D.CoordinateSpace.Device, p);
            if (p[0].X < 0 || p[0].Y < 0)
            {
                return;
            }
            int i = (int)(p[0].X / block);
            int j = (int)(p[0].Y / block);
            if (i > 2 || j > 2)
            {
                return;
            }

            if(nextIsUser == true)
            {

                if (e.Button == MouseButtons.Middle)
                {
                    grid[i, j] = CellSelection.N;
                    drawn[i, j] = 0;
                }
                else //only allow setting empty cells
                {
                    if (e.Button == MouseButtons.Left)
                    {
                        drawn[i, j]++;
                        if (drawn[i, j] == 1)
                        {
                            grid[i, j] = CellSelection.X;
                            nextIsUser = false;
                            recordGrid[i, j] = CellSelection.X;
                        }
                        else if (drawn[i, j] > 1)
                        {
                            MessageBox.Show("You're making a bad move. Please select an empty grid.");
                        }
                    }
                }
            }
            else if(nextIsUser == false)
            {

                OPosition = GameEngine.getOPosition(i, j, recordGrid, drawn);
                int a = OPosition[0];
                int b = OPosition[1];
                int c = OPosition[2];
                if (a == -1 && b == -1)
                {
                    if(messageBoxInd == true)
                    {
                        MessageBox.Show("You win!");
                    }
                    else
                    { }
                    messageBoxInd = false;
                }
                else if(a == -2 && b == -2)
                {
                    if (messageBoxInd == true)
                    {
                        MessageBox.Show("You Lose!");
                    }
                    else
                    { }
                    messageBoxInd = false;
                }
                else if(c == 0)
                {
                    if (messageBoxInd == true)
                    {
                        DrawO(a, b, g);
                        Ox = a;
                        Oy = b;
                        finalO = true;
                        MessageBox.Show("You Lose!");
                    }
                    else
                    { }
                    messageBoxInd = false;
                }
                else if(c == -1)
                {
                    if (messageBoxInd == true)
                    {
                        MessageBox.Show("This is a draw!");
                    }
                    else
                    { }
                    messageBoxInd = false;
                }
                else
                {
                    grid[a, b] = CellSelection.O;
                    drawn[a, b]++;
                    nextIsUser = true;
                    recordGrid[a, b] = CellSelection.O;
                }
            }

            Invalidate();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        public void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    grid[i, j] = CellSelection.N;
                    recordGrid[i, j] = CellSelection.N;
                    drawn[i, j] = 0;
                }
            }
            computerFirstToolStripMenuItem.Enabled = true;
            nextIsUser = true;
            messageBoxInd = true;
            finalO = false;
            this.Invalidate();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void clickHereToReadTipsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string title = "Tips";
            MessageBox.Show("User starts: click on any grid \r\nComputer starts: click on Computer First in the Menu \r\nBy clicking anywhere on the grid, the computer moves (if the user does not click, the computer does not move) \r\nIf all of the grids are filled, or you think that one party wins / loses, click one more time on the grid to see the result: lose, win, or draw\r\nAfter seeing the result in the message box, the game ends, and it can be initialized by choosing New in the Menu", title);
        }

        public void computerFirstToolStripMenuItem_Click(object sender, EventArgs e)
        {
            grid[1, 1] = CellSelection.O;
            recordGrid[1, 1] = CellSelection.O;
            drawn[1, 1] = 1;
            nextIsUser = true;
            this.Invalidate();
        }
    }
}

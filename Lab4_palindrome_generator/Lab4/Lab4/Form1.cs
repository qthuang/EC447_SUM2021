using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab4
{
    public partial class Form1 : Form
    {
        //variables
        int snum = 0;
        int counter = 0;
        int count = 0;
        bool gen = true;
        string str = "";
        string rstr = "";

        public Form1()
        {
            InitializeComponent();
            
            listBox1.SelectedIndex = -1;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                listBox1.Items.Clear();
                snum = Convert.ToInt32(textBox1.Text);
                count = Convert.ToInt32(textBox2.Text);
                counter = 0;
                label5.Visible = false;

                if(snum < 0 || snum > 1000000000 || count < 1 || count > 100)
                {
                    label5.Visible = true;
                    gen = false;
                }

                if(gen == true)
                {
                    while (counter < count)
                    {
                        str = Convert.ToString(snum);
                        //listBox1.Items.Add(str);

                        char[] array = str.ToCharArray();
                        Array.Reverse(array);
                        rstr = new string(array);
                        //listBox1.Items.Add(rstr);

                    if (str == rstr)
                        {
                            listBox1.Items.Add(str);
                            counter++;
                        }
                        snum++;
                    }
                }
            }
            catch
            {
                label5.Visible = true;
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab6
{
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();
        }



        private void Settings_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        public void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        public void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        { 

        }

        public void listBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}

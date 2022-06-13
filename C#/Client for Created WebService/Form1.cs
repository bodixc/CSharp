using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SPS_Lab7._3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            S1.Service1Client cl = new S1.Service1Client();
            label4.Text = cl.F4(Convert.ToInt32(textBox1.Text), Convert.ToInt32(textBox2.Text)).ToString();
            cl.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            S1.Service1Client cl = new S1.Service1Client();
            dataGridView1.DataSource = cl.GetAllElements();
            cl.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            S1.Service1Client cl = new S1.Service1Client();
            dataGridView1.DataSource = cl.GetElementByID(Convert.ToInt32(textBox3.Text));
            cl.Close();
        }
    }
}

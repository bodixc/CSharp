using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SPS_Lab7._1
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
            label1.Text = $"Login: {cl.IsLoginFree(textBox1.Text)}";
            cl.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            S1.Service1Client cl = new S1.Service1Client();
            label2.Text = $"IP: {cl.MyIPAddress()}";
            cl.Close();
        }
    }
}

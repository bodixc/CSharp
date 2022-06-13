using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Microsoft.Win32;

namespace SPS_Lab1._3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (RegistryKey key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Karpenchuk", true))
            {
                string[] P5 = (string[]) key.GetValue("P5");
                key.Close();
                string ValueP5 = string.Join("\n", P5);
                MessageBox.Show(ValueP5, button1.Text);
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (RegistryKey key = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\Karpenchuk", true))
            {
                string[] Value = {"Я Богдан", "кафедри КІ!"};
                key.SetValue("P6", Value, RegistryValueKind.MultiString);
                MessageBox.Show("Дані успішно внесено в реєстр!", button2.Text);
            }
        }
    }
}

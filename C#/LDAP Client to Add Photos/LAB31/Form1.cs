using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.DirectoryServices;

namespace LAB31
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (DirectoryEntry OU = new DirectoryEntry("LDAP://ou=KI3,dc=KARPENCHUK,dc=UA"))
            {
                string Name = textBox1.Text;
                string Path = @"C:\WORK\" + textBox2.Text;
                using (DirectoryEntry u = OU.Children.Add("F1RTeam=" + Name, "F1RaceTeam"))
                {
                    u.Properties["F1RaceTeam-Attribute05"].Add(Name);
                    using (FileStream F = new FileStream(Path, FileMode.Open, FileAccess.Read))
                    {
                        byte[] B = new byte[F.Length];
                        F.Read(B, 0, (int)F.Length);
                        u.Properties["F1RaceTeam-Attribute10"].Clear();
                        u.Properties["F1RaceTeam-Attribute10"].Value = B;
                    }
                    u.CommitChanges();
                    MessageBox.Show("Team " + textBox1.Text + " added to table!");
                }
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            using (DirectoryEntry AD = new DirectoryEntry("LDAP://ou=KI3,dc=KARPENCHUK,dc=UA"))
            {
                dataGridView1.Rows.Clear();
                foreach (DirectoryEntry u in AD.Children)
                {
                    var name = u.Properties["F1RaceTeam-Attribute05"].Value;
                    var Photo = V((byte[])u.Properties["F1RaceTeam-Attribute10"].Value);
                    var row = dataGridView1.Rows.Add();
                    dataGridView1.Rows[row].Cells["Name"].Value = name;
                    dataGridView1.Rows[row].Cells["Photo"].Value = Photo;
                }
            }
            
        }
        public static Bitmap V(byte[] k)
        {
            using (MemoryStream S = new MemoryStream())
            {
                S.Write(k, 0, (int)k.Length);
                Bitmap m = new Bitmap(S, false);
                return m;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
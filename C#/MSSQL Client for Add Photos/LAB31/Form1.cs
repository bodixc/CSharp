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
            string S = "Data Source=BOHDAN\\SQLEXPRESS;Initial Catalog=Karpenchuk-LAB3;Integrated Security=True";
            using (SqlConnection C = new SqlConnection(S))
            {
                C.Open();
                SqlCommand M = new SqlCommand();
                M.Connection = C;
                M.CommandText = @"INSERT INTO F1RaceTeam VALUES (@Name, @Photo)";
                string Name = textBox1.Text;
                string Path = "C:\\WORK\\" + textBox2.Text;
                M.Parameters.Add("@Name", SqlDbType.NVarChar);
                byte[] D;
                using (FileStream F = new FileStream(Path, FileMode.Open))
                {
                    D = new byte[F.Length];
                    F.Read(D, 0, D.Length);
                    M.Parameters.Add("@Photo", SqlDbType.Binary, Convert.ToInt32(F.Length));
                }
                M.Parameters["@Name"].Value = Name;
                M.Parameters["@Photo"].Value = D;
                M.ExecuteNonQuery();
                MessageBox.Show("Team " + textBox1.Text + " added to table!");
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string DB = "Data Source=BOHDAN\\SQLEXPRESS; Initial Catalog=Karpenchuk-LAB3; Integrated Security=True";
            string Query = "select * from F1RaceTeam";
            using (SqlConnection Conn = new SqlConnection(DB))
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                Conn.Open();
                SqlDataAdapter da = new SqlDataAdapter(Query, DB);
                da.Fill(ds);
                DataTable T = ds.Tables[0];
                dataGridView1.DataSource = T;
            }


        }
    }
}

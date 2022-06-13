using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace SPS_Lab1._4
{
    public partial class Form1 : Form
    {
        DataTable Table;
        public Form1()
        {
            InitializeComponent();
            try
            {
                Table = GetAllTable();
                dataGridView1.DataSource = Table;
            }
            catch (Exception Error)
            {
                MessageBox.Show(Error.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }
        public static DataTable GetAllTable()
        {
            string DB = "Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = MyMusicalGroups; Integrated Security = True";
            string Query = "select * from MyMusicalGroups";
            using (SqlConnection SC = new SqlConnection(DB))
            {
                DataSet DS = new DataSet();
                DataTable DT = new DataTable();
                SC.Open();
                SqlDataAdapter DA = new SqlDataAdapter(Query, DB);
                DA.Fill(DS);
                DT = DS.Tables[0];
                return DT;
            }
        }

    }
}

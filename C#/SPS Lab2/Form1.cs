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
using System.Text.RegularExpressions;
using MySql.Data.MySqlClient;


namespace SPS_Lab_2._1
{
    public partial class Form1 : Form
    {
        public static bool MsSQL, MySQL;
        public static string DB; 
        string Query;
        public static int changedRows;
        DataTable T;
        Dictionary<string, int> Branch_IDs = new Dictionary<string, int>();
        string Item_ID, Item, Price, Basis, Weight, Volume;
        public static DataTable MySQL_GetAllTable(string Query = "select * from Building_Materials as x inner join Store_branch as y on x.Branch_ID = y.ID;")
        {
            MySqlConnection SC = new MySqlConnection(DB);
            DataSet DS = new DataSet();
            DataTable DT = new DataTable();
            SC.Open();
            MySqlDataAdapter DA = new MySqlDataAdapter(Query, DB);
            DA.Fill(DS);   
            DT = DS.Tables[0];
            return DT;
        }
        public static DataTable MsSQL_GetAllTable(string Query = "select * from Building_Materials as x inner join Store_branch as y on x.Branch_ID = y.ID;")
        {
            SqlConnection SC = new SqlConnection(DB);
            DataSet DS = new DataSet();
            DataTable DT = new DataTable();
            SC.Open();
            SqlDataAdapter DA = new SqlDataAdapter(Query, DB);
            DA.Fill(DS);
            DT = DS.Tables[0];
            return DT;

        }
        public void CheckStore_Branch()
        {
            Query = "select * from Store_branch;";
            if (MsSQL)
            {
                T = MsSQL_GetAllTable(Query);
            }
            else if (MySQL)
            {
                T = MySQL_GetAllTable(Query);
            }
            string Branch = "";
            string[] Store_Branch = { "Суміші", "Хімія" };
            foreach (DataRow R in T.Rows)
            {
                Branch += R["Branch"] + " ";
            }
            for (int i = 0; i < 2; i++)
            {
                if (!Branch.Contains(Store_Branch[i]))
                {
                    Query = $"insert into Store_branch (Branch) values(N'{Store_Branch[i]}');";
                    SendMySQLCommand(Query);
                }
            }
        }
        public void GetStore_Branch()
        {
            Query = "select * from Store_branch;";
            if (MsSQL)
            {
                T = MsSQL_GetAllTable(Query);
            }
            else if (MySQL)
            {
                T = MySQL_GetAllTable(Query);
            }
            List<string> Store_Branch = new List<string>();
            foreach (DataRow R in T.Rows)
            {
                string Branch = R["Branch"].ToString();
                Store_Branch.Add(Branch);
                Branch_IDs.Add(Branch, (int)R["ID"]);
            }
            comboBox1.DataSource = Store_Branch;
        }
        public static int SendMySQLCommand(string Query)
        {
            using (MySqlConnection SC = new MySqlConnection(DB))
            {
                SC.Open();
                MySqlCommand S1 = new MySqlCommand(Query, SC);
                int changedRows = S1.ExecuteNonQuery();
                return changedRows;
                
            }
        }
        public static int SendMsSQLCommand(string Query)
        {
            using (SqlConnection SC = new SqlConnection(DB))
            {
                SC.Open();
                SqlCommand S1 = new SqlCommand(Query, SC);
                int changedRows = S1.ExecuteNonQuery();
                return changedRows;
            }
        }
        public bool PassFormat(string p)
        {
            Regex R = new Regex("^[0-9]*[.]?[0-9]{0,2}$");              
            Match M = R.Match(p);
            return M.Success;
        }
        public bool PassInt(string p)
        {
            Regex R = new Regex("^[0-9]*$");
            Match M = R.Match(p);
            return M.Success;
        }
        public bool PassValues()
        {
            bool Pass = true;
            if (string.IsNullOrEmpty(Price) | string.IsNullOrWhiteSpace(Price))
            {
                MessageBox.Show("Поле 'Ціна' повинне мати значення", "Неправильний формат введення!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Pass = false;
            }
            else if (!PassFormat(Price))
            {
                MessageBox.Show("Поле 'Ціна' повинно мати ціле число або дробове \n(не більше 2 знаків після крапки)", "Неправильний формат введення!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Pass = false;
            }
            if (string.IsNullOrEmpty(Weight) | string.IsNullOrWhiteSpace(Weight))
            {
                Weight = "NULL";
            }
            else if (!PassFormat(Weight))
            {
                MessageBox.Show("Поле 'Вага' повинно мати ціле число або дробове \n(не більше 2 знаків після крапки)", "Неправильний формат введення!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Pass = false;
            }
            if (string.IsNullOrEmpty(Volume) | string.IsNullOrWhiteSpace(Volume))
            {
                Volume = "NULL";
            }   
            else if (!PassFormat(Volume))
            {
                MessageBox.Show("Поле 'Об\'єм' повинно мати ціле число або дробове \n(не більше 2 знаків після крапки)", "Неправильний формат введення!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Pass =  false;
            }
            if (Weight == "NULL" && Volume == "NULL")
            {
                MessageBox.Show("Одне з полів 'Вага', 'Об\'єм' повинно мати значення", "Неправильний формат введення!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Pass = false;
            }
            if (string.IsNullOrEmpty(Item) | string.IsNullOrWhiteSpace(Item))
            {
                MessageBox.Show("Поле 'Назва' повинне мати значення", "Неправильний формат введення!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Pass = false;
            }
            if (string.IsNullOrEmpty(Basis) | string.IsNullOrWhiteSpace(Basis))
            {
                MessageBox.Show("Поле 'Основа' повинне мати значення", "Неправильний формат введення!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Pass = false;
            }
            return Pass;
        }

        public Form1()
        {
            InitializeComponent();
            var result = MessageBox.Show("Виберіть базу даних:\n   MS-SQL -> Да\n   MySQL -> Нет", "Вибір робочої бази даних", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                MsSQL = true;
                MySQL = false;
                DB = "Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = Hardware_Store; Integrated Security = True";
            }
            else if (result == DialogResult.No)
            {
                MySQL = true;
                MsSQL = false;
                DB = "server=127.0.0.100; port=3306; database=Hardware_Store; user=root; password='12345678'; SSL Mode = None;";
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CheckStore_Branch();
            GetStore_Branch();
            if (MsSQL)
            {
                dataGridView1.DataSource = MsSQL_GetAllTable();
            }
            else if (MySQL)
            {
                dataGridView1.DataSource = MySQL_GetAllTable();
            }
        }

        public void button1_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            Hide();
            form2.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Item_ID = textBox6.Text;
            Item = textBox5.Text;
            Price = textBox7.Text;
            Basis = textBox2.Text;
            Weight = textBox4.Text;
            Volume = textBox3.Text;
            string Branch = comboBox1.Text;
            int Branch_ID = Branch_IDs[$"{Branch}"];
            bool C1 = checkedListBox1.CheckedItems.Contains(checkedListBox1.Items[0]);
            bool C11 = checkBox5.Checked;
            bool C12 = checkBox6.Checked;
            bool C2 = checkedListBox1.CheckedItems.Contains(checkedListBox1.Items[1]);
            bool C3 = checkedListBox1.CheckedItems.Contains(checkedListBox1.Items[2]);
            bool C4 = checkedListBox1.CheckedItems.Contains(checkedListBox1.Items[3]);
            if (C1)
            {
                if (C11 && !C12)
                {
                    if (string.IsNullOrEmpty(Item_ID) | string.IsNullOrWhiteSpace(Item_ID))
                    {
                        MessageBox.Show("Поле 'ID' повинно мати значення", "Неправильний формат введення!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else if (!PassInt(Item_ID))
                    {
                        MessageBox.Show("Поле 'ID' повинно мати формат цілого числа", "Неправильний формат введення!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        Query = $"select * from Building_Materials as x inner join Store_branch as y on x.Branch_ID = y.ID where Item_ID = {Item_ID};";
                    }
                }
                else if (C12 && !C11)
                {
                    Query = $"select * from Building_Materials as x inner join Store_branch as y on x.Branch_ID = y.ID where Branch = N\'{Branch}\';";
                }
                else
                {
                    Query = $"select * from Building_Materials as x inner join Store_branch as y on x.Branch_ID = y.ID;";
                }
                if (MsSQL)
                {
                    dataGridView1.DataSource = MsSQL_GetAllTable(Query);
                }
                else if (MySQL)
                {
                    dataGridView1.DataSource = MySQL_GetAllTable(Query);
                }
            }

            if (C2)
            {
                if (PassValues() == true)
                {
                    Query = $"insert into Building_Materials (Item, Price, Basis, Weight, Volume, Branch_ID) values (N'{Item}', {Price}, N'{Basis}', {Weight}, {Volume}, {Branch_ID}) ;";
                    if (MsSQL)
                    {
                        changedRows = SendMsSQLCommand(Query);
                        dataGridView1.DataSource = MsSQL_GetAllTable();
                    }
                    else if (MySQL)
                    {
                        changedRows = SendMySQLCommand(Query);
                        dataGridView1.DataSource = MySQL_GetAllTable();
                    }
                    MessageBox.Show($"Додано {changedRows} запис(ів)");
                }
            }
            if (C3)
            {
                if (string.IsNullOrEmpty(Item_ID) | string.IsNullOrWhiteSpace(Item_ID))
                {
                    MessageBox.Show("Поле 'ID' повинно мати значення", "Неправильний формат введення!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (!PassInt(Item_ID))
                {
                    MessageBox.Show("Поле 'ID' повинно мати формат цілого числа", "Неправильний формат введення!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (PassValues() == true)
                {
                    Query = $" update Building_Materials set Item = N'{Item}', Price = {Price}, Basis = N'{Basis}', Weight = {Weight}, Volume = {Volume}, Branch_ID = {Branch_ID} where Item_ID = {Item_ID};";
                    if (MsSQL)
                    {
                        changedRows = SendMsSQLCommand(Query);
                        dataGridView1.DataSource = MsSQL_GetAllTable();
                    }
                    else if (MySQL)
                    {
                        changedRows = SendMySQLCommand(Query);
                        dataGridView1.DataSource = MySQL_GetAllTable();
                    }
                    MessageBox.Show($"Змінено {changedRows} запис(ів)");
                }
            }
        
            if (C4)
            {
                if (string.IsNullOrEmpty(Item_ID) | string.IsNullOrWhiteSpace(Item_ID))
                {
                    MessageBox.Show("Поле 'ID' повинно мати значення", "Неправильний формат введення!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else  if (PassInt(Item_ID) == true)
                {
                    Query = $"delete from Building_Materials where Item_ID = {Item_ID};";
                    if (MsSQL)
                    {
                        changedRows = SendMsSQLCommand(Query);
                        dataGridView1.DataSource = MsSQL_GetAllTable();
                    }
                    else if (MySQL)
                    {
                        changedRows = SendMySQLCommand(Query);
                        dataGridView1.DataSource = MySQL_GetAllTable();
                    }
                    MessageBox.Show($"Вилучено {changedRows} запис(ів)");
                }
                else
                {
                    MessageBox.Show("Поле 'ID' повинно мати формат цілого числа", "Неправильний формат введення!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = checkedListBox1.SelectedIndex;
            for (int i = 0; i < 4; i++)
            {
                if (index != i)
                {
                    checkedListBox1.SetItemChecked(i, false);
                }
            }
        }

    }
}

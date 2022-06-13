using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
namespace SPS_Lab_2._1
{
    public partial class Form2 : Form
    {
        string Query;
        string defQuery = "select * from Store_branch;";
        static string DB = Form1.DB;
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            Close();
            form1.Show();
        }
        public bool PassInt(string p)
        {
            Regex R = new Regex("^[0-9]*$");
            Match M = R.Match(p);
            return M.Success;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            string Branch = textBox5.Text;
            string Branch_ID = textBox6.Text;
            bool C1 = checkedListBox1.CheckedItems.Contains(checkedListBox1.Items[0]);
            bool C2 = checkedListBox1.CheckedItems.Contains(checkedListBox1.Items[1]);
            bool C3 = checkedListBox1.CheckedItems.Contains(checkedListBox1.Items[2]);
            bool C4 = checkedListBox1.CheckedItems.Contains(checkedListBox1.Items[3]);
            if (C1)
            {
                if (Form1.MsSQL)
                {
                    dataGridView1.DataSource = Form1.MsSQL_GetAllTable(defQuery);
                }
                else if (Form1.MySQL)
                {
                    dataGridView1.DataSource = Form1.MySQL_GetAllTable(defQuery);
                }
            }

            if (C2)
            {
                if (string.IsNullOrEmpty(Branch) | string.IsNullOrWhiteSpace(Branch))
                {
                    MessageBox.Show("Поле 'Назва' повинно мати значення", "Неправильний формат введення!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    Query = $"insert into Store_branch (Branch) values (N'{Branch}') ;";
                    if (Form1.MsSQL)
                    {
                        Form1.changedRows = Form1.SendMsSQLCommand(Query);
                        dataGridView1.DataSource = Form1.MsSQL_GetAllTable(defQuery);
                    }
                    else if (Form1.MySQL)
                    {
                        Form1.changedRows = Form1.SendMySQLCommand(Query);
                        dataGridView1.DataSource = Form1.MySQL_GetAllTable(defQuery);
                    }
                    MessageBox.Show($"Додано {Form1.changedRows} запис(ів)");
                }
                
            }
            if (C3)
            {
                if (string.IsNullOrEmpty(Branch_ID) | string.IsNullOrWhiteSpace(Branch_ID))
                {
                    MessageBox.Show("Поле 'ID' повинно мати значення", "Неправильний формат введення!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (string.IsNullOrEmpty(Branch) | string.IsNullOrWhiteSpace(Branch))
                {
                    MessageBox.Show("Поле 'Назва' повинно мати значення", "Неправильний формат введення!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (!PassInt(Branch_ID))
                {
                    MessageBox.Show("Поле 'ID' повинно мати формат цілого числа", "Неправильний формат введення!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    Query = $" update Store_branch set Branch = N'{Branch}' where ID = {Branch_ID} ;";
                    if (Form1.MsSQL)
                    {
                        Form1.changedRows = Form1.SendMsSQLCommand(Query);
                        dataGridView1.DataSource = Form1.MsSQL_GetAllTable(defQuery);
                    }
                    else if (Form1.MySQL)
                    {
                        Form1.changedRows = Form1.SendMySQLCommand(Query);
                        dataGridView1.DataSource = Form1.MySQL_GetAllTable(defQuery);
                    }
                    MessageBox.Show($"Змінено {Form1.changedRows} запис(ів)");
                }
            }

            if (C4)
            {
                if (string.IsNullOrEmpty(Branch_ID) | string.IsNullOrWhiteSpace(Branch_ID))
                {
                    MessageBox.Show("Поле 'ID' повинно мати значення", "Неправильний формат введення!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (PassInt(Branch_ID) == true)
                {
                    Query = $"delete from Store_branch where ID = {Branch_ID} ;";
                    if (Form1.MsSQL)
                    {
                        Form1.changedRows = Form1.SendMsSQLCommand(Query);
                        dataGridView1.DataSource = Form1.MsSQL_GetAllTable(defQuery);
                    }
                    else if (Form1.MySQL)
                    {
                        Form1.changedRows = Form1.SendMySQLCommand(Query);
                        dataGridView1.DataSource = Form1.MySQL_GetAllTable(defQuery);
                    }
                        MessageBox.Show($"Вилучено {Form1.changedRows} запис(ів)");
                }
                else
                {
                    MessageBox.Show("Поле 'ID' повинно мати формат цілого числа", "Неправильний формат введення!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void checkedListBox1_SelectedIndexChanged_1(object sender, EventArgs e)
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;
using System.Threading;

namespace SPS_Lab5
{
    public partial class page1 : System.Web.UI.Page
    {
        string SN = String.Empty;
        string Mail = String.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (TextBox1.Text == String.Empty)
            {
                Label4.Text = "Введіть свої дані!";
            }
            else if (TextBox2.Text == String.Empty)
            {
                Label5.Text = "Введіть свою пошту!";
            }
            else
            {
                Label4.Text = "";
                Label5.Text = "";
                SN = TextBox1.Text;
                Mail = TextBox2.Text;
                Thread.Sleep(2000);
                Response.Redirect($"~/page5.aspx?Name={SN}&Mail={Mail}");
            }
        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            if (TextBox1.Text == String.Empty)
            {
                Label4.Text = "Введіть свої дані!";
            }
            else if (TextBox2.Text == String.Empty)
            {
                Label5.Text = "Введіть свою пошту!";
            }
            else
            {
                Label4.Text = "";
                Label5.Text = "";
                SN = TextBox1.Text;
                Mail = TextBox2.Text;
                Thread.Sleep(2000);
                Response.Redirect($"~/page2.aspx?Name={SN}&Mail={Mail}");
            }
        }
        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {
            if (!Regex.IsMatch(TextBox1.Text, @"^[a-zA-Z]*[ ]{1}[a-zA-Z]*$"))
            {
                Label4.Text = "Введіть коректно дані!";
                Button1.Visible = false;
                Button2.Visible = false;
            }
            else
            {
                Label4.Text = "";
                Button1.Visible = true;
                Button2.Visible = true;
            }
        }

        protected void TextBox2_TextChanged(object sender, EventArgs e)
        {
            if (!Regex.IsMatch(TextBox2.Text, @"^[a-z]*[@]{1}[a-z]*[.][a-z]*$"))
            {
                Label5.Text = "Введіть правильний формат пошти!";
                Button1.Visible = false;
                Button2.Visible = false;
            }
            else
            {
                Label5.Text = "";
                Button1.Visible = true;
                Button2.Visible = true;
            }
        }
    }
}
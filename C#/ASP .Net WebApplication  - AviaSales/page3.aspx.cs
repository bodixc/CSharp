using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Threading;

namespace SPS_Lab5
{
    public partial class page3 : System.Web.UI.Page
    {
        double Price;
        DateTime Today = DateTime.Today;
        DateTime DT = DateTime.Today;
        string Name, Mail, Type, Auto, Passport, StartDate, FinishDate, Duration, Cost = String.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            Price = Convert.ToDouble(Request.QueryString["PR"]);
            Name = Request.QueryString["Name"];
            Mail = Request.QueryString["Mail"];
            Type = Request.QueryString["Type"];
            Auto = Request.QueryString["Auto"];
            Passport = Request.QueryString["Passport"];
            try
            {
                var Ref = Request.UrlReferrer.ToString().Substring(24,10);
                if (!IsPostBack)
                {
                    if (Ref == "page2.aspx")
                    {

                        TextBox1.Text = Today.Day.ToString();
                        TextBox2.Text = Today.Month.ToString();
                        TextBox3.Text = Today.Year.ToString();
                        DateTime DT2 = Today.AddDays(1);
                        TextBox4.Text = DT2.Day.ToString();
                        TextBox5.Text = DT2.Month.ToString();
                        TextBox6.Text = DT2.Year.ToString();
                        Label7.Text = $"Вартість замовлення: {Price} грн.";
                    }
                    else
                    {
                        Label1.Text = "СТАЛАСЬ ПОМИЛКА!";
                        Label1.ForeColor = System.Drawing.Color.OrangeRed;
                        Button3.Visible = true;
                    }
                }
            }
            catch
            {
                Label1.Text = "СТАЛАСЬ ПОМИЛКА!";
                Label1.ForeColor = System.Drawing.Color.OrangeRed;
                Button3.Visible = true;
            }
        }
        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int Day = 0, Month = 0, Year = 0;
            try
            {
                Day = Convert.ToInt32(TextBox1.Text);
                Month = Convert.ToInt32(TextBox2.Text);
                Year = Convert.ToInt32(TextBox3.Text);
            }
            catch
            {

            }
            int ind = DropDownList1.SelectedIndex;
            double total = 0;
            try
            {
                DT = new DateTime(Year, Month, Day);
                if (DT < Today)
                {
                    Label8.Text = "Введіть дійсну дату!";
                    TextBox4.Text = "";
                    TextBox5.Text = "";
                    TextBox6.Text = "";
                    Button1.Visible = false;
                }
                else
                {
                    DateTime DT2;
                    Button1.Visible = true;
                    Label8.Text = "";
                    DT2 = Today;
                    if (ind == 0)
                    {
                        DT2 = DT.AddDays(1);
                        total = Price;
                    }
                    else if (ind == 1)
                    {
                        DT2 = DT.AddDays(3);
                        total = Price * 3 * 0.7;
                    }
                    else if (ind == 2)
                    {
                        DT2 = DT.AddDays(7);
                        total = Price * 7 * 0.6;
                    }
                    else if (ind == 3)
                    {
                        DT2 = DT.AddDays(14);
                        total = Price * 14 * 0.5;
                    }
                    TextBox4.Text = DT2.Day.ToString();
                    TextBox5.Text = DT2.Month.ToString();
                    TextBox6.Text = DT2.Year.ToString();
                    Label7.Text = $"Вартість замовлення: {total} грн.";
                }

            }
            catch
            {
                Label8.Text = "Введіть коректну дату!";
                TextBox4.Text = "";
                TextBox5.Text = "";
                TextBox6.Text = "";
                Button1.Visible = false;
            }

        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            StartDate = $"{TextBox1.Text}.{TextBox2.Text}.{TextBox3.Text}";
            FinishDate = $"{TextBox4.Text}.{TextBox5.Text}.{TextBox6.Text}";
            Duration = DropDownList1.SelectedValue;
            Cost = Label7.Text.Substring(21);
            Thread.Sleep(2000);
            Response.Redirect($"~/page4.aspx?&Name={Name}&Mail={Mail}&Type={Type}&Auto={Auto}&Passport={Passport}&StartDate={StartDate}&FinishDate={FinishDate}&Duration={Duration}&Cost={Cost}");
        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/page2.aspx");
        }
        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/page1.aspx");
        }
        protected void TextBox_TextChanged(object sender, EventArgs e)
        {
            int Day = 0, Month = 0, Year = 0;
            try
            {
                Day = Convert.ToInt32(TextBox1.Text);
                Month = Convert.ToInt32(TextBox2.Text);
                Year = Convert.ToInt32(TextBox3.Text);
            }
            catch
            {
 
            }
            int ind = DropDownList1.SelectedIndex;
            try
            {
                DT = new DateTime(Year, Month, Day);
                if (DT < Today)
                {
                    Button1.Visible = false;
                    Label8.Text = "Введіть дійсну дату!";
                    TextBox4.Text = "";
                    TextBox5.Text = "";
                    TextBox6.Text = "";
                }
                else
                {
                    DateTime DT2;
                    Button1.Visible = true;
                    Label8.Text = "";
                    DT2 = Today;
                    if (ind == 0)
                    {
                        DT2 = DT.AddDays(1);
                    }
                    else if (ind == 1)
                    {
                        DT2 = DT.AddDays(3);
                    }
                    else if (ind == 2)
                    {
                        DT2 = DT.AddDays(7);
                    }
                    else if (ind == 3)
                    {
                        DT2 = DT.AddDays(14);
                    }
                    TextBox4.Text = DT2.Day.ToString();
                    TextBox5.Text = DT2.Month.ToString();
                    TextBox6.Text = DT2.Year.ToString();
                }
            }
            catch
            {
                Button1.Visible = false;
                Label8.Text = "Введіть коректну дату!";
                TextBox4.Text = "";
                TextBox5.Text = "";
                TextBox6.Text = "";
            }

        }
    }
}
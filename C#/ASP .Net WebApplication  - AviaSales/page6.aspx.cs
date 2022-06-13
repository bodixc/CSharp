using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SPS_Lab5
{
    public partial class page6 : System.Web.UI.Page
    {
        string Orders, Do, Duration, FinishDate, Cost, Total, Mail, StartDuration = String.Empty;
        public string ChangeCost, ChangeDate, ChangeTotal = " ";
        protected void Page_Load(object sender, EventArgs e)
        {
            StartDuration = Request.QueryString["StartDuration"];
            Mail = Request.QueryString["Mail"];
            Do = Request.QueryString["Do"];
            Orders = Request.QueryString["Orders"];
            Duration = Request.QueryString["Duration"];
            FinishDate = Request.QueryString["FinishDate"];
            Cost = Request.QueryString["Cost"];
            Total = Request.QueryString["Costs"];
            try
            {
                var Ref = Request.UrlReferrer.ToString().Substring(24, 10);
                if (!IsPostBack)
                {
                    if (Ref == "page5.aspx")
                    {
                        string[] Order = Orders.Split(' ');
                        if (Do == "Припинити")
                        {
                            Label1.Text += "припинення <br/>";
                            Button1.Text = Do.ToUpper();
                            for (int i = 0; i < Order.Length-1; i++)
                            {
                                Label1.Text += $" &#9989; Замовлення #{Order[i]} <br/>";
                            }
                        }
                        else if (Do == "Продовжити")
                        {
                            Label1.Text += "продовження <br/>";
                            Button1.Text = Do.ToUpper();
                            string[] Dates = FinishDate.Split(' ');
                            string[] Costs = Cost.Split(' ');
                            string[] Totals = Total.Split('-');
                            for (int i = 0; i < Order.Length-1; i++)
                            {
                                string[] DMY = Dates[i].Split('.');
                                int Day = Convert.ToInt32(DMY[0]);
                                int Month = Convert.ToInt32(DMY[1]);
                                int Year = Convert.ToInt32(DMY[2]);
                                DateTime DT = new DateTime(Year, Month, Day);
                                double total = 0;
                                int Price = Convert.ToInt32(Costs[i]);
                                if (Duration == "1 день")
                                {
                                    DT = DT.AddDays(1);
                                    total = Price;
                                }
                                else if (Duration == "3 дні")
                                {
                                    DT = DT.AddDays(3);
                                    total = Price * 3 * 0.7;
                                }
                                else if (Duration == "1 тиждень")
                                {
                                    DT = DT.AddDays(7);
                                    total = Price * 7 * 0.6;
                                }
                                else if (Duration == "2 тижні")
                                {
                                    DT = DT.AddDays(14);
                                    total = Price * 14 * 0.5;
                                }
                                double Tot = total + Convert.ToInt32(Totals[i].Substring(0, Totals[i].Length - 5));
                                Label2.Text += $"{DT.Date.ToString().Substring(0, 10)} ";
                                Label3.Text += $"{total} грн. ,";
                                Label4.Text += $"{Tot} грн. ,";
                                Label1.Text += $" &#9989; Замовлення #{Order[i]} до {DT.Date.ToString().Substring(0, 10)} включно, вартість продовження {total} грн. <br/>";
                            }
                        }
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
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (Button1.Text == "ПРИПИНИТИ")
            {
                Response.Redirect($"~/page7.aspx?Do={Do}&Orders={Orders}&Mail={Mail}");
            }
            else if (Button1.Text == "ПРОДОВЖИТИ")
            {
                Response.Redirect($"~/page7.aspx?Do={Do}&Orders={Orders}&ChangeDate={Label2.Text}&ChangeCost={Label3.Text}&Duration={Duration}&ChangeTotal={Label4.Text}&Mail={Mail}&StartDuration={StartDuration}");
            }
        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/page5.aspx");
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/page1.aspx");
        }
    }
}
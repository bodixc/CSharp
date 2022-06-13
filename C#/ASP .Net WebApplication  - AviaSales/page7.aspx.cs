using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Net;
using System.Net.Mail;

namespace SPS_Lab5
{
    public partial class page7 : System.Web.UI.Page
    {
        string Orders, Do, ChangeDate, ChangeCost, Duration, ChangeTotal, Mail, StartDuration = String.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            StartDuration = Request.QueryString["StartDuration"];
            Mail = Request.QueryString["Mail"];
            Orders = Request.QueryString["Orders"];
            Do = Request.QueryString["Do"];
            ChangeDate = Request.QueryString["ChangeDate"];
            ChangeCost = Request.QueryString["ChangeCost"];
            Duration = Request.QueryString["Duration"];
            ChangeTotal = Request.QueryString["ChangeTotal"];
            try
            {
                var Ref = Request.UrlReferrer.ToString().Substring(24, 10);
                if (!IsPostBack)
                {
                    if (Ref == "page6.aspx")
                    {
                        string[] Order = Orders.Split(' ');

                        if (Do == "Припинити")
                        {
                            Label1.Text += "ПРИПИНЕННЯ ЗАМОВЛЕННЯ";
                            TR1.Visible = false;
                            TR2.Visible = false;
                            TR3.Visible = false;
                            for (int i = 0; i < Order.Length-1; i++)
                            {
                                TableCell TC = new TableCell();
                                TC.Text = Order[i];
                                TR0.Cells.Add(TC);
                                SmtpClient Smtp = new SmtpClient("smtp.gmail.com");
                                Smtp.Port = 587;
                                Smtp.Credentials = new NetworkCredential("bodixc", "didedadody");
                                Smtp.EnableSsl = true;
                                MailMessage message = new MailMessage();
                                message.From = new MailAddress("bodixc@gmail.com");
                                message.To.Add(Mail);
                                message.Subject = $"Stop Order #{Order[i]}";
                                string textBody = $"<table><tr><td>Замовлення</td><td>{Order[i]}</td></tr></table>";
                                message.IsBodyHtml = true;
                                message.Body = textBody;
                                Smtp.Send(message);
                                Label2.Text = "Дані припинення замовлення надіслано на вказану вами пошту!";
                                string DB = "Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = WebRent; Integrated Security = True";
                                using (SqlConnection SC = new SqlConnection(DB))
                                {
                                    string Query = $"delete Auto_Rent where OrderNumber = {Order[i]}";
                                    SC.Open();
                                    SqlCommand S1 = new SqlCommand(Query, SC);
                                    S1.ExecuteNonQuery();
                                }
                            }
                        }
                        else if (Do == "Продовжити")
                        {
                            string[] Date = ChangeDate.Split(' ');
                            string[] Cost = ChangeCost.Split(',');
                            string[] Totals = ChangeTotal.Split(',');
                            string[] Durations = StartDuration.Split(',');
                            Label1.Text += "ПРОДОВЖЕННЯ ЗАМОВЛЕННЯ";
                            for (int i = 0; i < Order.Length-1; i++)
                            {
                                TableCell TC = new TableCell();
                                TC.Text = Order[i];
                                TR0.Cells.Add(TC);
                                TableCell TC1 = new TableCell();
                                TC1.Text = Duration;
                                TR1.Cells.Add(TC1);
                                TableCell TC2 = new TableCell();
                                TC2.Text = Date[i];
                                TR2.Cells.Add(TC2);
                                TableCell TC3 = new TableCell();
                                TC3.Text = Cost[i];
                                TR3.Cells.Add(TC3);
                                SmtpClient Smtp = new SmtpClient("smtp.gmail.com");
                                Smtp.Port = 587;
                                Smtp.Credentials = new NetworkCredential("bodixc", "didedadody");
                                Smtp.EnableSsl = true;
                                MailMessage message = new MailMessage();
                                message.From = new MailAddress("bodixc@gmail.com");
                                message.To.Add(Mail);
                                message.Subject = $"Extend Order #{Order[i]}";
                                string textBody = $"<table><tr><td>Замовлення</td><td>{Order[i]}</td></tr><tr><td>Тривалість</td><td>{Duration}</td></tr><tr><td>Дата закінчення</td><td>{Date[i]}</td></tr><tr><td>Вартість</td><td>{Cost[i]}</td></tr></table>";
                                message.IsBodyHtml = true;
                                message.Body = textBody;
                                Smtp.Send(message);
                                Label2.Text = "Дані продовження замовлення надіслано на вказану вами пошту!";
                                string DB = "Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = WebRent; Integrated Security = True";
                                using (SqlConnection SC = new SqlConnection(DB))
                                {
                                    string Query = $"update Auto_Rent set Duration = N'{Duration} + {Durations[i]}', Cost = N'{Totals[i]}' where OrderNumber = N'{Order[i]}'";
                                    SC.Open();
                                    SqlCommand S1 = new SqlCommand(Query, SC);
                                    S1.ExecuteNonQuery();
                                }
                            }
                        }
                    }
                    else
                    {
                        Label1.Text = "СТАЛАСЬ ПОМИЛКА!";
                        Label1.ForeColor = System.Drawing.Color.OrangeRed;
                    }
                }
            }
            catch
            {
                Label1.Text = "СТАЛАСЬ ПОМИЛКА!";
                Label1.ForeColor = System.Drawing.Color.OrangeRed;
            }
        }
    
        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/page1.aspx");
        }
    }
}
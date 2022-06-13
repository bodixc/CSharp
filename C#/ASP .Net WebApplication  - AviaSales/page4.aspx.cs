using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Threading;
using System.Net;
using System.Net.Mail;
using System.Data.SqlClient;

namespace SPS_Lab5
{
    public partial class page4 : System.Web.UI.Page
    {
        string Name, Mail, Type, Auto, Passport, StartDate, FinishDate, Duration, Cost, OrderNumber = String.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                var Ref = Request.UrlReferrer.ToString().Substring(24, 10);
                Name = Request.QueryString["Name"];
                Mail = Request.QueryString["Mail"];
                Type = Request.QueryString["Type"];
                Auto = Request.QueryString["Auto"];
                Passport = Request.QueryString["Passport"];
                StartDate = Request.QueryString["StartDate"];
                FinishDate = Request.QueryString["FinishDate"];
                Duration = Request.QueryString["Duration"];
                Cost = Request.QueryString["Cost"];
                OrderNumber = DateTime.Now.Ticks.ToString().Substring(0, 12);
                if (!IsPostBack)
                {
                    if (Ref == "page3.aspx")
                    {
                        TC0.Text = Name;
                        TC1.Text = Mail;
                        Img.ImageUrl = @"~/Passport/" + Passport;
                        TC3.Text = Type;
                        TC4.Text = Auto;
                        TC5.Text = StartDate;
                        TC6.Text = FinishDate;
                        TC7.Text = Duration;
                        TC8.Text = Cost;
                        TC9.Text = OrderNumber;
                        SmtpClient Smtp = new SmtpClient("smtp.gmail.com");
                        Smtp.Port = 587;
                        Smtp.Credentials = new NetworkCredential("bodixc", "didedadody");
                        Smtp.EnableSsl = true;
                        MailMessage message = new MailMessage();
                        message.From = new MailAddress("bodixc@gmail.com");
                        message.To.Add(Mail);
                        message.Subject = $"Order #{OrderNumber}";
                        string textBody = $"<table><tr><td>Прізвище Ім'я</td><td>{Name}</td></tr><tr><td>Ел.пошта</td><td>{Mail}</td></tr><tr><td>Посвідчення водія</td><td><img src = \"{@"https://localhost:44374/Passport/" + Passport}\"/></td></tr><tr><td>Тип автомобіля</td><td>{Type}</td></tr><tr><td>Автомобіль</td><td>{Auto}</td></tr><tr><td>Початок аренди</td><td>{StartDate}</td></tr><tr><td>Кінець аренди</td><td>{FinishDate}</td></tr><tr><td>Тривалість аренди</td><td>{Duration}</td></tr><tr><td>Вартість</td><td>{Cost}</td></tr><tr><td>Номер замовлення</td><td>{OrderNumber}</td></tr></table>";
                        message.IsBodyHtml = true;
                        message.Body = textBody;
                        Smtp.Send(message);
                        Label3.Text = "Дані замовлення надіслано на вказану вами пошту!";
                        string DB = "Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = WebRent; Integrated Security = True";
                        using (SqlConnection SC = new SqlConnection(DB))
                        {
                            string Query = $"insert into Auto_Rent (Name, Mail, Passport, Type, Auto, StartDate, FinishDate, Duration, Cost, OrderNumber) values ('{Name}', N'{Mail}', '{Passport}', N'{Type}', N'{Auto}', '{StartDate}', '{FinishDate}', N'{Duration}', N'{Cost}', '{OrderNumber}') ;";
                            SC.Open();
                            SqlCommand S1 = new SqlCommand(Query, SC);
                            S1.ExecuteNonQuery();
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
            Thread.Sleep(2000);
            Response.Redirect("~/page1.aspx");
        }
    }
}
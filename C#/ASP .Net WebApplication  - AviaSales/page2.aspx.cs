using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI;
using System.Threading;
using System.Text.RegularExpressions;
using System.Drawing;
using System.IO;

namespace SPS_Lab5
{
    public partial class page2 : System.Web.UI.Page
    {
        string SN = String.Empty;
        string Mail = String.Empty;
        string Type = String.Empty;
        string Auto = String.Empty;
        string Passport = String.Empty;
        List<string> Light = new List<string>(){ "BMW X5 (600 грн/доба)", "Skoda Octavia (450 грн/доба)", "Mercedes-Benz S (700 грн/доба)", "Ford Fusion (400 грн/доба)", "VW Passat (500 грн/доба)" };
        List<string> Medium = new List<string>() { "Mervedes-Benz Sprinter (900 грн/доба)", "Renault Trafic (1000 грн/доба)", "Peugeot Boxer (600 грн/доба)" };
        List<string> Price = new List<string>() { "600", "450", "700", "400", "500", "900", "1000", "600" };
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                var Ref = Request.UrlReferrer.ToString().Substring(24,10);
                SN = Request.QueryString["Name"];
                Mail = Request.QueryString["Mail"];
                if (!IsPostBack)
                {
                    if (Ref == "page1.aspx" || Ref == "page3.aspx")
                    {
                        TextBox1.Text = SN;
                        DropDownList2.DataSource = Light;
                        DropDownList2.DataBind();
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
            string PR = string.Empty;
            int ind = DropDownList2.SelectedIndex;
            int inb = DropDownList1.SelectedIndex;
            Type = DropDownList1.SelectedValue;
            Auto = DropDownList2.SelectedValue;
            if (inb == 0)
            {
                PR = Price[ind];
            }
            if (inb == 1)
            {
                PR = Price[Light.Count + ind - 1];
            }
            if (!FileUpload1.HasFile)
            {
                Label5.Text = "Завантажте фото!";
            }
            else
            {
                string Extension = FileUpload1.FileName.Substring(FileUpload1.FileName.IndexOf('.'));
                if (Extension != ".jpeg" && Extension != ".png")
                {
                    Label5.Text = "Завантажте фото формату .jpeg або .png!";
                }
                else
                {
                    string Path = Server.MapPath(@"~/Passport/") + FileUpload1.FileName;
                    FileUpload1.SaveAs(Path);
                    Image Img = Image.FromFile(Path);
                    if (Img.Height < 100 || Img.Height > 200 || Img.Width < 150 || Img.Width > 300)
                    {
                        Label5.Text = $"Зображення некоректного розміру! ({Img.Height}x{Img.Width})";
                        File.Delete(Path);
                    }
                    else
                    {
                        Label5.Text = "";
                        Passport = FileUpload1.FileName;
                        Thread.Sleep(2000);
                        Response.Redirect($"~/page3.aspx?PR={PR}&Name={SN}&Mail={Mail}&Type={Type}&Auto={Auto}&Passport={Passport}");
                    }
                }
            }
        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            Thread.Sleep(2000);
            Response.Redirect("~/page1.aspx");
        }
        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/page1.aspx");
        }
        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {
            if (!Regex.IsMatch(TextBox1.Text, @"^[a-zA-Z]*[ ]{1}[a-zA-Z]*$"))
            {
                Label8.Text = "Введіть коректно дані!";
                Button1.Visible = false;
            }
            else
            {
                Label8.Text = "";
                Button1.Visible = true;
            }
        }
        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string Value = DropDownList1.SelectedValue;
            if (Value == "Легковий")
            {
                DropDownList2.DataSource = Light;
            }
            if (Value == "Дрібновантажний")
            {
                DropDownList2.DataSource = Medium;
            }
            DropDownList2.DataBind();
        }
    }
}
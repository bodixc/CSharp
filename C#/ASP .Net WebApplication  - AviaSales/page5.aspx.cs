using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Threading;

namespace SPS_Lab5
{
    public partial class page5 : System.Web.UI.Page
    {
        string Orders, Do, FinishDate, Duration, StartDuration, Cost, Costs, Mail = String.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            Mail = Request.QueryString["Mail"];
            try
            {
                var Ref = Request.UrlReferrer.ToString().Substring(24, 10);
                if (!IsPostBack)
                {
                    if (Ref == "page1.aspx" || Ref == "page6.aspx")
                    {

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
            int i = 0;
            foreach (GridViewRow gvrow in GridView1.Rows)
            {
                var checkbox = gvrow.FindControl("CheckBox1") as CheckBox;
                if (checkbox.Checked)
                {
                    i++;
                    Orders += gvrow.Cells[9].Text + " ";
                    Costs += gvrow.Cells[8].Text + "-";
                    StartDuration += gvrow.Cells[7].Text + ",";
                    FinishDate += gvrow.Cells[6].Text + " ";
                    string Auto = gvrow.Cells[4].Text;
                    int start = Auto.IndexOf('(')+1;
                    int end = Auto.IndexOf(')')-9;
                    Cost += Auto.Substring(start, end-start) + " ";
                }
            }
            if (i == 0)
            {
                Label2.Text = "Виберіть хоча б 1 замовлення!";
            }
            else
            {
                if (RadioButtonList1.SelectedIndex == 0)
                {
                    Do = RadioButtonList1.SelectedValue;
                    Thread.Sleep(2000);
                    Response.Redirect($"~/page6.aspx?Orders={Orders}&Do={Do}&Mail={Mail}");
                }
                else if (RadioButtonList1.SelectedIndex == 1)
                {
                    Do = RadioButtonList1.SelectedValue;
                    Duration = DropDownList1.SelectedValue;
                    Thread.Sleep(2000);
                    Response.Redirect($"~/page6.aspx?Orders={Orders}&Do={Do}&Duration={Duration}&Cost={Cost}&Costs={Costs}&FinishDate={FinishDate}&Mail={Mail}&StartDuration={StartDuration}");
                }
            }
        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/page1.aspx");
        }


        protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (RadioButtonList1.SelectedIndex == 1)
            {
                DropDownList1.Visible = true;
            }
            else
            {
                DropDownList1.Visible = false;
            }
        }
    }
}
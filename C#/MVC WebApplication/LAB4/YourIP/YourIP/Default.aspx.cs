using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Security.Principal;
using System.Data.SqlClient;

namespace YourIP
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Label1.Text = "Hello! Welcome to Web Server of Bohdan KARPENCHUK!  Your IP address: " + Request.UserHostAddress;
            string DB = "Data Source=localhost\\SQLEXPRESS; Initial Catalog=Karpenchuk-LAB4; Integrated Security=True";
            string Query = "select * from Myfriends";
            using (SqlConnection Conn = new SqlConnection(DB))
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                Conn.Open();
                SqlDataAdapter da = new SqlDataAdapter(Query, DB);
                da.Fill(ds);
                DataTable T = ds.Tables[0];
                GridView1.DataSource = T;
                GridView1.DataBind();
            }
            WindowsIdentity ID = WindowsIdentity.GetCurrent();
            Label2.Text="UserName: " + ID.Name;

        }
    }
}

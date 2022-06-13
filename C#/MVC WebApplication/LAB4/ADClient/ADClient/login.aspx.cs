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
using System.DirectoryServices;

namespace ADClient
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (!Is(TextBox1.Text, TextBox2.Text))
            {
                Response.Redirect("fail.aspx");
            }
            else
            {
                Response.Redirect("success.aspx?user=" + TextBox1.Text);
            }
        }

        public bool Is(string L, string P)
        {
            try
            {
                using (DirectoryEntry AD = new DirectoryEntry("LDAP://DC=KARPENCHUK,DC=UA", L, P))
                {
                    DirectorySearcher S = new DirectorySearcher(AD);
                    S.Filter = "(SAMAccountName=" + L + ")"; S.PropertiesToLoad.Add("cn");
                    SearchResult R = S.FindOne();
                    if (R == null)
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
            }
            catch
            {
                return false;
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            using (DirectoryEntry AD = new DirectoryEntry("LDAP://DC=KARPENCHUK,DC=UA"))
                {
                    using (DirectoryEntry u = AD.Children.Add("OU=LAB4", "organizationalUnit"))
                    {
                        u.CommitChanges();
                    }
                }
            Label3.Text = "OU LAB4 created";
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            for (int i = 1; i <= 50; i++)
            {
                using (DirectoryEntry AD = new DirectoryEntry("LDAP://OU=LAB4,DC=KARPENCHUK,DC=UA"))
                {
                    string user = "Bohdan" + i.ToString();
                    using (DirectoryEntry u = AD.Children.Add("CN=" + user, "user"))
                    {
                        u.Properties["displayName"].Add(user);
                        u.Properties["userPrincipalName"].Add(user + "@karpenchuk.ua");
                        u.Properties["sAMAccountName"].Add(user);
                        u.CommitChanges();

                        SetPassword(u, "P@ssw0rd");
                        u.Properties["userAccountControl"].Value = "544";
                        u.CommitChanges();
                    }
                }
            }
            Label4.Text = "Users created";
        }
        private static void SetPassword(DirectoryEntry UE, string password)
        {
            object[] oPassword = new object[] { password };
            object ret = UE.Invoke("SetPassword", oPassword);
            UE.CommitChanges();
        }
    }
}

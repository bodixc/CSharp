using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.DirectoryServices;

namespace lab2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (DirectoryEntry AD = new DirectoryEntry("LDAP://DC=KARPENCHUK,DC=UA"))
            {
                using (DirectoryEntry u = AD.Children.Add("OU=SecurityTeam", "organizationalUnit"))
                {
                    u.CommitChanges();
                }
            }
            using (DirectoryEntry AD = new DirectoryEntry("LDAP://OU=SecurityTeam,DC=KARPENCHUK,DC=UA"))
            {
                using (DirectoryEntry u = AD.Children.Add("OU=ImportantUsers", "organizationalUnit"))
                {
                    u.CommitChanges();
                }
            }
            using (DirectoryEntry AD = new DirectoryEntry("LDAP://OU=ImportantUsers,OU=SecurityTeam,DC=KARPENCHUK,DC=UA"))
            {
                using (DirectoryEntry u = AD.Children.Add("OU=Partners", "organizationalUnit"))
                {
                    u.CommitChanges();
                }
            }
            MessageBox.Show("OUs created!");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            for (int i = 1; i <= 50; i++)
            {
                using (DirectoryEntry AD = new DirectoryEntry("LDAP://OU=Partners,OU=ImportantUsers,OU=SecurityTeam,DC=KARPENCHUK,DC=UA"))
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
                        u.Properties["department"].Value = "Branch Office";
                        u.Properties["description"].Value = "Very Goog User";
                        u.Properties["businessCategory"].Add("Secretary");
                        u.Properties["businessCategory"].Add("Manager");
                        u.Properties["businessCategory"].Add("HelpDesk");

                        u.CommitChanges();
                    }
                }
            }
            MessageBox.Show("Users created!");
        }
        private static void SetPassword(DirectoryEntry UE, string password)
        {
            object[] oPassword = new object[] { password };
            object ret = UE.Invoke("SetPassword", oPassword);
            UE.CommitChanges();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (DirectoryEntry AD = new DirectoryEntry("LDAP://OU=Partners,OU=ImportantUsers,OU=SecurityTeam,DC=KARPENCHUK,DC=UA"))
            {
                foreach (DirectoryEntry u in AD.Children)
                {

                    u.Properties["Company"].Add("Kiev National University");
                    u.Properties["telephoneNumber"].Add("044-5260522");
                    u.Properties["KarpenchukDescription"].Add("Прогресивний працівник");
                    u.Properties["KarpenchukID"].Add("23456");
                    u.Properties["KarpenchukTaxID"].Add("8877665544");
                    u.Properties["KarpenchukCovidVaccinated"].Add("TRUE");
                    u.Properties["otherMobile"].Add("067-2334383");
                    u.Properties["otherMobile"].Add("050-2206789");
                    u.Properties["otherMobile"].Add("063-2184545");

                    u.CommitChanges();

                }

            }
            MessageBox.Show("Attributes added!");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            using (DirectoryEntry AD = new DirectoryEntry("LDAP://OU=ImportantUsers,OU=SecurityTeam,DC=KARPENCHUK,DC=UA"))
            {
                using (DirectoryEntry u1 = AD.Children.Add("CN=AdvancedSpecialists", "group"))
                {
                    u1.Properties["sAMAccountName"].Add("AdvancedSpecialists");
                    u1.CommitChanges();
                    using (DirectoryEntry u2 = AD.Children.Add("CN=AdvancedWorkers", "group"))
                    {
                        u2.Properties["sAMAccountName"].Add("AdvancedWorkers");
                        u2.Properties["member"].Add(u1.Properties["distinguishedName"].Value);
                        u2.CommitChanges();
                    }
                }
            }
            MessageBox.Show("Security groups created!");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            using (DirectoryEntry AD1 = new DirectoryEntry("LDAP://CN=AdvancedSpecialists,OU=ImportantUsers,OU=SecurityTeam,DC=KARPENCHUK,DC=UA"))
            {
                using (DirectoryEntry AD2 = new DirectoryEntry("LDAP://OU=Partners,OU=ImportantUsers,OU=SecurityTeam,DC=KARPENCHUK,DC=UA"))
                {
                    foreach (DirectoryEntry u in AD2.Children)
                    {
                        AD1.Properties["member"].Add(u.Properties["distinguishedName"].Value);
                        AD1.CommitChanges();
                    }
                }
            }
            MessageBox.Show("Users added to group");
        }
        string [] users = new string[]{};
        private void button6_Click(object sender, EventArgs e)
        {
            using (DirectoryEntry AD = new DirectoryEntry("LDAP://CN=AdvancedSpecialists  ,OU=ImportantUsers,OU=SecurityTeam,DC=KARPENCHUK,DC=UA"))
            {
                string Users = "";
                System.DirectoryServices.PropertyCollection RPCol2 = AD.Properties;
                foreach (string pr2 in RPCol2.PropertyNames)
                {
                    if (pr2.ToLower() == "member")
                    {
                        foreach (Object vc2 in RPCol2[pr2])
                        {
                            string User = vc2.ToString().Split(',')[0].Substring(3);
                            Users += User + "  \t";
                        }
                    }
                }
                textBox1.Text = Users;
                users = Users.Split('\t');
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            using (DirectoryEntry AD = new DirectoryEntry("LDAP://CN=AdvancedSpecialists,OU=ImportantUsers,OU=SecurityTeam,DC=KARPENCHUK,DC=UA"))
            {
                string Deleted = "";
                Random rnd = new Random();
                for (int i = 0; i < 2; i++)
                {
                    int index = rnd.Next(users.Count() - 1);
                    AD.Properties["member"].Remove("CN=" + users[index] + ",OU=Partners,OU=ImportantUsers,OU=SecurityTeam,DC=KARPENCHUK,DC=UA");
                    AD.CommitChanges();
                    Deleted += users[index];
                }
                button6_Click(sender, e);
                MessageBox.Show("Deleted " + Deleted);
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            try
            {
                using (DirectoryEntry AD = new DirectoryEntry("LDAP://DC=KARPENCHUK,DC=UA", textBox2.Text, textBox3.Text))
                {
                    DirectorySearcher S = new DirectorySearcher(AD);
                    S.Filter = "(SAMAccountName=" + textBox2.Text + ")"; 
                    S.PropertiesToLoad.Add("cn");
                    SearchResult R = S.FindOne();
                    if (R == null)
                    {
                        MessageBox.Show("Auth Failed☹");
                    }
                    else
                    {
                        MessageBox.Show("Auth is Succesful☺");
                    }
                }
            }
            catch
            {
                MessageBox.Show("Auth Failed☹");
            }            
        }
    }
}
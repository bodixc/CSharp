using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Xml;
using System.Security.Cryptography;

namespace SPS_Lab4._1
{
    public partial class Form1 : Form
    {
        string Login;
        public Form1()
        {
            InitializeComponent();
            textBox2.PasswordChar = '\u2388';
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Request_1();
            Request_2();
            Get_Auth();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public byte[] Speaking(byte[] M)
        {
            IPEndPoint ipEndPoint = new IPEndPoint(IPAddress.Parse("192.168.0.2"), 52000);
            byte[] bytes = new byte[1000000];
            using (Socket S = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp))
            {
                S.Connect(ipEndPoint);
                S.Send(M);
                int bytesRec = S.Receive(bytes);
                S.Shutdown(SocketShutdown.Both);
                return bytes;
            }
        }
        void Request_1()
        {
            Login = textBox1.Text;
            using (XmlWriter XW = XmlWriter.Create("Request-1.xml"))
            {
                XW.WriteStartElement("Data");
                XW.WriteElementString("Login", Login);
                XW.WriteEndElement();
            }
            XmlDocument XD = new XmlDocument();
            XD.Load("Request-1.xml");
            byte[] request_xml1 = Encoding.UTF8.GetBytes(XD.OuterXml);
            byte[] responce_xml1 = Speaking(request_xml1);
            MemoryStream MS = new MemoryStream(responce_xml1);
            XD.Load(MS);
            XD.Save("Responce-1.xml");
        }
        string Create_Hash()
        {
            XmlReader XR = XmlReader.Create("Responce-1.xml");
            XR.ReadToFollowing("Digest");
            string Digest = XR.ReadElementContentAsString();
            string Password = textBox2.Text;
            SHA1 sha1Hash = SHA1.Create();
            byte[] sourceBytes = Encoding.UTF8.GetBytes(Digest+Password);
            byte[] hashBytes = sha1Hash.ComputeHash(sourceBytes);
            string hash = BitConverter.ToString(hashBytes);
            return hash;
        }
        void Request_2()
        {
            string Hash = Create_Hash();
            using (XmlWriter XW = XmlWriter.Create("Request-2.xml"))
            {
                XW.WriteStartElement("Data");
                XW.WriteElementString("Login", Login);
                XW.WriteElementString("Hash", Hash);
                XW.WriteEndElement();
            }
            XmlDocument XD = new XmlDocument();
            XD.Load("Request-2.xml");
            byte[] request_xml2 = Encoding.UTF8.GetBytes(XD.OuterXml);
            byte[] responce_xml2 = Speaking(request_xml2);
            MemoryStream MS = new MemoryStream(responce_xml2);
            XD.Load(MS);
            XD.Save("Responce-2.xml");
        }
        void Get_Auth()
        {
            using (XmlReader XR = XmlReader.Create("Responce-2.xml"))
            {
                XR.ReadToFollowing("Auth-Status");
                string Status = XR.ReadElementContentAsString();
                if (Status == "Success")
                {
                    XR.ReadToFollowing("Group");
                    string Group = XR.ReadElementContentAsString();
                    label3.Text = $"Ви пройшли аутентифікацію \n і маєте права групи {Group}";
                }
                else if (Status == "Fail")
                {
                    label3.Text = "Ви НЕ пройшли аутентифікацію";
                }
            }

        }
    }
}

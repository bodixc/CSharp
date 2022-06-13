using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Xml;
using System.Net;
using System.Net.Sockets;
using Microsoft.Win32;
using System.IO;
using System.Security.Cryptography;

namespace SPS_Lab4._2
{
    public partial class Service1 : ServiceBase
    {
        CHAP_server CS;
        Thread T;
        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            CS = new CHAP_server();
            T = new Thread(new ThreadStart(CS.WorkerThread));
            T.Start();
        }

        protected override void OnStop()
        {
            T.Abort();
        }
    }
    class CHAP_server
    {
        byte[] B;
        string[] Values = new string[2];
        string[] Users;
        string Login, Digest, Hash;
        int ID = 1;
        public void WorkerThread()
        {
            while (true)
            {
                IPAddress IP = IPAddress.Parse("192.168.0.2");
                IPEndPoint ipEndPoint = new IPEndPoint(IP, 52000);
                Socket S = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
                try
                {
                    S.Bind(ipEndPoint);

                    while (true)
                    {
                        IPEndPoint L = new IPEndPoint(IP, 0);
                        EndPoint R = (EndPoint)L;
                        byte[] D = new byte[1000000];
                        int Receive = S.ReceiveFrom(D, ref R);
                        if (ID == 1)
                        {
                            Take_Request_1(D);
                            Responce_1();
                            ID += 1;
                        }
                        else if (ID == 2)
                        {
                            Take_Request_2(D);
                            Responce_2();
                            ID = 1;
                        }
                        S.SendTo(B, R);
                    }
                }
                catch (Exception e)
                {
                    WriteLog(e.Message);
                }
            }
        }

        private static void WriteLog(string z)
        {
            using (StreamWriter F = new StreamWriter("UDP.log", true))
            {
                F.WriteLine(DateTime.Now + "  " + z);
            }
        }
        string Get_Digest()
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
            var stringChars = new char[50];
            Random rnd = new Random();
            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[rnd.Next(chars.Length)];
            }
            string Digest = new String(stringChars);
            return Digest;
        }
        string Get_Hash(string Digest_Password)
        {
            SHA1 sha1Hash = SHA1.Create();
            byte[] sourceBytes = Encoding.UTF8.GetBytes(Digest_Password);
            byte[] hashBytes = sha1Hash.ComputeHash(sourceBytes);
            string hash = BitConverter.ToString(hashBytes);
            return hash;
        }
        void Get_Values()
        {
            RegistryKey key = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64);
            RegistryKey key1 = key.OpenSubKey(@"SOFTWARE\CHAP-server");
            Users = key1.GetValueNames();
            if (Users.Contains(Login))
            {
                string value = (string)key1.GetValue(Login);
                Values = value.Split(' ');
            }
            else
            {
                Values[0] = "False";
            }
        }
        void Take_Request_1(byte[] D)
        {
            MemoryStream MS = new MemoryStream(D);
            XmlDocument XD = new XmlDocument();
            XD.Load(MS);
            XD.Save("Request-1.xml");
        }
        void Responce_1()
        {
            XmlReader XR = XmlReader.Create("Request-1.xml");
            XR.ReadToFollowing("Login");
            string Login = XR.ReadElementContentAsString();
            Digest = Get_Digest();
            using (XmlWriter XW = XmlWriter.Create("Responce-1.xml"))
            {
                XW.WriteStartElement("Data");
                XW.WriteElementString("Login", Login);
                XW.WriteElementString("Digest", Digest);
                XW.WriteEndElement();
            }
            XmlDocument XD = new XmlDocument();
            XD.Load("Responce-1.xml");
            B = Encoding.UTF8.GetBytes(XD.OuterXml);
        }
        void Take_Request_2(byte[] D)
        {
            MemoryStream MS = new MemoryStream(D);
            XmlDocument XD = new XmlDocument();
            XD.Load(MS);
            XD.Save("Request-2.xml");
        }
        void Responce_2()
        {
            XmlReader XR = XmlReader.Create("Request-2.xml");
            XR.ReadToFollowing("Login");
            Login = XR.ReadElementContentAsString();
            XR.ReadToFollowing("Hash");
            string hash = XR.ReadElementContentAsString();
            using (XmlWriter XW = XmlWriter.Create("Responce-2.xml"))
            {
                XW.WriteStartElement("Data");
                Get_Values();
                Hash = Get_Hash(Digest + Values[0]);
                if (hash == Hash && Users.Contains(Login))
                {
                    XW.WriteElementString("Auth-Status", "Success");
                    XW.WriteElementString("Group", Values[1]);
                    XW.WriteEndElement();
                }
                else
                {
                    XW.WriteElementString("Auth-Status", "Fail");
                    XW.WriteEndElement();
                }
            }
            XmlDocument XD = new XmlDocument();
            XD.Load("Responce-2.xml");
            B = Encoding.UTF8.GetBytes(XD.OuterXml);
        }
    }
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;

namespace SPS_Lab1._1
{
    class Program
    {
        static void Main(string[] args)
        {
            WebClient WC = new WebClient();
            string ReadMe = WC.DownloadString("https://mail.univ.net.ua/readme.txt");
            File.WriteAllText("C:\\Users\\Bodix\\SPS\\SPS Lab1.1\\ReadMe.txt", ReadMe);
            string[] ReadText = File.ReadAllLines("C:\\Users\\Bodix\\SPS\\SPS Lab1.1\\ReadMe.txt");
            string FindWord = "WORD FOUND!!!";
            for (int i = 0; i < ReadText.Length; i++)
            {
                if (ReadText[i].Contains(args[0]))
                {
                    ReadText[i] = FindWord;
                }
            }
            string ReadText_Light = string.Join("\n", ReadText);
            File.WriteAllText("C:\\Users\\Bodix\\SPS\\SPS Lab1.1\\ReadMe-Light.txt", ReadText_Light);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;

namespace LAB1._1
{
    class Program
    {
        static void Main(string[] args)
        {
            
            WebClient WC = new WebClient();
            string Lsmod = WC.DownloadString("https://mail.univ.net.ua/lsmod.txt");
            File.WriteAllText("Lsmod.txt", Lsmod);
            string[] ReadText = File.ReadAllLines("Lsmod.txt");
            string SearchWord = "dm_region";
            for (int i = 0; i < ReadText.Length; i++)
            {
                if (ReadText[i].ToLower().Contains(args[0]) | ReadText[i].Contains(SearchWord.ToLower()))
                {
                    ReadText[i] = null;
                }
            }
            string ReadText_Light = string.Join("\n", ReadText);
            File.WriteAllText("Lsmod_LIGHT.txt", ReadText_Light);
        }
    }
}


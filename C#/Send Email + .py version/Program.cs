using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;

namespace LabSPS_1._2
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 2)
            {
                SmtpClient Message = new SmtpClient("smtp.gmail.com");
                Message.Port = 587;
                Message.Credentials = new NetworkCredential("barpenchuk", "password");
                Message.EnableSsl = true;
                Message.Send(new MailMessage("barpenchuk@gmail.com", args[0], args[1], $"{DateTime.Now} Karpenchuk Bohdan"));

            }
            else
            {
                Console.WriteLine("SYNTAX: <toAddr> <subject>");
            }
        }   
    }
}

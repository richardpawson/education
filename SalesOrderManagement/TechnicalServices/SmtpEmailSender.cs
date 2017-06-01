using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace TechnicalServices
{
    public class SmtpEmailSender : IEmailSender
    {
        public void SendMessage(string from, string to, string subject, string body)
        {
            var client = new SmtpClient("smtp.gmail.com", 587)
            {
                Credentials = new NetworkCredential("myEmail@gmail.com", "myGmailPassword"),
                EnableSsl = true
            };
            client.Send(from, to, subject,  body);
        }
    }
}

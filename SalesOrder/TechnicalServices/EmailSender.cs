using System.Net;
using System.Net.Mail;

namespace TechnicalServices
{
    public class EmailSender
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

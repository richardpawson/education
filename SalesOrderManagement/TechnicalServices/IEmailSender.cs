namespace TechnicalServices
{
    public interface IEmailSender
    {
        void SendMessage(string from, string to, string subject, string body);
    }
}

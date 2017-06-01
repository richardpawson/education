using Common.Logging;

namespace TechnicalServices
{
    //For testing purposes  -  does not send an email, but writes a message to the log file indicating that it has been sent.
    public class MockEmailSender : IEmailSender
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(MockEmailSender));

        public void SendMessage(string from, string to, string subject, string body)
        {
            Log.Warn(string.Format("Email with subject {0} would have been sent  from {1} to {2}",subject, from, to));
        }
    }
}

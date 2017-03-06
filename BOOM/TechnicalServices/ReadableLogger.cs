using System.Text;

namespace TechnicalServices
{
    //Implementation of ILogger with no actual UI. It captures the messages written, and allows
    //them to be read back programmatically via the ReadAndResetLog() method. Useful
    //for testing, or for use within another non-console UI.
    public class ReadableLogger : ILogger
    {
        private StringBuilder log = new StringBuilder();
        private bool Logging;
        public ReadableLogger()
        {
            StartLogging();
        }

        public string ReadAndResetLog()
        {
            var output = log.ToString();
            log = new StringBuilder();
            return output;
        }

        public void Write(string text)
        {
            if (Logging) log.Append(text);
        }
        public void WriteLine(string text = null)
        {
            if (Logging) log.Append(text);
        }
        public void PageBreak()
        {
            //does nothing at present
        }

        public void StartLogging()
        {
            Logging = true;
        }

        public void StopLogging()
        {
            Logging = false;
        }
    }
}

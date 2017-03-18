using System;

namespace TechnicalServices
{
    public class ConsoleLogger : ILogger
    {
        private bool Logging;

        public void Write(string text)
        {
            if (Logging) Console.Write(text);
        }
        public void WriteLine(string text = null)
        {
            if (Logging) Console.WriteLine(text);
        }
        public void PageBreak()
        {
            if (Logging) Console.ReadKey();
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

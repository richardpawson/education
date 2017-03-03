﻿using System.Text;
using TechnicalServices;

namespace Boom.Test
{
    public class TestLogger : ILogger
    {
        private StringBuilder log = new StringBuilder();
        private bool Logging;
        public TestLogger()
        {
            StartLogging();
        }

        internal string ReadAndResetLog()
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

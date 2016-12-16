using System;

namespace PredatorPrey
{
    class ConsoleLogger : ILogger
    {
        private bool logging;

        public void Write(string text)
        {
            if (logging) Console.Write(text);
        }
        public void WriteLine(string text = null)
        {
            if (logging) Console.WriteLine(text);
        }
        public void PageBreak()
        {
            if (logging) Console.ReadKey();
        }

        public void StartLogging()
        {
            logging = true;
        }

        public void StopLogging()
        {
            logging = false;
        }
    }
}

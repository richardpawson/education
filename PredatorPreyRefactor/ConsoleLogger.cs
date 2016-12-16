using System;

namespace PredatorPrey
{
    class ConsoleLogger : ILogger
    {
        public void Write(string text)
        {
            Console.Write(text);
        }
        public void WriteLine(string text = null)
        {
            Console.WriteLine(text);
        }
        public void PageBreak()
        {
            Console.ReadKey();
        }
    }
}

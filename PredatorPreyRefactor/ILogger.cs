
namespace PredatorPrey
{
    interface ILogger
    {
        void Write(string text);

        void WriteLine(string text = null);

        void PageBreak();

        void StartLogging();

        void StopLogging();
    }
}

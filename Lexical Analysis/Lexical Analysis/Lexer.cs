using System;
using System.IO;
using System.Text.RegularExpressions;

/// <summary>
/// Acknowledgement: This code taken from: http://stackoverflow.com/questions/673113/poor-mans-lexer-for-c-sharp 
/// </summary>

namespace LexicalAnalysis
{
public sealed class Lexer : IDisposable
{
    private readonly TextReader reader;
    private readonly TokenDefinition[] tokenDefinitions;

    private string lineRemaining;

    public Lexer(TextReader reader, TokenDefinition[] tokenDefinitions)
    {
        this.reader = reader;
        this.tokenDefinitions = tokenDefinitions;
        nextLine();
    }

    private void nextLine()
    {
        do
        {
            lineRemaining = reader.ReadLine();
            ++LineNumber;
            Position = 0;
        } while (lineRemaining != null && lineRemaining.Length == 0);
    }

    public bool More()
    {
        return lineRemaining != null;
    }
    public bool Next()
    {
        if (lineRemaining == null)
            return false;
        foreach (var def in tokenDefinitions)
        {
            var matched = def.Matcher.Match(lineRemaining);
            if (matched > 0)
            {
                Position += matched;
                Token = def.Token;
                TokenContents = lineRemaining.Substring(0, matched);
                lineRemaining = lineRemaining.Substring(matched);
                if (lineRemaining.Length == 0)
                    nextLine();

                return true;
            }
        }
        throw new Exception(string.Format("Unable to match against any tokens at line {0} position {1} \"{2}\"",
                                          LineNumber, Position, lineRemaining));
    }

    public string TokenContents { get; private set; }

    public object Token { get; private set; }

    public int LineNumber { get; private set; }

    public int Position { get; private set; }

    public void Dispose()
    {
        reader.Dispose();
    }
}
}
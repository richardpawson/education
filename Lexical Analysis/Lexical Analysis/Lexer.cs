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

    public bool TextRemaining()
    {
        return lineRemaining != null;
    }
    public Token NextToken()
    {
        if (lineRemaining == null)
            return null;
        foreach (var def in tokenDefinitions)
        {
            var matched = def.Matcher.Match(lineRemaining);
            if (matched > 0)
            {
                string contents = lineRemaining.Substring(0, matched);
                Token token = new Token(def.TokenName, contents, LineNumber, Position);
                lineRemaining = lineRemaining.Substring(matched);
                 if (lineRemaining.Length == 0) { nextLine(); }
                Position += matched;
                return token;
            }
        }
        throw new Exception(string.Format("Unable to match against any tokens at line {0} position {1} \"{2}\"",
                                          LineNumber, Position, lineRemaining));
    }

        private int LineNumber;

        private int Position;

    public void Dispose()
    {
        reader.Dispose();
    }
}
}
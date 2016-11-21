using System;
using System.IO;
using System.Text.RegularExpressions;

/// <summary>
/// Acknowledgement: This code taken from: http://stackoverflow.com/questions/673113/poor-mans-lexer-for-c-sharp 
/// </summary>
public interface IMatcher
{
    /// <summary>
    /// Return the number of characters that this "regex" or equivalent
    /// matches.
    /// </summary>
    /// <param name="text">The text to be matched</param>
    /// <returns>The number of characters that matched</returns>
    int Match(string text);
}

using System.Text.RegularExpressions;

namespace LexicalAnalysis
{
public class RegexMatcher
{
    private readonly Regex regex;
    public RegexMatcher(string regex)
    {
        this.regex = new Regex(string.Format("^{0}", regex)); // The ^ enforces that match must be at the start of the current (remaining) string
    }

    public int Match(string text)
    {
        var m = regex.Match(text);
        return m.Success ? m.Length : 0;
    }

    public override string ToString()
    {
        return regex.ToString();
    }
}
}

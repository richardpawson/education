namespace LexicalAnalysis
{
    public class TokenDefinition
    {
        public readonly RegexMatcher Matcher;
        public readonly string TokenName;

        public TokenDefinition(string regex, string tokenName)
        {
            this.Matcher = new RegexMatcher(regex);
            this.TokenName = tokenName;
        }
    }

}

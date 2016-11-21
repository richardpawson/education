namespace LexicalAnalysis
{

    public sealed class TokenDefinition
    {
        public readonly IMatcher Matcher;
        public readonly object Token;

        public TokenDefinition(string regex, object token)
        {
            this.Matcher = new RegexMatcher(regex);
            this.Token = token;
        }
    }

}

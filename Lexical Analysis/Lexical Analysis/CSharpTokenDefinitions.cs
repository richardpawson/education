namespace LexicalAnalysis
{
    public static class CSharpTokenDefinitions
    {

        public static TokenDefinition[] lexemes = new TokenDefinition[]
            {
                new TokenDefinition(@"\s", "SPACE"),

                //Add C# keywords here
                new TokenDefinition(@"public", "KEYWORD-PUBLIC"),
                new TokenDefinition(@"class", "KEYWORD-CLASS"),
                new TokenDefinition(@"[-+]?\d+", "KEYWORD-INT"),

                //Add recognised punctuation symbols here
                new TokenDefinition(@"\{", "BRACE-OPEN"),
                new TokenDefinition(@"\}", "BRACE-CLOSE"),
                new TokenDefinition(@"\=", "EQUALS"),
                new TokenDefinition(@"\;", "SEMI-COLON"),

                //Literals
                new TokenDefinition(@"([""'])(?:\\\1|.)*?\1", "QUOTED-STRING"),
                //to-add  -  numbers

                new TokenDefinition(@"[-+]?\d*\.\d+([eE][-+]?\d+)?", "FLOAT"),

                //Symbol should catch all valid constant, variable, parameter & function names
                new TokenDefinition(@"[*<>\?\-+/A-Za-z->!]+", "SYMBOL"),
            };
    }
}

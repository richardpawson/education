using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LexicalAnalysis
{
    public class Token
    {
        public string TokenName { get; private set; }

        public string Contents { get; private set; }

        public int LineNumber { get; private set; }

        public int CharacterPosition { get; private set; }


        public Token(string tokenName, string contents, int lineNumber, int position)
        {
            TokenName = tokenName;
            Contents = contents;
            LineNumber = lineNumber;
            CharacterPosition = position;
        }

        public override string ToString()
        {
            return TokenName;
        }
    }
}

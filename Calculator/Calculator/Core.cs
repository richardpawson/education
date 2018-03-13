using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator
{
    public class Core
    {
        private List<object> Tokens = new List<object>();

        public void Clear()
        {
            Tokens = new List<object>();
        }

        internal void AddSymbolAsToken(char symbol)
        {
            Tokens.Add(symbol);
        }

        public double AddNumberAsToken(string numberAsText)
        {
            double number = Convert.ToDouble(numberAsText);
            Tokens.Add(number);
            return number;
        }

        public string TokensAsString()
        {
            var sb = new StringBuilder();
            foreach (var token in Tokens)
            {
                sb.Append(token.ToString()).Append(" ");
            }
            return sb.ToString();
        }

        public double EvaluateTokensAsRPN()
        {
            return EvaluateAsRPN(Tokens);
        }

        public static double EvaluateAsRPN(List<object> Tokens)
        {
            throw new NotImplementedException();
        }

        public double EvaluateTokensAsInfix()
        {
            var tokensAsRPN = ConvertInfixToPostfix(Tokens);
            return EvaluateAsRPN(tokensAsRPN);
        }

        public static List<object> ConvertInfixToPostfix(List<object> inputTokens)
        {
            throw new NotImplementedException();
        }

        public static int Priority(char c)
        {
            throw new NotImplementedException();
        }
    }
}

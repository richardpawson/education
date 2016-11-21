using System;

namespace LexicalAnalysis
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //Note that the properties on the ExampleCode.cs file have Copy To Output Directly 
            //set to 'Copy Always' so it is in the path.
            //Alternatively specify a full path to a file e.g. "C:\Users\richard\Documents\ExampleCode.txt"
            var sourceCode = System.IO.File.OpenText(@"ExampleCode.txt");

            Lexer l = new Lexer(sourceCode, CSharpTokenDefinitions.lexemes);
            while (l.TextRemaining())
            {
                try
                {
                    Token token = l.NextToken();
                    Console.WriteLine("Token: {0} Contents: {1}", token, token.Contents);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    break;
                }                
            }
            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }
    }
}

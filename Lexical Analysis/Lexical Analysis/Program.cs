using System;

namespace LexicalAnalysis
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //Can also specify a full path to a file e.g. "C:\Users\richard\Documents\ExampleCode.cs"
            var sourceCode = System.IO.File.OpenText(@"C:\Users\richard\Documents\visual studio 2015\Projects\Lexical Analysis\Lexical Analysis\ExampleCode.cs");
            Lexer l = new Lexer(sourceCode, CSharpTokenDefinitions.lexemes);
            while (l.More())
            {
                try
                {
                    l.Next();
                    Console.WriteLine("Token: {0} Contents: {1}", l.Token, l.TokenContents);
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

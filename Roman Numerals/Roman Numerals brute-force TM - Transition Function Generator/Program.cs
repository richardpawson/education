using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    class Program
    {
        const char blank = ' ';
        const string startState = "S0";
        const string haltState = "S*";

        static void Main(string[] args)
        {
            foreach (var rule in RulesForRange(5))
            {
                Console.Write(rule.Format1());
            }
            Console.ReadKey();
        }

        static List<Rule> RulesForRange(int max)
        {
            List<Rule> rules = new List<Rule>();
            for (int i = 1; i <= max; i++)
            {
                string newState = State(i);
                char read = RightMostDigit(i);
                var previousState = "S" + TruncateLastDigit(i);
                rules.Add(new Rule(previousState, read, newState, blank, Direction.Right));
                var result = SubtractLargestPossibleSymbol(i);
                char write = result.Item1;
                int remainingValue = result.Item2;
                string nextState = remainingValue > 0 ? State(remainingValue) : haltState;
                rules.Add(new Rule(newState, blank, nextState, write, Direction.Right));
            }
            return rules;
        }

        static string State(int n)
        {
            return n > 0 ? "S" + n : startState;
        }

        //Returns the symbol and the REMAINING value
        static Tuple<char, int> SubtractLargestPossibleSymbol(int value)
        {
            if (value >= 1000) return Tuple.Create('M', value - 1000);
            if (value == 900) return Tuple.Create('C', value + 100);
            if (value >= 500) return Tuple.Create('D', value - 500);
            if (value == 400) return Tuple.Create('C', value + 100);
            if (value >= 100) return Tuple.Create('C', value - 100);
            if (value == 90) return Tuple.Create('X', value + 10);
            if (value >= 50) return Tuple.Create('L', value - 50);
            if (value == 40) return Tuple.Create('X', value + 10);
            if (value >= 10) return Tuple.Create('X', value - 10);
            if (value == 9) return Tuple.Create('I', value + 1);
            if (value >= 5) return Tuple.Create('V', value - 5);
            if (value == 4) return Tuple.Create('I', value + 1);
            return Tuple.Create('I', value - 1);
        }

        static int TruncateLastDigit(int n)
        {
            return n / 10;
        }

        static Char RightMostDigit(int n)
        {
            return Convert.ToChar(n.ToString().Substring(n.ToString().Length - 1, 1));
        }
    }

    public enum Direction
    {
        Left, Right
    }

    public class Rule
    {

        private string PreviousState;
        private char Read;
        private string NewState;
        private char Write;
        private Direction Direction;
        public Rule(string previousState, char read, string newState, char write, Direction dir)
        {
            PreviousState = previousState;
            Read = read;
            NewState = newState;
            Write = write;
            Direction = dir;
        }


        //This is the format for use with RP's Assembly Language Turing Machine
        public string Format1()
        {
            var dir = Direction == Direction.Right ? 'R' : 'L';
            return "d(" + PreviousState + "," + Read + ")=(" + NewState + "," + Write + "," + dir + ")";
        }

        //Format for use with https://turingmachinesimulator.com/ 
        public string Format2()
        {
            var dir = Direction == Direction.Right ? '>' : '<';
            return PreviousState + "," + Read + "\n" + NewState + "," + Write + "," + dir+"\n";
        }
    }

}

using System;
using System.Collections.Generic;
using System.IO;

namespace ConsoleApp1
{
    static class Constants
    {
        public const char blank = underscore;
        public const char underscore = '_';
        public const char space = ' ';
        public const string startState = "S0";
        public const string haltState = "S*";
    }
    class Program
    {


        static void Main(string[] args)
        {
            var rules = RulesForRange(2100);

            string path = @"C:\Users\rpaws\Desktop\RomanNumerals TM (brute force) for online simulator.txt";

            using (StreamWriter sw = File.AppendText(path))
            {
                sw.WriteLine("init:" + Constants.startState);
                sw.WriteLine("accept:" + Constants.haltState);
                sw.WriteLine();
                foreach (var rule in rules)
                {
                    sw.WriteLine(rule.Format2Selector());
                    sw.WriteLine(rule.Format2Action());
                    sw.WriteLine();
                }
            }

             path = @"C:\Users\rpaws\Desktop\RomanNumerals TM (brute force) for AQA AL emulator.txt";

            // Create a file to write to.
            using (StreamWriter sw = File.AppendText(path))
            {
                foreach (var rule in rules)
                {
                    sw.WriteLine(rule.Format1());
                }
            }
        }

        static List<Rule> RulesForRange(int max)
        {
            List<Rule> rules = new List<Rule>();
            for (int i = 1; i <= max; i++)
            {
                string newState = State(i);
                char read = RightMostDigit(i);
                var previousState = "S" + TruncateLastDigit(i);
                rules.Add(new Rule(previousState, read, newState, Constants.blank, Direction.Right));
                var result = SubtractLargestPossibleSymbol(i);
                char write = result.Item1;
                int remainingValue = result.Item2;
                string nextState = remainingValue > 0 ? State(remainingValue) : Constants.haltState;
                rules.Add(new Rule(newState, Constants.blank, nextState, write, Direction.Right));
            }
            return rules;
        }

        static string State(int n)
        {
            return n > 0 ? "S" + n : Constants.startState;
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
            var ReadChar = Read == Constants.underscore ? Constants.blank : Read;
            var WriteChar = Read == Constants.underscore ? Constants.blank : Write;
            var dir = Direction == Direction.Right ? 'R' : 'L';
            return "d(" + PreviousState + "," + ReadChar + ")=(" + NewState + "," + WriteChar + "," + dir + ")";
        }

        //Format for use with https://turingmachinesimulator.com/ 
        public string Format2Selector()
        {
            return PreviousState + "," + Read;
        }
        public string Format2Action()
        {
            var dir = Direction == Direction.Right ? '>' : '<';
            return NewState + "," + Write + "," + dir;
        }
    }

}

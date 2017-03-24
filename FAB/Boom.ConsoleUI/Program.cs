using System;
using TechnicalServices;
using Boom.Model;
using Boom.DataFixture;
using System.Collections.Immutable;

namespace Boom.ConsoleUI
{
    public class Program
    {
        static void Main(string[] args)
        {
            var noMisses = ImmutableList<Location>.Empty;
                GameBoard Board = null;

            int MenuOption = 0;
            while (MenuOption != 9)
            {
                DisplayMenu();
                MenuOption = GetMainMenuChoice();
                if (MenuOption == 1)
                {
                    var ships = Ships.UnplacedShips5();
                    Board = GameBoardFunctions.PlaceShipsRandomlyOnBoard(10, ships, new Random());
                }
                if (MenuOption == 2)
                {
                    var ships = Ships.TrainingGame();
                    Board = new GameBoard(10, ships, "", noMisses);
                }
                PlayGame(Board);
            }
        }

        private static void DisplayMenu()
        {
            Console.WriteLine("MAIN MENU");
            Console.WriteLine("");
            Console.WriteLine("1. Start new game");
            Console.WriteLine("2. Load training game");
            Console.WriteLine("9. Quit");
            Console.WriteLine();
        }

        private static int GetMainMenuChoice()
        {
            int Choice = 0;
            Console.Write("Please enter your choice: ");
            Choice = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();
            return Choice;
        }

        private static void PlayGame(GameBoard Board)
        {
            bool GameWon = false;
            //TODO: Make recursive!
            while (!GameWon)
            {
                PrintBoard(Board);
                var missileType = GetMissileType();
                var loc = GetLocation();
                if (missileType == "M")
                {
                    Board = Missile.Fire(loc, Board);
                }
                if (missileType == "B")
                {
                    Board = Bomb.Fire(loc, Board);
                }
                
            }
        }

        private static string GetMissileType()
        {
            Console.WriteLine();
            Console.Write("Please enter type (M) missile, (B) Bomb: ");
            return Console.ReadLine().ToUpper();
        }

        private static Location GetLocation()
        {
            Console.Write("Please enter column: ");
            var col =  Convert.ToInt32(Console.ReadLine());
            Console.Write("Please enter row: ");
            var row = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();
            return new Location(col, row);
        }

        private static void PrintBoard(GameBoard board)
        {
            int boardSize = board.Size;
            Console.WriteLine();
            Console.WriteLine("The board looks like this: ");
            Console.WriteLine();
            Console.Write(" ");
            for (int Column = 0; Column <boardSize; Column++)
            {
                Console.Write(" " + Column + "  ");
            }
            Console.WriteLine();
            for (int row = 0; row < boardSize; row++)
            {
                Console.Write(row + " ");
                for (int col = 0; col < boardSize; col++)
                {
                    //TODO: functionalise this!
                    var loc = new Location(col, row);
                    SquareValues square = board.ReadSquare(loc);
                    switch (square)
                    {
                        case SquareValues.Empty:
                            Console.Write(' ');
                            break;
                        case SquareValues.Miss:
                            Console.Write('m');
                            break;
                        case SquareValues.Hit:
                            Console.Write('h');
                            break;
                    }        
                    
                    if (col != boardSize - 1)
                    {
                        Console.Write(" | ");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}

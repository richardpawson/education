using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using TechnicalServices;

namespace Boom.Model
{
    public class GameBoard
    {
        public readonly int Size;
        public readonly ImmutableList<Tuple<int, int>> Misses;
        public readonly Ship[] Ships;
        public readonly ILogger Logger;
        public readonly IRandomGenerator RandomGenerator;

        /// <summary>
        /// </summary>
        /// <param name="size"></param>
        /// <param name="ships"></param>
        /// <param name="logger"></param>
        /// <param name="randomGenerator"></param>
        /// <param name="misses"></param>
        public GameBoard(int size, Ship[] ships, ILogger logger, IRandomGenerator randomGenerator, ImmutableList<Tuple<int, int>> misses)
        {
            Size = size;
            Logger = logger;
            RandomGenerator = randomGenerator;
            Ships = ships;
            Misses = misses;
        }



        //Checks, in collaboration with Ships, whether any of them cover
        //the given row, column; if one does, invoke the Hit() method on it.
        public static GameBoard CheckSquareAndRecordOutcome(GameBoard board, int col, int row)
        {
            foreach (Ship ship in board.Ships)
            {
                if (Ship.ShipOccupiesLocation(ship, col, row))
                {
                    Ship.Hit(ship, col, row);
                    if (Ship.IsSunk(ship))
                    {
                        board.Logger.WriteLine(ship.Name + " sunk!");
                    }
                    else
                    {
                        board.Logger.WriteLine("Hit a " + ship.Name + " at (" + col + "," + row + ").");
                    }
                    if (CheckWin(board))
                    {
                        board.Logger.WriteLine("All ships sunk!");
                        board.Logger.WriteLine();
                    }
                    return board;
                }
            }
            var newMisses = board.Misses.Add(Tuple.Create(col, row));
            board.Logger.WriteLine("Sorry, (" + col + "," + row + ") is a miss.");
            return new GameBoard(board.Size, board.Ships, board.Logger, board.RandomGenerator, newMisses);
        }

        //Returns true if the given position for the ship fits within the board 
        //and does not clash with another ship
        private static bool IsValidPosition(GameBoard board, Ship ship, int row, int col, Orientations orientation)
        {
            if (orientation == Orientations.Vertical && row + ship.Size > board.Size)
            {
                return false;
            }
            else if (orientation == Orientations.Horizontal && col + ship.Size > board.Size)
            {
                return false;
            }
            else
            {
                if (orientation == Orientations.Vertical)
                {
                    for (int scan = 0; scan < ship.Size; scan++)
                    {
                        if (Ship.ShipOccupiesLocation(ship, col+scan, row)) return false;
                    }
                }
                else if (orientation == Orientations.Horizontal)
                {
                    for (int scan = 0; scan < ship.Size; scan++)
                    {
                        if (Ship.ShipOccupiesLocation(ship, col, row+scan)) return false;
                    }
                }
            }
            return true;
        }
        //Returns true if all ships are sunk.
        public static bool CheckWin(GameBoard board)
        {
          return !board.Ships.Any(s => !Ship.IsSunk(s));
        }

        //Allows the actual array of squares to remain private
        public static SquareValues ReadSquare(GameBoard board, int col, int row)
        {
            if (board.Ships.Any(s => Ship.ShipIsHitInLocation(s, col, row)))
            {
                return SquareValues.Hit;
            }
            else if (board.Misses.Contains(Tuple.Create(col, row)))
            {
                return SquareValues.Miss;
            }
            else
            {
                return SquareValues.Empty;
            }
        }

        //In collaboration with IsValidPosition, finds a random but valid
        //position for each of the ships set up, whether or not they already
        //have a position specified.
        public static GameBoard RandomiseShipPlacement(GameBoard board)
        {
            var newShips = new List<Ship>(); 
            foreach (var ship in board.Ships)
            {
                Orientations orientation = 0; //default
                int row = 0;
                int col = 0;
                bool valid = false;
                while (valid == false)
                {
                    col = board.RandomGenerator.Next(0, board.Size);
                    row = board.RandomGenerator.Next(0, board.Size);
                    orientation = (Orientations) board.RandomGenerator.Next(0, 2);
                    valid = IsValidPosition(board, ship, row, col, orientation);
                }
                board.Logger.WriteLine("Computer placing the " + ship.Name);
                var newShip = Ship.SetPosition(ship, col, row, orientation);
                newShips.Add(newShip);
            }
            return new GameBoard(board.Size, newShips.ToArray(), board.Logger, board.RandomGenerator, board.Misses);
        }
    }
}
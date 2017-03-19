using System;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using TechnicalServices;

namespace Boom.Model
{
    public class GameBoard
    {
        public readonly int Size;
        public readonly ImmutableList<Tuple<int, int>> Misses;
        public readonly ImmutableArray<Ship> Ships;
        public readonly Random RandomGenerator;
        public readonly string Messages;
        private const string newLine = "\n";
        /// <summary>
        /// </summary>
        /// <param name="size"></param>
        /// <param name="ships"></param>
        /// <param name="logger"></param>
        /// <param name="randomGenerator"></param>
        /// <param name="misses"></param>
        public GameBoard(int size, ImmutableArray<Ship> ships, string messages,Random randomGenerator, ImmutableList<Tuple<int, int>> misses)
        {
            Size = size;
            Messages = messages;
            RandomGenerator = randomGenerator;
            Ships = ships;
            Misses = misses;
        }

        //Checks, in collaboration with Ships, whether any of them cover
        //the given row, column; if one does, invoke the Hit() method on it.
        public static GameBoard CheckSquareAndRecordOutcome(GameBoard board, int col, int row)
        {
            var newShips = ImmutableArray<Ship>.Empty;
            bool hit = false;
            var messages = new StringBuilder();
            foreach (Ship ship in board.Ships)
            {
                if (Ship.ShipOccupiesLocation(ship, col, row))
                {
                    hit = true;
                    var newShip = Ship.Hit(ship, col, row);
                    newShips = newShips.Add(newShip);
                    if (Ship.IsSunk(newShip))
                    {
                        messages.Append(newShip.Name + " sunk!");
                    }
                    else
                    {
                        messages.Append("Hit a " + newShip.Name + " at (" + col + "," + row + ").");
                    }
                }
                else
                {
                   newShips = newShips.Add(ship);
                }
            }
            var misses = board.Misses;
            if (!hit)
            {
                misses = board.Misses.Add(Tuple.Create(col, row));
                messages.Append("Sorry, (" + col + "," + row + ") is a miss.");
            }
            if (!newShips.Any(s => !Ship.IsSunk(s))) {
                messages.Append("All ships sunk!");
            }
            return new GameBoard(board.Size, newShips.ToImmutableArray(), messages.ToString(), board.RandomGenerator, misses);
        }

        private static bool IsValidPosition(GameBoard board, Ship ship, int row, int col, Orientations orientation)
        {
            if (!ShipWouldFitWithinBoard(board, ship, row, col, orientation))
            {
                return false;
            }

            else
            {
                if (orientation == Orientations.Vertical)
                {
                    for (int scan = 0; scan < ship.Size; scan++)
                    {
                        if (Ship.ShipOccupiesLocation(ship, col + scan, row)) return false;
                    }
                }
                else if (orientation == Orientations.Horizontal)
                {
                    for (int scan = 0; scan < ship.Size; scan++)
                    {
                        if (Ship.ShipOccupiesLocation(ship, col, row + scan)) return false;
                    }
                }
            }
            return true;
        }

        private static bool ShipWouldFitWithinBoard(GameBoard board, Ship ship, int row, int col, Orientations orientation)
        {
            return (orientation == Orientations.Vertical && row + ship.Size <= board.Size) ||
                   (orientation == Orientations.Horizontal && col + ship.Size <= board.Size);
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
            Random random1 = board.RandomGenerator;
            var newShips = ImmutableList<Ship>.Empty;
            var messages = "";
            foreach (var ship in board.Ships)
            {
                Orientations orientation = 0; //default
                int row = 0;
                int col = 0;
                bool valid = false;
                while (valid == false)
                {
                    var result1 = RandomNumbers.Next(random1, 0, board.Size);
                    col = result1.Item1;
                    var random2 = result1.Item2;

                    result = RandomNumbers.Next(random1, 0, board.Size);
                    col = result.Item1;
                    random1 = result.Item2;

                    result = RandomNumbers.Next(random1, 0, board.Size);
                    row = result.Item1;
                    random1 = result.Item2;

                    result = RandomNumbers.Next(random1, 0, 2);
                    orientation  = (Orientations) result.Item1;
                    random1 = result.Item2;

                    valid = IsValidPosition(board, ship, row, col, orientation);
                }
                messages =("Computer placing the " + ship.Name+newLine);
                var newShip = Ship.SetPosition(ship, col, row, orientation);
                newShips = newShips.Add(newShip);
            }
            return new GameBoard(board.Size, newShips.ToImmutableArray(), messages, random1, board.Misses);
        }
    }
}
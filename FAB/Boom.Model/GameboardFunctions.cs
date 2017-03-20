using System;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using TechnicalServices;

namespace Boom.Model
{
    public static class GameBoardFunctions
    {
        private const string newLine = "\n";

        //Checks, in collaboration with Ships, whether any of them cover
        //the given row, column; if one does, invoke the Hit() method on it.
        public static GameBoard CheckSquareAndRecordOutcome(this GameBoard board, int col, int row)
        {
            var newShips = ImmutableArray<Ship>.Empty;
            bool hit = false;
            var messages = new StringBuilder();
            foreach (Ship ship in board.Ships)
            {
                if (ship.ShipOccupiesLocation(col, row))
                {
                    hit = true;
                    var newShip = ship.Hit(col, row);
                    newShips = newShips.Add(newShip);
                    if (newShip.IsSunk())
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
            if (!newShips.Any(ship => !ship.IsSunk())) {
                messages.Append("All ships sunk!");
            }
            return new GameBoard(board.Size, newShips.ToImmutableArray(), messages.ToString(), board.RandomGenerator, misses);
        }

        private static bool IsValidPosition(this GameBoard board, Ship ship, int row, int col, Orientations orientation)
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
                        if (ship.ShipOccupiesLocation(col + scan, row)) return false;
                    }
                }
                else if (orientation == Orientations.Horizontal)
                {
                    for (int scan = 0; scan < ship.Size; scan++)
                    {
                        if (ship.ShipOccupiesLocation(col, row + scan)) return false;
                    }
                }
            }
            return true;
        }

        private static bool ShipWouldFitWithinBoard(this GameBoard board, Ship ship, int row, int col, Orientations orientation)
        {
            return (orientation == Orientations.Vertical && row + ship.Size <= board.Size) ||
                   (orientation == Orientations.Horizontal && col + ship.Size <= board.Size);
        }

        //Allows the actual array of squares to remain private
        public static SquareValues ReadSquare(this GameBoard board, int col, int row)
        {
            if (board.Ships.Any(s => s.IsHitInLocation(col, row)))
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
        public static GameBoard RandomiseShipPlacement(this GameBoard board)
        {
            Random random = board.RandomGenerator;
            var newShips = ImmutableList<Ship>.Empty;
            var messages = "";
            foreach (var ship in board.Ships)
            {
                var pos = GetValidRandomPosition(board, random, ship);
                random = pos.Item4;
                messages =("Computer placing the " + ship.Name+newLine);
                var newShip = ship.SetPosition(pos.Item1, pos.Item2, pos.Item3);
                newShips = newShips.Add(newShip);
            }
            return new GameBoard(board.Size, newShips.ToImmutableArray(), messages, random, board.Misses);
        }

        private static Tuple<int, int, Orientations, Random> GetValidRandomPosition(this GameBoard board, Random random1, Ship ship)
        {
            var pos = GetRandomPosition(board, random1);
            return IsValidPosition(board, ship, pos.Item1, pos.Item2, pos.Item3) ?
                pos :
                GetValidRandomPosition(board, pos.Item4, ship);
        }

        private static Tuple<int, int, Orientations, Random> GetRandomPosition(this GameBoard board, Random random1)
        {
            var result1 = RandomNumbers.Next(random1, 0, board.Size);
            var col = result1.Item1;
            var random2 = result1.Item2;

            var result2 = RandomNumbers.Next(random2, 0, board.Size);
            var row = result2.Item1;
            var random3 = result2.Item2;

            var result3 = RandomNumbers.Next(random3, 0, 2);
            var orientation = (Orientations)result3.Item1;
            var random4 = result3.Item2;

            return Tuple.Create(col, row, orientation, random4);
        }
    }
}
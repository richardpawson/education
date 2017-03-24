using System;
using System.Collections.Immutable;
using System.Linq;
using TechnicalServices;

namespace Boom.Model
{
    public static class GameBoardFunctions
    {
        private const string newLine = "\n";

        public static GameBoard CheckSquareAndRecordOutcome(this GameBoard board, int col, int row)
        {
            var results = board.Ships.Select(s => s.FireAt(col, row));
            var newShips = results.Select(r => r.Item1);
            var hit = results.Select(r => r.Item2).Aggregate((a, b) => a | b);
            var messages = results.Select(r => r.Item3).Aggregate((a, b) => a + b);
            var misses = board.Misses;
            if (hit)
            {
                if (!newShips.Any(ship => !ship.IsSunk()))
                {
                    var newMessage = messages + "All ships sunk!";
                    return new GameBoard(board.Size, newShips.ToImmutableArray(), newMessage, misses);
                }
                else
                {
                    return new GameBoard(board.Size, newShips.ToImmutableArray(), messages.ToString(), misses);
                }
            }
            else
            {
                var newMisses = board.Misses.Add(Tuple.Create(col, row));
                var newMessage = messages + "Sorry, (" + col + "," + row + ") is a miss.";
                return new GameBoard(board.Size, newShips.ToImmutableArray(), newMessage, newMisses);
            }
        }

        public static bool IsValidPosition(int boardSize, ImmutableArray<Ship> existingShips, Ship shipToBePlaced, int row, int col, Orientations orientation)
        {
            if (!ShipWouldFitWithinBoard(boardSize, shipToBePlaced, row, col, orientation))
            {
                return false;
            }
            else
            {
                var locs = LocationsThatShipWouldOccupy(col, row, orientation, shipToBePlaced.Size);
                //TODO: re-write using .SelectMany ?
                var occupiedLocations = from l in locs
                                        from s in existingShips
                                        where s.ShipOccupiesLocation(l.Item1, l.Item2)
                                        select l;
                return occupiedLocations.Count() == 0;
            }
        }

        public static ImmutableArray<Tuple<int, int>> LocationsThatShipWouldOccupy(int startCol, int startRow, Orientations orient, int locsToAdd)
        {
            if (locsToAdd == 0)
            {
                return ImmutableArray<Tuple<int, int>>.Empty;
            }
            else
            {
                var loc = Tuple.Create(startCol, startRow);
                if (orient == Orientations.Horizontal)
                {
                    return LocationsThatShipWouldOccupy(startCol + 1, startRow, orient, locsToAdd - 1).Add(loc);
                }
                else //i.e. vertical
                {
                    return LocationsThatShipWouldOccupy(startCol, startRow + 1, orient, locsToAdd - 1).Add(loc);
                }
            }
        }

        public static bool ShipWouldFitWithinBoard(int boardSize, Ship ship, int row, int col, Orientations orientation)
        {
            return (orientation == Orientations.Vertical && row + ship.Size <= boardSize) ||
                   (orientation == Orientations.Horizontal && col + ship.Size <= boardSize);
        }

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

        public static GameBoard PlaceShipsRandomlyOnBoard(int boardSize, ImmutableArray<Ship> shipsToBePlaced, Random random)
        {
            var shipPlacements = LocateShipsRandomly(boardSize, shipsToBePlaced, ImmutableArray<Ship>.Empty, random);
            var newShips = shipPlacements.Select(r => r.Item1).ToImmutableArray();
            string messages = shipPlacements.Select(r => r.Item2).Aggregate((r, s) => r + s);
            var noMisses = ImmutableList<Tuple<int, int>>.Empty;
            return new GameBoard(boardSize, newShips, messages, noMisses);
        }

        public static ImmutableList<Tuple<Ship, string>> LocateShipsRandomly(int boardSize, ImmutableArray<Ship> shipsToBePlaced, ImmutableArray<Ship> shipsAlreadyPlaced, Random random)
        {
            if (shipsToBePlaced.Count() == 0)
            {
                return ImmutableList<Tuple<Ship, string>>.Empty;
            }
            else
            {
                var thisShip = shipsToBePlaced[0];
                var result = LocateShipRandomly(boardSize, shipsAlreadyPlaced, thisShip, random);
                var shipPlacement = Tuple.Create(result.Item1, result.Item2);
                var newRandom = result.Item3;
                var newshipsAlreadyPlaced = shipsAlreadyPlaced.Add(result.Item1);
                var newShipsToBePlaced = shipsToBePlaced.Remove(thisShip);
                return LocateShipsRandomly(boardSize, newShipsToBePlaced, newshipsAlreadyPlaced, newRandom).Add(shipPlacement);
            }
        }

        public static Tuple<Ship, string, Random> LocateShipRandomly(int boardSize, ImmutableArray<Ship> shipsAlreadyLocated, Ship shipToBeLocated, Random random)
        {
            var pos = GetValidRandomPosition(boardSize, shipsAlreadyLocated, shipToBeLocated, random);
            var message = "Computer placing the " + shipToBeLocated.Name + newLine;
            var newShip = shipToBeLocated.SetPosition(pos.Item1, pos.Item2, pos.Item3);
            return Tuple.Create(newShip, message, pos.Item4);
        }

        public static Tuple<int, int, Orientations, Random> GetValidRandomPosition(int boardSize, ImmutableArray<Ship> shipsAlreadyLocated, Ship shipToBeLocated, Random random)
        {
            var pos = GetRandomPosition(boardSize, random);
            return IsValidPosition(boardSize, shipsAlreadyLocated, shipToBeLocated, pos.Item1, pos.Item2, pos.Item3) ?
                pos :
                GetValidRandomPosition(boardSize, shipsAlreadyLocated, shipToBeLocated, pos.Item4);
        }

        public static Tuple<int, int, Orientations, Random> GetRandomPosition(int boardSize, Random random1)
        {
            var result1 = RandomNumbers.Next(random1, 0, boardSize);
            var col = result1.Item1;

            var result2 = RandomNumbers.Next(result1.Item2, 0, boardSize);
            var row = result2.Item1;

            var result3 = RandomNumbers.Next(result2.Item2, 0, 2);
            var orientation = (Orientations)result3.Item1;

            return Tuple.Create(col, row, orientation, result3.Item2);
        }
    }
}
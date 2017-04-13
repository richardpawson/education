using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using TechnicalServices;

namespace Boom.Model
{
    public static class GameBoardFunctions
    {
        private const string newLine = "\n";

        public static bool AllShipsSunk(IEnumerable<Ship> ships)
        {
            return !ships.Any(ship => !ship.IsSunk());
        }

        public static GameBoard CheckSquareAndRecordOutcome(this GameBoard board, Location loc, bool aggregateMessages = false)
        {
            var results = board.Ships.Select(s => s.FireAt(loc));
            var newShips = results.Select(r => r.Item1);
            var hit = results.Select(r => r.Item2).Aggregate((a, b) => a | b);
            string newMessages = results.Select(r => r.Item3).Aggregate((a, b) => a + b);
            var aggregatedMessages = aggregateMessages ? board.Messages + newMessages : newMessages;
            var misses = board.Misses;
            if (hit)
            {
                if (AllShipsSunk(newShips))
                {
                    var newMessage = newMessages + "All ships sunk!";
                    return new GameBoard(board.Size, newShips.ToImmutableArray(), newMessage, misses);
                }
                else
                {
                    return new GameBoard(board.Size, newShips.ToImmutableArray(), aggregatedMessages, misses);
                }
            }
            else
            {
                var newMisses = board.Misses.Add(loc);
                var newMessage = aggregatedMessages + "Sorry, (" + loc.Col + "," + loc.Row + ") is a miss.";
                return new GameBoard(board.Size, newShips.ToImmutableArray(), newMessage, newMisses);
            }
        }

        public static GameBoard CheckSquaresAndRecordOutcome(this GameBoard board, IImmutableList<Location> locs)
        {
            var boardFromHead = CheckSquareAndRecordOutcome(board, locs.First(), true);
            if (locs.Count() == 1)
            {
                return boardFromHead;
            }
            else
            {
                return CheckSquaresAndRecordOutcome(boardFromHead, locs.Remove(locs.First()));
            }
        }

        public static bool IsValidPosition(int boardSize, IImmutableList<Ship> existingShips, Ship shipToBePlaced, Location loc, Orientations orientation)
        {
            if (!ShipWouldFitWithinBoard(boardSize, shipToBePlaced, loc, orientation))
            {
                return false;
            }
            else
            {
                var locs = LocationsThatShipWouldOccupy(loc, orientation, shipToBePlaced.Size);
                var occupiedLocations = from l in locs
                                        from s in existingShips
                                        where s.ShipOccupiesLocation(l)
                                        select loc;
                return occupiedLocations.Count() == 0;
            }
        }

        public static ImmutableArray<Location> LocationsThatShipWouldOccupy(Location loc, Orientations orient, int locsToAdd)
        {
            if (locsToAdd == 0)
            {
                return ImmutableArray<Location>.Empty;
            }
            else
            {
                if (orient == Orientations.Horizontal)
                {
                    return LocationsThatShipWouldOccupy(loc.Add(1, 0), orient, locsToAdd - 1).Add(loc);
                }
                else
                {
                    return LocationsThatShipWouldOccupy(loc.Add(0, 1), orient, locsToAdd - 1).Add(loc);
                }
            }
        }

        public static bool ShipWouldFitWithinBoard(int boardSize, Ship ship, Location loc, Orientations orientation)
        {
            return (orientation == Orientations.Horizontal && loc.Col + ship.Size <= boardSize) ||
                (orientation == Orientations.Vertical && loc.Row + ship.Size <= boardSize);
        }

        public static bool Contains(this GameBoard board, Location loc)
        {
            int boardSize = board.Size;
            return loc.Col >= 0 && loc.Col < boardSize && loc.Row >= 0 && loc.Row < boardSize;
        }

        public static SquareValues ReadSquare(this GameBoard board, Location loc)
        {
            if (board.Ships.Any(s => s.IsHitInLocation(loc)))
            {
                return SquareValues.Hit;
            }
            else if (board.Misses.Contains(loc))
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
            var noMisses = ImmutableList<Location>.Empty;
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
            var newShip = shipToBeLocated.SetPosition(pos.Item1, pos.Item2);
            return Tuple.Create(newShip, message, pos.Item3);
        }

        public static Tuple<Location, Orientations, Random> GetValidRandomPosition(int boardSize, ImmutableArray<Ship> shipsAlreadyLocated, Ship shipToBeLocated, Random random)
        {
            var pos = GetRandomPosition(boardSize, random);
            return IsValidPosition(boardSize, shipsAlreadyLocated, shipToBeLocated, pos.Item1, pos.Item2) ?
                pos :
                GetValidRandomPosition(boardSize, shipsAlreadyLocated, shipToBeLocated, pos.Item3);
        }

        public static Tuple<Location, Orientations, Random> GetRandomPosition(int boardSize, Random random)
        {
            var result1 = RandomNumbers.Next(random, 0, boardSize);
            var col = result1.Number;

            var result2 = RandomNumbers.Next(result1.NewGenerator, 0, boardSize);
            var row = result2.Number;

            var result3 = RandomNumbers.Next(result2.NewGenerator, 0, 2);
            var orientation = (Orientations)result3.Number;

            var loc = new Location(col, row);
            return Tuple.Create(loc, orientation, result3.NewGenerator);
        }


    }
}
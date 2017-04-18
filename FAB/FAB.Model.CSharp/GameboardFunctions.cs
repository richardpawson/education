using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using TechnicalServices;

namespace FAB.Model
{
    public static class GameBoardFunctions
    {
        private const string newLine = "\n";

        public static bool allSunk(IEnumerable<Ship> ships)
        {
            return !ships.Any(ship => !ship.isSunk());
        }

        public static GameBoard checkSquareAndRecordOutcome(this GameBoard board, Location loc, bool aggregateMessages = false)
        {
            var results = board.Ships.Select(s => s.fireAt(loc));
            var newShips = results.Select(r => r.Item1);
            var hit = results.Select(r => r.Item2).Aggregate((a, b) => a | b);
            string newMessages = results.Select(r => r.Item3).Aggregate((a, b) => a + b);
            var aggregatedMessages = aggregateMessages ? board.Messages + newMessages : newMessages;
            var misses = board.Misses;
            if (hit)
            {
                if (allSunk(newShips))
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

        public static GameBoard checkSquaresAndRecordOutcome(this GameBoard board, IImmutableList<Location> locs)
        {
            var boardFromHead = checkSquareAndRecordOutcome(board, locs.First(), true);
            if (locs.Count() == 1)
            {
                return boardFromHead;
            }
            else
            {
                return checkSquaresAndRecordOutcome(boardFromHead, locs.Remove(locs.First()));
            }
        }

        public static bool isValidPosition(int boardSize, IImmutableList<Ship> existingShips, Ship shipToBePlaced, Location loc, Orientations orientation)
        {
            if (!shipWouldFitWithinBoard(boardSize, shipToBePlaced, loc, orientation))
            {
                return false;
            }
            else
            {
                var locs = locationsThatShipWouldOccupy(loc, orientation, shipToBePlaced.Size);
                var occupiedLocations = from l in locs
                                        from s in existingShips
                                        where s.occupies(l)
                                        select loc;
                return occupiedLocations.Count() == 0;
            }
        }

        public static ImmutableArray<Location> locationsThatShipWouldOccupy(Location loc, Orientations orient, int locsToAdd)
        {
            if (locsToAdd == 0)
            {
                return ImmutableArray<Location>.Empty;
            }
            else
            {
                if (orient == Orientations.Horizontal)
                {
                    return locationsThatShipWouldOccupy(loc.Add(1, 0), orient, locsToAdd - 1).Add(loc);
                }
                else
                {
                    return locationsThatShipWouldOccupy(loc.Add(0, 1), orient, locsToAdd - 1).Add(loc);
                }
            }
        }

        public static bool shipWouldFitWithinBoard(int boardSize, Ship ship, Location loc, Orientations orientation)
        {
            return (orientation == Orientations.Horizontal && loc.Col + ship.Size <= boardSize) ||
                (orientation == Orientations.Vertical && loc.Row + ship.Size <= boardSize);
        }

        public static bool contains(this GameBoard board, Location loc)
        {
            int boardSize = board.Size;
            return loc.Col >= 0 && loc.Col < boardSize && loc.Row >= 0 && loc.Row < boardSize;
        }

        public static SquareValues readSquare(this GameBoard board, Location loc)
        {
            if (board.Ships.Any(s => s.isHitInLocation(loc)))
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

        public static GameBoard createBoardWithShipsPlacedRandomly(int boardSize, ImmutableArray<Ship> shipsToBePlaced, Random random)
        {
            var shipPlacements = locateShipsRandomly(boardSize, shipsToBePlaced, ImmutableArray<Ship>.Empty, random);
            var newShips = shipPlacements.Select(r => r.Item1).ToImmutableArray();
            string messages = shipPlacements.Select(r => r.Item2).Aggregate((r, s) => r + s);
            var noMisses = ImmutableList<Location>.Empty;
            return new GameBoard(boardSize, newShips, messages, noMisses);
        }

        public static ImmutableList<Tuple<Ship, string>> locateShipsRandomly(int boardSize, ImmutableArray<Ship> shipsToBePlaced, ImmutableArray<Ship> shipsAlreadyPlaced, Random random)
        {
            if (shipsToBePlaced.Count() == 0)
            {
                return ImmutableList<Tuple<Ship, string>>.Empty;
            }
            else
            {
                var thisShip = shipsToBePlaced[0];
                var result = locateShipRandomly(boardSize, shipsAlreadyPlaced, thisShip, random);
                var shipPlacement = Tuple.Create(result.Item1, result.Item2);
                var newRandom = result.Item3;
                var newshipsAlreadyPlaced = shipsAlreadyPlaced.Add(result.Item1);
                var newShipsToBePlaced = shipsToBePlaced.Remove(thisShip);
                return locateShipsRandomly(boardSize, newShipsToBePlaced, newshipsAlreadyPlaced, newRandom).Insert(0, shipPlacement);
            }
        }

        public static Tuple<Ship, string, Random> locateShipRandomly(int boardSize, ImmutableArray<Ship> shipsAlreadyLocated, Ship shipToBeLocated, Random random)
        {
            var pos = getValidRandomPosition(boardSize, shipsAlreadyLocated, shipToBeLocated, random);
            var message = "Computer placing the " + shipToBeLocated.Name + newLine;
            var newShip = shipToBeLocated.setPosition(pos.Item1, pos.Item2);
            return Tuple.Create(newShip, message, pos.Item3);
        }

        public static Tuple<Location, Orientations, Random> getValidRandomPosition(int boardSize, ImmutableArray<Ship> shipsAlreadyLocated, Ship shipToBeLocated, Random random)
        {
            var pos = getRandomPosition(boardSize, random);
            return isValidPosition(boardSize, shipsAlreadyLocated, shipToBeLocated, pos.Item1, pos.Item2) ?
                pos :
                getValidRandomPosition(boardSize, shipsAlreadyLocated, shipToBeLocated, pos.Item3);
        }

        public static Tuple<Location, Orientations, Random> getRandomPosition(int boardSize, Random random)
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
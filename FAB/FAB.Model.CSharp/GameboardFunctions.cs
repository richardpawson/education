using FunctionalLibrary;
using System;
using System.Collections.Immutable;
using System.Linq;

namespace FAB.Model
{
    public static class GameBoardFunctions
    {
        private const string newLine = "\n";

        public static bool allSunk(FList<Ship> ships)
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
                    return new GameBoard(board.Size, newShips, newMessage, misses);
                }
                else
                {
                    return new GameBoard(board.Size, newShips, aggregatedMessages, misses);
                }
            }
            else
            {
                var newMisses = board.Misses.Add(loc);
                var newMessage = aggregatedMessages + "Sorry, (" + loc.Col + "," + loc.Row + ") is a miss.";
                return new GameBoard(board.Size, newShips, newMessage, newMisses);
            }
        }

        public static GameBoard checkSquaresAndRecordOutcome(this GameBoard board, FList<Location> locs)
        {
            var boardFromHead = checkSquareAndRecordOutcome(board, locs.Head, true);
            if (locs.Count() == 1)
            {
                return boardFromHead;
            }
            else
            {
                return checkSquaresAndRecordOutcome(boardFromHead, locs.Remove(locs.Head));
            }
        }

        public static bool isValidPosition(int boardSize, FList<Ship> existingShips, Ship shipToBePlaced)
        {
            if (!shipWouldFitWithinBoard(boardSize, shipToBePlaced))
            {
                return false;
            }
            else
            {
                return !existingShips.Any(s => s.intersects(shipToBePlaced));
            }
        }

        public static FList<Location> locationsThatShipWouldOccupy(Location loc, Orientations orient, int locsToAdd)
        {
            if (locsToAdd == 0)
            {
                return FList.Empty<Location>();
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

        public static bool shipWouldFitWithinBoard(int boardSize, Ship ship)
        {
            return (ship.Orientation == Orientations.Horizontal && ship.Location.Col + ship.Size <= boardSize) ||
                (ship.Orientation == Orientations.Vertical && ship.Location.Row + ship.Size <= boardSize);
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

        public static GameBoard createBoardWithShipsPlacedRandomly(int boardSize, FList<Ship> shipsToBePlaced, RandomResult random)
        {
            var shipPlacements = locateShipsRandomly(boardSize, shipsToBePlaced, FList.Empty<Ship>(), random);
            var newShips = shipPlacements.Select(r => r.Item1);
            string messages = shipPlacements.Select(r => r.Item2).Aggregate((r, s) => r + s);
            var noMisses = FList.Empty<Location>();
            return new GameBoard(boardSize, newShips, messages, noMisses);
        }

        public static FList<Tuple<Ship, string>> locateShipsRandomly(int boardSize, FList<Ship> shipsToBePlaced, FList<Ship> shipsAlreadyPlaced, RandomResult random)
        {
            if (shipsToBePlaced.Count() == 0)
            {
                return FList.Empty<Tuple<Ship, string>>();
            }
            else
            {
                var thisShip = shipsToBePlaced.Head;
                var result = locateShipRandomly(boardSize, shipsAlreadyPlaced, thisShip, random);
                var shipPlacement = Tuple.Create(result.Item1, result.Item2);
                var newRandom = result.Item3;
                var newshipsAlreadyPlaced = shipsAlreadyPlaced.Add(result.Item1);
                var newShipsToBePlaced = shipsToBePlaced.Remove(thisShip);
                return FList.Cons(shipPlacement, locateShipsRandomly(boardSize, newShipsToBePlaced, newshipsAlreadyPlaced, newRandom));
            }
        }

        public static Tuple<Ship, string, RandomResult> locateShipRandomly(int boardSize, FList<Ship> shipsAlreadyLocated, Ship shipToBeLocated, RandomResult random)
        {
            var pos = getValidRandomPosition(boardSize, shipsAlreadyLocated, shipToBeLocated, random);
            var message = "Computer placing the " + shipToBeLocated.Name + newLine;
            var newShip = shipToBeLocated.setPosition(pos.Item1, pos.Item2);
            return Tuple.Create(newShip, message, pos.Item3);
        }

        public static Tuple<Location, Orientations, RandomResult> getValidRandomPosition(int boardSize, FList<Ship> shipsAlreadyLocated, Ship shipToBeLocated, RandomResult random)
        {
            var pos = getRandomPosition(boardSize, random);
            var hypotheticalShip = new Ship(shipToBeLocated.Name, shipToBeLocated.Size, pos.Item1, pos.Item2);
            return isValidPosition(boardSize, shipsAlreadyLocated, hypotheticalShip) ?
                pos :
                getValidRandomPosition(boardSize, shipsAlreadyLocated, shipToBeLocated, pos.Item3);
        }

        public static Tuple<Location, Orientations, RandomResult> getRandomPosition(int boardSize, RandomResult random)
        {
            var random1 = random.Next(0, boardSize);
            var col = random1.Number;

            var random2 = random1.Next(0, boardSize);
            var row = random2.Number;

            var random3 = random2.Next(0, 2);
            var orientation = (Orientations)random3.Number;

            var loc = new Location(col, row);
            return Tuple.Create(loc, orientation, random3);
        }

        public static Location Add(this Location loc, int colInc, int rowInc)
        {
            return new Location(loc.Col + colInc, loc.Row + rowInc);
        }
    }
}
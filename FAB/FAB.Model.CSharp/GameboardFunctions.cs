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

        public static GameBoard checkSquareAndRecordOutcome(this GameBoard board, Location loc, bool aggregate = false)
        {
            return HitSomething(board, loc) ?
                allSunk(ShipsAfterFiring(board, loc)) ?
                     new GameBoard(board.Size, ShipsAfterFiring(board, loc), MessagesAfterFiring(board, loc) + "All ships sunk!", board.Misses)
                     : new GameBoard(board.Size, ShipsAfterFiring(board, loc), AggregatedMessages(board, aggregate, MessagesAfterFiring(board, loc)), board.Misses)
                : new GameBoard(board.Size, ShipsAfterFiring(board, loc), AddMissMsg(board, loc, aggregate, MessagesAfterFiring(board, loc)), board.Misses.Add(loc));
        }

        private static bool HitSomething(GameBoard board, Location loc)
        {
            return board.Ships.Select(s => s.fireAt(loc).Item2).Aggregate((a, b) => a | b);
        }

        private static string MessagesAfterFiring(GameBoard board, Location loc)
        {
            return board.Ships.Select(s => s.fireAt(loc).Item3).Aggregate((a, b) => a + b);
        }

        private static FList<Ship> ShipsAfterFiring(GameBoard board, Location loc)
        {
            return board.Ships.Select(s => s.fireAt(loc).Item1);
        }

        private static string AddMissMsg(GameBoard board, Location loc, bool aggregate, string newMessages)
        {
            return AggregatedMessages(board, aggregate, newMessages) + "Sorry, (" + loc.Col + "," + loc.Row + ") is a miss.";
        }

        private static string AggregatedMessages(GameBoard board, bool aggregateMessages, string newMessages)
        {
            return aggregateMessages ? board.Messages + newMessages : newMessages;
        }

        public static GameBoard checkSquaresAndRecordOutcome(this GameBoard board, FList<Location> locs)
        {
            return locs.Count() == 1 ?
                checkSquareAndRecordOutcome(board, locs.Head, true)
                : checkSquaresAndRecordOutcome(checkSquareAndRecordOutcome(board, locs.Head, true), locs.Remove(locs.Head));
        }

        public static bool isValidPosition(int boardSize, FList<Ship> existingShips, Ship shipToBePlaced)
        {
            return !shipWouldFitWithinBoard(boardSize, shipToBePlaced) ?
                 false
                 : !existingShips.Any(s => s.intersects(shipToBePlaced));
        }

        public static FList<Location> locationsThatShipWouldOccupy(Location loc, Orientations orient, int locsToAdd)
        {
            return locsToAdd == 0 ?
                 FList.Empty<Location>()
                 : orient == Orientations.Horizontal ?
                         locationsThatShipWouldOccupy(loc.Add(1, 0), orient, locsToAdd - 1).Add(loc)
                         : locationsThatShipWouldOccupy(loc.Add(0, 1), orient, locsToAdd - 1).Add(loc);
        }

        public static bool shipWouldFitWithinBoard(int boardSize, Ship ship)
        {
            return (ship.Orientation == Orientations.Horizontal
                        && ship.Location.Col + ship.Size <= boardSize)
                    ||
                    (ship.Orientation == Orientations.Vertical
                        && ship.Location.Row + ship.Size <= boardSize);
        }

        public static bool contains(this GameBoard board, Location loc)
        {
            return loc.Col >= 0 && loc.Col < board.Size && loc.Row >= 0 && loc.Row < board.Size;
        }

        public static SquareValues readSquare(this GameBoard board, Location loc)
        {
            return board.Ships.Any(s => s.isHitInLocation(loc)) ?
                SquareValues.Hit
                : board.Misses.Contains(loc) ?
                    SquareValues.Miss
                    : SquareValues.Empty;
        }

        public static GameBoard createBoardWithShipsPlacedRandomly(int boardSize, FList<Ship> shipsToBePlaced, RandomResult random)
        {
            return new GameBoard(
                boardSize,
                locateShipsRandomly(boardSize, shipsToBePlaced, FList.Empty<Ship>(), random).Select(r => r.Item1),
                locateShipsRandomly(boardSize, shipsToBePlaced, FList.Empty<Ship>(), random).Select(r => r.Item2).Aggregate((r, s) => r + s),
                ImmutableHashSet.Create<Location>()
            );
        }

        public static FList<Tuple<Ship, string>> locateShipsRandomly(int boardSize, FList<Ship> shipsToBePlaced, FList<Ship> shipsAlreadyPlaced, RandomResult random)
        {
            return shipsToBePlaced.Count() == 0 ?
                FList.Empty<Tuple<Ship, string>>()
                : FList.Cons(
                    Tuple.Create(
                        locateShipRandomly(boardSize, shipsAlreadyPlaced, shipsToBePlaced.Head, random).Item1,
                        locateShipRandomly(boardSize, shipsAlreadyPlaced, shipsToBePlaced.Head, random).Item2
                    ),
                    locateShipsRandomly(
                        boardSize,
                        shipsToBePlaced.Remove(shipsToBePlaced.Head),
                        shipsAlreadyPlaced.Add(locateShipRandomly(boardSize, shipsAlreadyPlaced, shipsToBePlaced.Head, random).Item1),
                        locateShipRandomly(boardSize, shipsAlreadyPlaced, shipsToBePlaced.Head, random).Item3
                    )
                );
        }

        public static Tuple<Ship, string, RandomResult> locateShipRandomly(
            int boardSize, FList<Ship> shipsAlreadyLocated, Ship shipToBeLocated, RandomResult random)
        {
            return Tuple.Create(
                shipToBeLocated.setPosition(
                    getValidRandomPosition(boardSize, shipsAlreadyLocated, shipToBeLocated, random).Item1,
                    getValidRandomPosition(boardSize, shipsAlreadyLocated, shipToBeLocated, random).Item2),
                "Computer placing the " + shipToBeLocated.Name + newLine,
                getValidRandomPosition(boardSize, shipsAlreadyLocated, shipToBeLocated, random).Item3);
        }

        public static Tuple<Location, Orientations, RandomResult> getValidRandomPosition(int boardSize, FList<Ship> shipsAlreadyLocated, Ship shipToBeLocated, RandomResult random)
        {
            return isValidPosition(
                    boardSize,
                    shipsAlreadyLocated,
                    new Ship(shipToBeLocated.Name, shipToBeLocated.Size, getRandomPosition(boardSize, random).Item1,
                    getRandomPosition(boardSize, random).Item2)
                ) ?
                getRandomPosition(boardSize, random)
                : getValidRandomPosition(
                    boardSize,
                    shipsAlreadyLocated,
                    shipToBeLocated,
                    getRandomPosition(boardSize, random).Item3
                  );
        }

        public static Tuple<Location, Orientations, RandomResult> getRandomPosition(int boardSize, RandomResult random)
        {
            return Tuple.Create(
                new Location(random.Next(0, boardSize).Number, random.Next(0, boardSize).Next(0, boardSize).Number),
                (Orientations)random.Next(0, boardSize).Next(0, boardSize).Next(0, 2).Number,
                random.Next(0, boardSize).Next(0, boardSize).Next(0, 2));
        }

        public static Location Add(this Location loc, int colInc, int rowInc)
        {
            return new Location(loc.Col + colInc, loc.Row + rowInc);
        }
    }
}
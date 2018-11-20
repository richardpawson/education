using Quadrivia.FunctionalLibrary;
using System;
using System.Collections.Immutable;
using System.Linq;

namespace Quadrivia.FAB
{
    public static class GameBoardFunctions
    {
        private const string newLine = "\n";

        public static bool allSunk(FList<Ship> ships)
        {
            return !FList.Any(ship => !ship.isSunk(), ships);
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
            return FList.FoldL((a, b) => a | b, false, FList.Map(s => s.fireAt(loc).Item2, board.Ships));
        }
        //TODO: Check use of FoldL vs FoldR here and above
        private static string MessagesAfterFiring(GameBoard board, Location loc)
        {
            return FList.FoldL((a, b) => a + b, "",FList.Map(s => s.fireAt(loc).Item3, board.Ships));
        }

        private static FList<Ship> ShipsAfterFiring(GameBoard board, Location loc)
        {
            return FList.Map(s => s.fireAt(loc).Item1, board.Ships);
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
            return FList.Length(locs) == 1 ?
                checkSquareAndRecordOutcome(board, FList.Head(locs), true)
                : checkSquaresAndRecordOutcome(checkSquareAndRecordOutcome(board, FList.Head(locs), true), FList.RemoveFirst(FList.Head(locs), locs));
        }

        public static bool isValidPosition(int boardSize, FList<Ship> existingShips, Ship shipToBePlaced)
        {
            return !shipWouldFitWithinBoard(boardSize, shipToBePlaced) ?
                 false
                 : !FList.Any(s => s.intersects(shipToBePlaced), existingShips);
        }

        public static FList<Location> locationsThatShipWouldOccupy(Location loc, Orientations orient, int locsToAdd)
        {
            return locsToAdd == 0 ?
                 FList.Empty<Location>()
                 : orient == Orientations.Horizontal ?
                         locationsThatShipWouldOccupy(loc.Add(1, 0), orient, locsToAdd - 1)
                         : FList.Prepend(loc,locationsThatShipWouldOccupy(loc.Add(0, 1), orient, locsToAdd - 1));
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
            return FList.Any(s => s.isHitInLocation(loc), board.Ships) ?
                SquareValues.Hit
                : board.Misses.Contains(loc) ?
                    SquareValues.Miss
                    : SquareValues.Empty;
        }

        public static GameBoard createBoardWithShipsPlacedRandomly(int boardSize, FList<Ship> shipsToBePlaced, FRandom random)
        {
            return new GameBoard(
                boardSize,
                FList.Map(r => r.Item1,locateShipsRandomly(boardSize, shipsToBePlaced, FList.Empty<Ship>(), random)),
                FList.FoldL((r, s) => r + s, "", FList.Map(r => r.Item2,locateShipsRandomly(boardSize, shipsToBePlaced, FList.Empty<Ship>(), random))),
                ImmutableHashSet.Create<Location>()
            );
        }

        public static FList<Tuple<Ship, string>> locateShipsRandomly(int boardSize, FList<Ship> shipsToBePlaced, FList<Ship> shipsAlreadyPlaced, FRandom random)
        {
            return FList.Length(shipsToBePlaced)== 0 ?
                FList.Empty<Tuple<Ship, string>>()
                : FList.New(
                    Tuple.Create(
                        locateShipRandomly(boardSize, shipsAlreadyPlaced, FList.Head(shipsToBePlaced), random).Item1,
                        locateShipRandomly(boardSize, shipsAlreadyPlaced, FList.Head(shipsToBePlaced), random).Item2
                    ),
                    locateShipsRandomly(
                        boardSize,
                        FList.RemoveFirst(FList.Head(shipsToBePlaced), shipsToBePlaced),
                        FList.Prepend(
                            locateShipRandomly(boardSize, shipsAlreadyPlaced, FList.Head(shipsToBePlaced), random).Item1, shipsAlreadyPlaced),
                        locateShipRandomly(boardSize, shipsAlreadyPlaced, FList.Head(shipsToBePlaced), random).Item3
                    )
                );
        }

        public static Tuple<Ship, string, FRandom> locateShipRandomly(
            int boardSize, FList<Ship> shipsAlreadyLocated, Ship shipToBeLocated, FRandom random)
        {
            return Tuple.Create(
                shipToBeLocated.setPosition(
                    getValidRandomPosition(boardSize, shipsAlreadyLocated, shipToBeLocated, random).Item1,
                    getValidRandomPosition(boardSize, shipsAlreadyLocated, shipToBeLocated, random).Item2),
                "Computer placing the " + shipToBeLocated.Name + newLine,
                getValidRandomPosition(boardSize, shipsAlreadyLocated, shipToBeLocated, random).Item3);
        }

        public static Tuple<Location, Orientations, FRandom> getValidRandomPosition(int boardSize, FList<Ship> shipsAlreadyLocated, Ship shipToBeLocated, FRandom random)
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

        public static Tuple<Location, Orientations, FRandom> getRandomPosition(int boardSize, FRandom random)
        {
            return Tuple.Create(
                new Location(FRandom.Skip(0, random, 0, boardSize).Number, FRandom.Skip(1, random, 0, boardSize).Number),
                (Orientations)FRandom.Skip(2, random, 0, 2).Number,
                FRandom.Skip(2, random, 0, 2)); //Deliberately uses same as the last call -  this contains the next seed.
        }

        public static Location Add(this Location loc, int colInc, int rowInc)
        {
            return new Location(loc.Col + colInc, loc.Row + rowInc);
        }
    }
}
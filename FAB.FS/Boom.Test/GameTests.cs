
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FAB.DataFixture;
using FAB.Model;
using System.Collections.Immutable;
using System;
using System.Linq;

namespace FAB.Test
{
    [TestClass]
    public class GameTests
    {
        private Random Random = null;
        private ImmutableList<Location>  noMisses = ImmutableList<Location>.Empty;
        [TestInitialize] 
        public void TestInitialize()
        {
            Random = new Random(1);
        }

        [TestCleanup] 
        public void TestCleanUp()
        {
            Random = null;
        }

        [TestMethod]
        public void TestHitWithMissile()
        {
            var ships = Ships.TrainingGame();
            var board = new GameBoard(10, ships, "", noMisses);       
            board = Missile.fireMissile(new Location(8, 1), board);
            Assert.AreEqual("Hit a Battleship at (8,1).", board.Messages);
            var battleship = board.Ships.ElementAt(1);
            Assert.AreEqual(1, battleship.Hits.Count());
            Assert.IsFalse(ShipFunctions.isSunk(battleship));
            Assert.AreEqual(0, board.Misses.Count());
        }

        [TestMethod]
        public void RepeatedHitOnSameSquareDoesNotIncreaseHitCount()
        {
            var ships = Ships.TrainingGame();
            var board = new GameBoard(10, ships, "", noMisses);
            var loc = new Location(8, 1);
            board = Missile.fireMissile(loc, board);
            Assert.AreEqual("Hit a Battleship at (8,1).", board.Messages);
            var battleship = board.Ships.ElementAt(1);
            Assert.AreEqual(1, battleship.Hits.Count());
            Assert.IsFalse(ShipFunctions.isSunk(battleship));
            board = Missile.fireMissile(loc, board);
            Assert.AreEqual("Hit a Battleship at (8,1).", board.Messages);
            battleship = board.Ships.ElementAt(1);
            Assert.AreEqual(1, battleship.Hits.Count());
            board = Missile.fireMissile(loc, board);
            board = Missile.fireMissile(loc, board);
            board = Missile.fireMissile(loc, board);
            battleship = board.Ships.ElementAt(1);
            Assert.AreEqual(1, battleship.Hits.Count());
            Assert.IsFalse(ShipFunctions.isSunk(battleship));
        }

        [TestMethod]
        public void TestMissWithMissile()
        {
            var ships = Ships.TrainingGame();
            var board = new GameBoard(10, ships, "", noMisses);
            board = Missile.fireMissile(new Location(7, 1), board);
            Assert.AreEqual(1, board.Misses.Count());
            Assert.AreEqual("Sorry, (7,1) is a miss.", board.Messages);
            board = Missile.fireMissile(new Location(6, 1), board);
            Assert.AreEqual(2, board.Misses.Count());
            Assert.AreEqual("Sorry, (6,1) is a miss.", board.Messages);

        }

        [TestMethod]
        public void TestBombWithHits()
        {
            var ships = Ships.TrainingGame();
            var board = new GameBoard(10, ships, "", noMisses);
            board = Missile.fireBomb(new Location(7, 2), board);
            var expected = "Sorry, (6,1) is a miss.Sorry, (6,2) is a miss.Sorry, (6,3) is a miss." +
               "Sorry, (7,1) is a miss.Sorry, (7,2) is a miss.Sorry, (7,3) is a miss." +
               "Hit a Battleship at (8,1).Hit a Battleship at (8,2).Hit a Battleship at (8,3).";
            Assert.AreEqual(expected, board.Messages);
            var battleship = board.Ships.ElementAt(1);
            Assert.AreEqual(3, battleship.Hits.Count());
            Assert.IsFalse(ShipFunctions.isSunk(battleship));
        }

        [TestMethod]
        public void TestSunk()
        {
            var ships = Ships.SmallTestGame();
            var board = new GameBoard(10, ships, "", noMisses);
            board = Missile.fireMissile(new Location(4,5), board);
            Assert.AreEqual("Hit a Frigate at (4,5).", board.Messages);
            var frigate = board.Ships.ElementAt(1);
            Assert.AreEqual(1, frigate.Hits.Count());
            Assert.IsFalse(ShipFunctions.isSunk(frigate));
            board = Missile.fireMissile(new Location(4, 6), board);
            frigate = board.Ships.ElementAt(1);
            Assert.AreEqual(2, frigate.Hits.Count());
            Assert.IsTrue(ShipFunctions.isSunk(frigate));
            Assert.AreEqual("Frigate sunk!", board.Messages);
        }

        [TestMethod]
        public void TestGameOver()
        {
            var ships = Ships.SmallTestGame();
            var board = new GameBoard(10, ships, "", noMisses);
            board = Missile.fireMissile(new Location(4, 5), board);
            Assert.AreEqual("Hit a Frigate at (4,5).", board.Messages);
            board = Missile.fireMissile(new Location(4, 6), board);
            Assert.AreEqual("Frigate sunk!", board.Messages);
            board = Missile.fireMissile(new Location(2, 3), board);
            Assert.AreEqual("Minesweeper sunk!All ships sunk!", board.Messages);
        }

        //Uses the (mock) RandomRandomGenerator. It is not
        //testing the randomness, but that the outcomes are correct
        [TestMethod]
        public void TestRandomPlacement()
        {
            var unplacedShips = Ships.UnplacedShips4();
            var board = GameBoardFunctions.createBoardWithShipsPlacedRandomly(10, unplacedShips, Random);
            var ships = board.Ships;
            var s0 = ships.ElementAt(0);
            var s1 = ships.ElementAt(1);
            var s2 = ships.ElementAt(2);
            var s3 = ships.ElementAt(3);

            //2 1 0 7 6 0

            Assert.IsTrue(ShipFunctions.occupies(s0, new Location(2, 1)));
            Assert.IsTrue(ShipFunctions.occupies(s0, new Location(3, 1)));

            Assert.IsTrue(ShipFunctions.occupies(s1, new Location(7, 6)));
            Assert.IsTrue(ShipFunctions.occupies(s1, new Location(8, 6)));
        }
    }
}

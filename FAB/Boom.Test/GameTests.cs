
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Boom.DataFixture;
using Boom.Model;
using TechnicalServices;
using System.Collections.Immutable;
using System;

namespace Boom.Test
{
    [TestClass]
    public class GameTests
    {
        private IRandomGenerator SystemRandom = null;
        private PredictableRandomGenerator Preditable = null;
        private ImmutableList<Tuple<int, int>>  noMisses = ImmutableList<Tuple<int, int>>.Empty;
        [TestInitialize] 
        public void TestInitialize()
        {
             SystemRandom = new SystemRandomGenerator();
             Preditable = new PredictableRandomGenerator();
        }

        [TestCleanup] 
        public void TestCleanUp()
        {
            SystemRandom = null;
            Preditable = null;
        }

        [TestMethod]
        public void TestHitWithMissile()
        {
            var ships = Ships.TrainingGame();
            var board = new GameBoard(10, ships, "", SystemRandom, noMisses);       
            board = Missile.Fire(8, 1, board);
            Assert.AreEqual("Hit a Battleship at (8,1).", board.Messages);
            var battleship = board.Ships[1];
            Assert.AreEqual(1, Ship.HitCount(battleship));
            Assert.IsFalse(Ship.IsSunk(battleship));
            Assert.AreEqual(0, board.Misses.Count);
        }

        [TestMethod]
        public void RepeatedHitOnSameSquareDoesNotIncreaseHitCount()
        {
            var ships = Ships.TrainingGame();
            var board = new GameBoard(10, ships, "", SystemRandom, noMisses);
            board = Missile.Fire(8, 1, board);
            Assert.AreEqual("Hit a Battleship at (8,1).", board.Messages);
            var battleship = board.Ships[1];
            Assert.AreEqual(1, Ship.HitCount(battleship));
            Assert.IsFalse(Ship.IsSunk(battleship));
            board = Missile.Fire(8, 1, board);
            board = Missile.Fire(8, 1, board);
            board = Missile.Fire(8, 1, board);
            board = Missile.Fire(8, 1, board);
            battleship = board.Ships[1];
            Assert.AreEqual(1, Ship.HitCount(battleship));
            Assert.IsFalse(Ship.IsSunk(battleship));
        }

        [TestMethod]
        public void TestMissWithMissile()
        {
            var ships = Ships.TrainingGame();
            var board = new GameBoard(10, ships, "", SystemRandom, noMisses);
            board = Missile.Fire(7, 1, board);
            Assert.AreEqual(1, board.Misses.Count);
            Assert.AreEqual("Sorry, (7,1) is a miss.", board.Messages);
            board = Missile.Fire(6, 1, board);
            Assert.AreEqual(2, board.Misses.Count);
            Assert.AreEqual("Sorry, (6,1) is a miss.", board.Messages);

        }

        [TestMethod]
        public void TestBombWithHits()
        {
            var ships = Ships.TrainingGame();
            var board = new GameBoard(10, ships, "", SystemRandom, noMisses);
            board = Bomb.Fire(7, 2, board);
            var expected = "Sorry, (6,1) is a miss.Sorry, (6,2) is a miss.Sorry, (6,3) is a miss." +
               "Sorry, (7,1) is a miss.Sorry, (7,2) is a miss.Sorry, (7,3) is a miss." +
               "Hit a Battleship at (8,1).Hit a Battleship at (8,2).Hit a Battleship at (8,3).";
            Assert.AreEqual(expected, board.Messages);
            var battleship = board.Ships[1];
            Assert.AreEqual(3, Ship.HitCount(battleship));
            Assert.IsFalse(Ship.IsSunk(battleship));
        }

        [TestMethod]
        public void TestSunk()
        {
            var ships = Ships.SmallTestGame();
            var board = new GameBoard(10, ships, "", SystemRandom, noMisses);
            board = Missile.Fire(4,5, board);
            Assert.AreEqual("Hit a Frigate at (4,5).", board.Messages);
            var frigate = board.Ships[1];
            Assert.AreEqual(1, Ship.HitCount(frigate));
            Assert.IsFalse(Ship.IsSunk(frigate));
            board = Missile.Fire(4, 6, board);
            frigate = board.Ships[1];
            Assert.AreEqual(2, Ship.HitCount(frigate));
            Assert.IsTrue(Ship.IsSunk(frigate));
            Assert.AreEqual("Frigate sunk!", board.Messages);
        }

        [TestMethod]
        public void TestGameOver()
        {
            var ships = Ships.SmallTestGame();
            var board = new GameBoard(10, ships, "", SystemRandom, noMisses);
            board = Missile.Fire(4, 5, board);
            Assert.AreEqual("Hit a Frigate at (4,5).", board.Messages);
            board = Missile.Fire(4, 6, board);
            Assert.AreEqual("Frigate sunk!", board.Messages);
            board = Missile.Fire(2, 3, board);
            Assert.AreEqual("Minesweeper sunk!All ships sunk!", board.Messages);
        }

        //Uses the (mock) PredictableRandomGenerator. It is not
        //testing the randomness, but that the outcomes are correct
        [TestMethod]
        public void TestRandomPlacement()
        {
            var ships = Ships.UnplacedShips2();
            var board = new GameBoard(10, ships, "", Preditable, noMisses);

            Preditable.SetNextValues(2, 3, 0, 4, 2, 1);
            board = GameBoard.RandomiseShipPlacement(board);
            ships = board.Ships;
            var destroyer = ships[0];
            var patrol = ships[1];
            Assert.IsTrue(Ship.ShipOccupiesLocation(destroyer,2, 3));
            Assert.IsTrue(Ship.ShipOccupiesLocation(destroyer, 3, 3));
            Assert.IsTrue(Ship.ShipOccupiesLocation(destroyer, 4, 3));
            Assert.IsFalse(Ship.ShipOccupiesLocation(destroyer, 3, 2));

            Assert.IsTrue(Ship.ShipOccupiesLocation(patrol,4, 2));
            Assert.IsTrue(Ship.ShipOccupiesLocation(patrol, 4, 3));
            Assert.IsFalse(Ship.ShipOccupiesLocation(patrol,5, 2));
        }

    }
}

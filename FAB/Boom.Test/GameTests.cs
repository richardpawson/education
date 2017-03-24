﻿
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
        private Random Random = null;
        private ImmutableList<Tuple<int, int>>  noMisses = ImmutableList<Tuple<int, int>>.Empty;
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
            board = Missile.Fire(8, 1, board);
            Assert.AreEqual("Hit a Battleship at (8,1).", board.Messages);
            var battleship = board.Ships[1];
            Assert.AreEqual(1, battleship.Hits.Count);
            Assert.IsFalse(battleship.IsSunk());
            Assert.AreEqual(0, board.Misses.Count);
        }

        [TestMethod]
        public void RepeatedHitOnSameSquareDoesNotIncreaseHitCount()
        {
            var ships = Ships.TrainingGame();
            var board = new GameBoard(10, ships, "", noMisses);
            board = Missile.Fire(8, 1, board);
            Assert.AreEqual("Hit a Battleship at (8,1).", board.Messages);
            var battleship = board.Ships[1];
            Assert.AreEqual(1, battleship.Hits.Count);
            Assert.IsFalse(battleship.IsSunk());
            board = Missile.Fire(8, 1, board);
            board = Missile.Fire(8, 1, board);
            board = Missile.Fire(8, 1, board);
            board = Missile.Fire(8, 1, board);
            battleship = board.Ships[1];
            Assert.AreEqual(1, battleship.Hits.Count);
            Assert.IsFalse(battleship.IsSunk());
        }

        [TestMethod]
        public void TestMissWithMissile()
        {
            var ships = Ships.TrainingGame();
            var board = new GameBoard(10, ships, "", noMisses);
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
            var board = new GameBoard(10, ships, "", noMisses);
            board = Bomb.Fire(7, 2, board);
            var expected = "Sorry, (6,1) is a miss.Sorry, (6,2) is a miss.Sorry, (6,3) is a miss." +
               "Sorry, (7,1) is a miss.Sorry, (7,2) is a miss.Sorry, (7,3) is a miss." +
               "Hit a Battleship at (8,1).Hit a Battleship at (8,2).Hit a Battleship at (8,3).";
            Assert.AreEqual(expected, board.Messages);
            var battleship = board.Ships[1];
            Assert.AreEqual(3, battleship.Hits.Count);
            Assert.IsFalse(battleship.IsSunk());
        }

        [TestMethod]
        public void TestSunk()
        {
            var ships = Ships.SmallTestGame();
            var board = new GameBoard(10, ships, "", noMisses);
            board = Missile.Fire(4,5, board);
            Assert.AreEqual("Hit a Frigate at (4,5).", board.Messages);
            var frigate = board.Ships[1];
            Assert.AreEqual(1, frigate.Hits.Count);
            Assert.IsFalse(frigate.IsSunk());
            board = Missile.Fire(4, 6, board);
            frigate = board.Ships[1];
            Assert.AreEqual(2, frigate.Hits.Count);
            Assert.IsTrue(frigate.IsSunk());
            Assert.AreEqual("Frigate sunk!", board.Messages);
        }

        [TestMethod]
        public void TestGameOver()
        {
            var ships = Ships.SmallTestGame();
            var board = new GameBoard(10, ships, "", noMisses);
            board = Missile.Fire(4, 5, board);
            Assert.AreEqual("Hit a Frigate at (4,5).", board.Messages);
            board = Missile.Fire(4, 6, board);
            Assert.AreEqual("Frigate sunk!", board.Messages);
            board = Missile.Fire(2, 3, board);
            Assert.AreEqual("Minesweeper sunk!All ships sunk!", board.Messages);
        }

        //Uses the (mock) RandomRandomGenerator. It is not
        //testing the randomness, but that the outcomes are correct
        [TestMethod]
        public void TestRandomPlacement()
        {
            var ships = Ships.UnplacedShips4();
            var board = GameBoardFunctions.PlaceShipsRandomlyOnBoard(10, ships, Random);
            ships = board.Ships;
            var s0 = ships[0];
            var s1 = ships[1];
            var s2 = ships[2];
            var s3 = ships[3];

            //2 1 0 7 6 0

            Assert.IsTrue(s3.ShipOccupiesLocation(2, 1));
            Assert.IsTrue(s3.ShipOccupiesLocation(3, 1));

            Assert.IsTrue(s2.ShipOccupiesLocation(7, 6));
            Assert.IsTrue(s2.ShipOccupiesLocation(8, 6));
        }

    }
}

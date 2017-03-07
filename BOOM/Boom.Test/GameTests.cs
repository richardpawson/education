
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Boom.DataFixture;
using Boom.Model;
using TechnicalServices;

namespace Boom.Test
{
    [TestClass]
    public class GameTests
    {
        private ReadableLogger Logger = null;
        private IRandomGenerator SystemRandom = null;
        private PredictableRandomGenerator Preditable = null;
        [TestInitialize] 
        public void TestInitialize()
        {
             Logger = new ReadableLogger();
             SystemRandom = new SystemRandomGenerator();
             Preditable = new PredictableRandomGenerator();
        }

        [TestCleanup] 
        public void TestCleanUp()
        {
            Logger = null;
            SystemRandom = null;
            Preditable = null;
        }


        [TestMethod]
        public void TestHitWithMissile()
        {
            var ships = Ships.TrainingGame();
            var board = new GameBoard(10, ships, Logger, SystemRandom);
            var missile = new Missile();
            missile.Fire(8, 1, board);
            Assert.AreEqual("Hit a Battleship at (8,1).", Logger.ReadAndResetLog());
            var battleship = ships[1];
            Assert.AreEqual(1, battleship.HitCount());
            Assert.IsFalse(battleship.IsSunk());
        }

        [TestMethod]
        public void RepeatedHitOnSameSquareDoesNotIncreaseHitCount()
        {
            var ships = Ships.TrainingGame();
            var board = new GameBoard(10, ships, Logger, SystemRandom);
            var missile = new Missile();
            missile.Fire(8, 1, board);
            Assert.AreEqual("Hit a Battleship at (8,1).", Logger.ReadAndResetLog());
            var battleship = ships[1];
            Assert.AreEqual(1, battleship.HitCount());
            Assert.IsFalse(battleship.IsSunk());
            missile.Fire(8, 1, board);
            missile.Fire(8, 1, board);
            missile.Fire(8, 1, board);
            missile.Fire(8, 1, board);
            Assert.AreEqual(1, battleship.HitCount());
            Assert.IsFalse(battleship.IsSunk());
        }

        [TestMethod]
        public void TestMissWithMissile()
        {
            var ships = Ships.TrainingGame();
            var board = new GameBoard(10, ships, Logger, SystemRandom);
            var missile = new Missile();
            missile.Fire(7, 1, board);
                       Assert.AreEqual("Sorry, (7,1) is a miss.", Logger.ReadAndResetLog());
        }

        [TestMethod]
        public void TestBombWithHits()
        {
            var ships = Ships.TrainingGame();
            var board = new GameBoard(10, ships, Logger, SystemRandom);
            var bomb = new Bomb();
            bomb.Fire(7, 2, board);
            var expected = "Sorry, (6,1) is a miss.Sorry, (6,2) is a miss.Sorry, (6,3) is a miss." +
               "Sorry, (7,1) is a miss.Sorry, (7,2) is a miss.Sorry, (7,3) is a miss." +
               "Hit a Battleship at (8,1).Hit a Battleship at (8,2).Hit a Battleship at (8,3).";
            Assert.AreEqual(expected, Logger.ReadAndResetLog());
            var battleship = ships[1];
            Assert.AreEqual(3, battleship.HitCount());
            Assert.IsFalse(battleship.IsSunk());
        }

        [TestMethod]
        public void TestSunk()
        {
            var ships = Ships.SmallTestGame();
            var board = new GameBoard(10, ships, Logger, SystemRandom);
            var missile = new Missile();
            missile.Fire(4,5, board);
            Assert.AreEqual("Hit a Frigate at (4,5).", Logger.ReadAndResetLog());
            var frigate = ships[1];
            Assert.AreEqual(1, frigate.HitCount());
            Assert.IsFalse(frigate.IsSunk());
            missile.Fire(4, 6, board);
            Assert.AreEqual(2, frigate.HitCount());
            Assert.IsTrue(frigate.IsSunk());
            Assert.AreEqual("Frigate sunk!", Logger.ReadAndResetLog());
        }

        [TestMethod]
        public void TestGameOver()
        {
            var ships = Ships.SmallTestGame();
            var board = new GameBoard(10, ships, Logger, SystemRandom);
            var missile = new Missile();
            missile.Fire(4, 5, board);
            Assert.AreEqual("Hit a Frigate at (4,5).", Logger.ReadAndResetLog());
            var frigate = ships[1];
            missile.Fire(4, 6, board);
            Assert.AreEqual("Frigate sunk!", Logger.ReadAndResetLog());
            missile.Fire(2, 3, board);
            Assert.AreEqual("Minesweeper sunk!All ships sunk!", Logger.ReadAndResetLog());
        }

        //Uses the (mock) PredictableRandomGenerator. It is not
        //testing the randomness, but that the outcomes are correct
        [TestMethod]
        public void TestRandomPlacement()
        {
            var ships = Ships.UnplacedShips2();
            var board = new GameBoard(10, ships, Logger, Preditable);
            var destroyer = ships[0];
            var patrol = ships[1];
            Preditable.SetNextValues(2, 3, 0, 4, 2, 1);
            board.RandomiseShipPlacement();
            Assert.IsTrue(destroyer.ShipOccupiesLocation(2, 3));
            Assert.IsTrue(destroyer.ShipOccupiesLocation(3, 3));
            Assert.IsTrue(destroyer.ShipOccupiesLocation(4, 3));
            Assert.IsFalse(destroyer.ShipOccupiesLocation(2, 4));

            Assert.IsTrue(patrol.ShipOccupiesLocation(4, 2));
            Assert.IsTrue(patrol.ShipOccupiesLocation(4, 3));
            Assert.IsFalse(patrol.ShipOccupiesLocation(5, 2));
        }

    }
}

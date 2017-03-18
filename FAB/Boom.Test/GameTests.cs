
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
            Missile.Fire(8, 1, board);
            Assert.AreEqual("Hit a Battleship at (8,1).", Logger.ReadAndResetLog());
            var battleship = ships[1];
            Assert.AreEqual(1, Ship.HitCount(battleship));
            Assert.IsFalse(Ship.IsSunk(battleship));
        }

        [TestMethod]
        public void RepeatedHitOnSameSquareDoesNotIncreaseHitCount()
        {
            var ships = Ships.TrainingGame();
            var board = new GameBoard(10, ships, Logger, SystemRandom);
            Missile.Fire(8, 1, board);
            Assert.AreEqual("Hit a Battleship at (8,1).", Logger.ReadAndResetLog());
            var battleship = ships[1];
            Assert.AreEqual(1, Ship.HitCount(battleship));
            Assert.IsFalse(Ship.IsSunk(battleship));
            Missile.Fire(8, 1, board);
            Missile.Fire(8, 1, board);
            Missile.Fire(8, 1, board);
            Missile.Fire(8, 1, board);
            Assert.AreEqual(1, Ship.HitCount(battleship));
            Assert.IsFalse(Ship.IsSunk(battleship));
        }

        [TestMethod]
        public void TestMissWithMissile()
        {
            var ships = Ships.TrainingGame();
            var board = new GameBoard(10, ships, Logger, SystemRandom);
            Missile.Fire(7, 1, board);
            Assert.AreEqual("Sorry, (7,1) is a miss.", Logger.ReadAndResetLog());
        }

        [TestMethod]
        public void TestBombWithHits()
        {
            var ships = Ships.TrainingGame();
            var board = new GameBoard(10, ships, Logger, SystemRandom);
            Bomb.Fire(7, 2, board);
            var expected = "Sorry, (6,1) is a miss.Sorry, (6,2) is a miss.Sorry, (6,3) is a miss." +
               "Sorry, (7,1) is a miss.Sorry, (7,2) is a miss.Sorry, (7,3) is a miss." +
               "Hit a Battleship at (8,1).Hit a Battleship at (8,2).Hit a Battleship at (8,3).";
            Assert.AreEqual(expected, Logger.ReadAndResetLog());
            var battleship = ships[1];
            Assert.AreEqual(3, Ship.HitCount(battleship));
            Assert.IsFalse(Ship.IsSunk(battleship));
        }

        [TestMethod]
        public void TestSunk()
        {
            var ships = Ships.SmallTestGame();
            var board = new GameBoard(10, ships, Logger, SystemRandom);
            Missile.Fire(4,5, board);
            Assert.AreEqual("Hit a Frigate at (4,5).", Logger.ReadAndResetLog());
            var frigate = ships[1];
            Assert.AreEqual(1, Ship.HitCount(frigate));
            Assert.IsFalse(Ship.IsSunk(frigate));
            Missile.Fire(4, 6, board);
            Assert.AreEqual(2, Ship.HitCount(frigate));
            Assert.IsTrue(Ship.IsSunk(frigate));
            Assert.AreEqual("Frigate sunk!", Logger.ReadAndResetLog());
        }

        [TestMethod]
        public void TestGameOver()
        {
            var ships = Ships.SmallTestGame();
            var board = new GameBoard(10, ships, Logger, SystemRandom);
            Missile.Fire(4, 5, board);
            Assert.AreEqual("Hit a Frigate at (4,5).", Logger.ReadAndResetLog());
            var frigate = ships[1];
            Missile.Fire(4, 6, board);
            Assert.AreEqual("Frigate sunk!", Logger.ReadAndResetLog());
            Missile.Fire(2, 3, board);
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
            GameBoard.RandomiseShipPlacement(board);
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

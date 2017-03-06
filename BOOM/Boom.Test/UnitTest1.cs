﻿
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Boom.DataFixture;
using Boom.Model;
using TechnicalServices;

namespace Boom.Test
{
    [TestClass]
    public class UnitTest1
    {
        static ReadableLogger Logger = new ReadableLogger();
        static IRandomGenerator RandomGenerator = new SystemRandomGenerator(); 

        [TestMethod]
        public void TestTrainingGame()
        {
            var ships = Ships.TrainingGame();
            var board = new GameBoard(10, ships, Logger, RandomGenerator);
            var missile = new Missile();
            missile.Fire(1, 8, board);
            Assert.AreEqual("Hit a Battleship at (8,1).", Logger.ReadAndResetLog());
            var battleship = ships[1];
            Assert.AreEqual(1, battleship.Hits);
            Assert.IsFalse(battleship.IsSunk());
        }
    }
}

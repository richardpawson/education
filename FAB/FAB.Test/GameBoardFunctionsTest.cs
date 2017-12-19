using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FAB.Model;

namespace Boom.Test
{
    [TestClass]
    public class GameBoardFunctionsTest
    {
        [TestMethod]
        public void ShipWouldFitWithinBoard1()
        {
            var ship = new Ship("", 5, new Location(3, 4), Orientations.Horizontal);
            Assert.IsTrue(GameBoardFunctions.shipWouldFitWithinBoard(9, ship));
        }
        [TestMethod]
        public void ShipWouldFitWithinBoard2()
        {
            var ship = new Ship("", 5, new Location(0, 0), Orientations.Vertical);
            Assert.IsTrue(GameBoardFunctions.shipWouldFitWithinBoard(5, ship));
        }
        [TestMethod]
        public void ShipWouldFitWithinBoard3()
        {
            var ship = new Ship("", 5, new Location(5, 5), Orientations.Horizontal);
            Assert.IsFalse(GameBoardFunctions.shipWouldFitWithinBoard(9, ship));
        }
        [TestMethod]
        public void ShipWouldFitWithinBoard4()
        {
            var ship = new Ship("", 5, new Location(5, 5), Orientations.Vertical);
            Assert.IsFalse(GameBoardFunctions.shipWouldFitWithinBoard(9, ship));
        }
    }
}

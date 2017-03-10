

Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports Boom.DataFixture
Imports Boom.Model
Imports TechnicalServices

Namespace Boom.Test
	<TestClass> _
	Public Class GameTests
		Private Logger As ReadableLogger = Nothing
		Private SystemRandom As IRandomGenerator = Nothing
		Private Preditable As PredictableRandomGenerator = Nothing
		<TestInitialize> _
		Public Sub TestInitialize()
			Logger = New ReadableLogger()
			SystemRandom = New SystemRandomGenerator()
			Preditable = New PredictableRandomGenerator()
		End Sub

		<TestCleanup> _
		Public Sub TestCleanUp()
			Logger = Nothing
			SystemRandom = Nothing
			Preditable = Nothing
		End Sub


		<TestMethod> _
		Public Sub TestHitWithMissile()
			Dim ships__1 = Ships.TrainingGame()
			Dim board = New GameBoard(10, ships__1, Logger, SystemRandom)
			Dim missile = New Missile()
			missile.Fire(8, 1, board)
			Assert.AreEqual("Hit a Battleship at (8,1).", Logger.ReadAndResetLog())
			Dim battleship = ships__1(1)
			Assert.AreEqual(1, battleship.HitCount())
			Assert.IsFalse(battleship.IsSunk())
		End Sub

		<TestMethod> _
		Public Sub RepeatedHitOnSameSquareDoesNotIncreaseHitCount()
			Dim ships__1 = Ships.TrainingGame()
			Dim board = New GameBoard(10, ships__1, Logger, SystemRandom)
			Dim missile = New Missile()
			missile.Fire(8, 1, board)
			Assert.AreEqual("Hit a Battleship at (8,1).", Logger.ReadAndResetLog())
			Dim battleship = ships__1(1)
			Assert.AreEqual(1, battleship.HitCount())
			Assert.IsFalse(battleship.IsSunk())
			missile.Fire(8, 1, board)
			missile.Fire(8, 1, board)
			missile.Fire(8, 1, board)
			missile.Fire(8, 1, board)
			Assert.AreEqual(1, battleship.HitCount())
			Assert.IsFalse(battleship.IsSunk())
		End Sub

		<TestMethod> _
		Public Sub TestMissWithMissile()
			Dim ships__1 = Ships.TrainingGame()
			Dim board = New GameBoard(10, ships__1, Logger, SystemRandom)
			Dim missile = New Missile()
			missile.Fire(7, 1, board)
			Assert.AreEqual("Sorry, (7,1) is a miss.", Logger.ReadAndResetLog())
		End Sub

		<TestMethod> _
		Public Sub TestBombWithHits()
			Dim ships__1 = Ships.TrainingGame()
			Dim board = New GameBoard(10, ships__1, Logger, SystemRandom)
			Dim bomb = New Bomb()
			bomb.Fire(7, 2, board)
			Dim expected = "Sorry, (6,1) is a miss.Sorry, (6,2) is a miss.Sorry, (6,3) is a miss." + "Sorry, (7,1) is a miss.Sorry, (7,2) is a miss.Sorry, (7,3) is a miss." + "Hit a Battleship at (8,1).Hit a Battleship at (8,2).Hit a Battleship at (8,3)."
			Assert.AreEqual(expected, Logger.ReadAndResetLog())
			Dim battleship = ships__1(1)
			Assert.AreEqual(3, battleship.HitCount())
			Assert.IsFalse(battleship.IsSunk())
		End Sub

		<TestMethod> _
		Public Sub TestSunk()
			Dim ships__1 = Ships.SmallTestGame()
			Dim board = New GameBoard(10, ships__1, Logger, SystemRandom)
			Dim missile = New Missile()
			missile.Fire(4, 5, board)
			Assert.AreEqual("Hit a Frigate at (4,5).", Logger.ReadAndResetLog())
			Dim frigate = ships__1(1)
			Assert.AreEqual(1, frigate.HitCount())
			Assert.IsFalse(frigate.IsSunk())
			missile.Fire(4, 6, board)
			Assert.AreEqual(2, frigate.HitCount())
			Assert.IsTrue(frigate.IsSunk())
			Assert.AreEqual("Frigate sunk!", Logger.ReadAndResetLog())
		End Sub

		<TestMethod> _
		Public Sub TestGameOver()
			Dim ships__1 = Ships.SmallTestGame()
			Dim board = New GameBoard(10, ships__1, Logger, SystemRandom)
			Dim missile = New Missile()
			missile.Fire(4, 5, board)
			Assert.AreEqual("Hit a Frigate at (4,5).", Logger.ReadAndResetLog())
			Dim frigate = ships__1(1)
			missile.Fire(4, 6, board)
			Assert.AreEqual("Frigate sunk!", Logger.ReadAndResetLog())
			missile.Fire(2, 3, board)
			Assert.AreEqual("Minesweeper sunk!All ships sunk!", Logger.ReadAndResetLog())
		End Sub

		'Uses the (mock) PredictableRandomGenerator. It is not
		'testing the randomness, but that the outcomes are correct
		<TestMethod> _
		Public Sub TestRandomPlacement()
			Dim ships__1 = Ships.UnplacedShips2()
			Dim board = New GameBoard(10, ships__1, Logger, Preditable)
			Dim destroyer = ships__1(0)
			Dim patrol = ships__1(1)
			Preditable.SetNextValues(2, 3, 0, 4, 2, 1)
			board.RandomiseShipPlacement()
            Assert.IsTrue(destroyer.ShipOccupiesLocation(2, 3))
            Assert.IsTrue(destroyer.ShipOccupiesLocation(3, 3))
			Assert.IsTrue(destroyer.ShipOccupiesLocation(4, 3))
            Assert.IsFalse(destroyer.ShipOccupiesLocation(3, 2))

            Assert.IsTrue(patrol.ShipOccupiesLocation(4, 2))
			Assert.IsTrue(patrol.ShipOccupiesLocation(4, 3))
			Assert.IsFalse(patrol.ShipOccupiesLocation(5, 2))
		End Sub

	End Class
End Namespace

'=======================================================
'Service provided by Telerik (www.telerik.com)
'Conversion powered by NRefactory.
'Twitter: @telerik
'Facebook: facebook.com/telerik
'=======================================================


Imports Boom.Model

Namespace Boom.DataFixture
	Public NotInheritable Class Ships
		Private Sub New()
		End Sub
		'Returns five ships with no placings. Intention is that after creating a new
		' GameBoard with this set, you would call RandomiseShipPlacement() on it.
		Public Shared Function UnplacedShips5() As Ship()
			Dim ships = New Ship(4) {}
			ships(0) = New Ship("Aircraft Carrier", 5)
			ships(1) = New Ship("Battleship", 4)
			ships(2) = New Ship("Submarine", 3)
			ships(3) = New Ship("Destroyer", 3)
			ships(4) = New Ship("Patrol Boat", 2)
			Return ships
		End Function

		Public Shared Function UnplacedShips2() As Ship()
			Dim ships = New Ship(1) {}
			ships(0) = New Ship("Destroyer", 3)
			ships(1) = New Ship("Patrol Boat", 2)
			Return ships
		End Function

		Public Shared Function TrainingGame() As Ship()
			Dim ships = New Ship(4) {}
			ships(0) = New Ship("Aircraft Carrier", 5, 1, 8, Orientations.Horizontal)
			ships(1) = New Ship("Battleship", 4, 8, 1, Orientations.Vertical)
			ships(2) = New Ship("Submarine", 3, 7, 6, Orientations.Vertical)
			ships(3) = New Ship("Destroyer", 3, 5, 9, Orientations.Horizontal)
			ships(4) = New Ship("Patrol Boat", 2, 1, 4, Orientations.Vertical)
			Return ships
		End Function

		'Contains only two small ships.  Intent is for testing a complete game scenario.
		Public Shared Function SmallTestGame() As Ship()
			Dim ships = New Ship(1) {}
			ships(0) = New Ship("Minesweeper", 1, 2, 3, Orientations.Horizontal)
			ships(1) = New Ship("Frigate", 2, 4, 5, Orientations.Vertical)
			Return ships
		End Function
	End Class
End Namespace

'=======================================================
'Service provided by Telerik (www.telerik.com)
'Conversion powered by NRefactory.
'Twitter: @telerik
'Facebook: facebook.com/telerik
'=======================================================

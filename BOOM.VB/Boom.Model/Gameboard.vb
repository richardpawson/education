
Imports System.Linq
Imports TechnicalServices

Namespace Boom.Model
	Public Class GameBoard
		Public Property Size() As Integer
			Get
				Return m_Size
			End Get
			Private Set
				m_Size = Value
			End Set
		End Property
		Private m_Size As Integer
		Private Squares As SquareValues(,)
		Private Ships As Ship()
		Private Logger As ILogger
		Private RandomGenerator As IRandomGenerator

		Public Sub New(size__1 As Integer, ships__2 As Ship(), logger__3 As ILogger, randomGenerator__4 As IRandomGenerator)
			Size = size__1
			Squares = New SquareValues(Size - 1, Size - 1) {}
			Logger = logger__3
			RandomGenerator = randomGenerator__4
			InitialiseEmptyBoard()
			Ships = ships__2
		End Sub

		'Sets all squares to empty
		Private Sub InitialiseEmptyBoard()
			For Row As Integer = 0 To Size - 1
				For Column As Integer = 0 To Size - 1
					Squares(Row, Column) = SquareValues.Empty
				Next
			Next
		End Sub
		'Checks, in collaboration with Ships, whether any of them cover
		'the given row, column; if one does, invoke the Hit() method on it.
		Public Sub CheckSquareAndRecordOutcome(col As Integer, row As Integer)
			For Each ship As Ship In Ships
				If ship.ShipOccupiesLocation(col, row) Then
					ship.Hit(col, row)
					Squares(row, col) = SquareValues.Hit
					If ship.IsSunk() Then
						Logger.WriteLine(ship.Name + " sunk!")
					Else
                        Logger.WriteLine("Hit a " + ship.Name + " at (" + col.ToString() + "," + row.ToString() + ").")
                    End If
					If CheckWin() Then
						Logger.WriteLine("All ships sunk!")
						Logger.WriteLine()
					End If
					Return
				End If
			Next
			Squares(row, col) = SquareValues.Miss
            Logger.WriteLine("Sorry, (" + col.ToString() + "," + row.ToString() + ") is a miss.")
        End Sub

		'Returns true if the given position for the ship fits within the board 
		'and does not clash with another ship
		Private Function IsValidPosition(ship As Ship, row As Integer, col As Integer, orientation As Orientations) As Boolean
			If orientation = Orientations.Vertical AndAlso row + ship.Size > Size Then
				Return False
			ElseIf orientation = Orientations.Horizontal AndAlso col + ship.Size > Size Then
				Return False
			Else
				If orientation = Orientations.Vertical Then
					For Scan As Integer = 0 To ship.Size - 1
						If Squares(row + Scan, col) <> SquareValues.Empty Then
							Return False
						End If
					Next
				ElseIf orientation = Orientations.Horizontal Then
					For Scan As Integer = 0 To ship.Size - 1
						If Squares(row, col + Scan) <> SquareValues.Empty Then
							Return False
						End If
					Next
				End If
			End If
			Return True
		End Function
		'Returns true if all ships are sunk.
		Public Function CheckWin() As Boolean
			Return Not Ships.Any(Function(s) Not s.IsSunk())
		End Function

		'Allows the actual array of squares to remain private
		Public Function ReadSquare(row As Integer, col As Integer) As SquareValues
			Return Squares(row, col)
		End Function

		'In collaboration with IsValidPosition, finds a random but valid
		'position for each of the ships set up, whether or not they already
		'have a position specified.
		Public Sub RandomiseShipPlacement()
            For Each ship As Ship In Ships
                Dim orientation As Orientations = 0
                'default
                Dim row As Integer = 0
                Dim col As Integer = 0
                Dim valid As Boolean = False
                While valid = False
                    row = RandomGenerator.[Next](0, Size)
                    col = RandomGenerator.[Next](0, Size)
                    orientation = DirectCast(RandomGenerator.[Next](0, 2), Orientations)
                    valid = IsValidPosition(ship, row, col, orientation)
                End While
                Logger.WriteLine("Computer placing the " + ship.Name)
                ship.SetPosition(row, col, orientation)
            Next
        End Sub
	End Class
End Namespace

'=======================================================
'Service provided by Telerik (www.telerik.com)
'Conversion powered by NRefactory.
'Twitter: @telerik
'Facebook: facebook.com/telerik
'=======================================================

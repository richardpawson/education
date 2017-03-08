
Imports System.Linq

Namespace Boom.Model
	Public Class Ship
		Private startRow As Integer

		Private startCol As Integer

		Private Orientation As Orientations

		Public Property Name() As String
			Get
				Return m_Name
			End Get
			Private Set
				m_Name = Value
			End Set
		End Property
		Private m_Name As String

		Public Property Size() As Integer
			Get
				Return m_Size
			End Get
			Private Set
				m_Size = Value
			End Set
		End Property
		Private m_Size As Integer

		'Corresponds to the length of the ship to know which squares
		'have already been hit and prevent double-counting hits on same position
		Private Hits As Boolean() = Nothing

		Public Sub New(ShipName As String, ShipSize As Integer, Optional col As Integer = 0, Optional row As Integer = 0, Optional orient As Orientations = 0)
			Name = ShipName
			Size = ShipSize
			Hits = New Boolean(ShipSize - 1) {}
			SetPosition(col, row, orient)
		End Sub

		Public Sub SetPosition(col As Integer, row As Integer, orient As Orientations)
			startCol = col
			startRow = row
			Orientation = orient
		End Sub

		'Calculated based on the size and the orientation of the ship
		Public Function ShipOccupiesLocation(col As Integer, row As Integer) As Boolean
			If Orientation = Orientations.Horizontal Then
				Return startRow = row AndAlso col >= startCol AndAlso col < startCol + Size
			Else
				Return Me.startCol = col AndAlso row >= startRow AndAlso row < startRow + Size
			End If
		End Function

		Private Function PositionOnShip(col As Integer, row As Integer) As Integer
			If Not ShipOccupiesLocation(col, row) Then
				Throw New System.Exception("Ship does not occupy coordinates given")
			End If
			If Orientation = Orientations.Horizontal Then
				Return col - startCol
			Else
				Return row - startRow
			End If
		End Function

		'Increments the hit count
		Public Sub Hit(col As Integer, row As Integer)
			Dim positionOnShip__1 As Integer = PositionOnShip(col, row)
			Hits(positionOnShip__1) = True
		End Sub

		Public Function HitCount() As Integer
			Return Hits.Count(Function(h) h)
			'i.e. returns count of 'true' values
		End Function

		'Returns true if the Hit count matches the size of the ship
		Public Function IsSunk() As Boolean
			Return HitCount() >= Size
		End Function
	End Class
End Namespace

'=======================================================
'Service provided by Telerik (www.telerik.com)
'Conversion powered by NRefactory.
'Twitter: @telerik
'Facebook: facebook.com/telerik
'=======================================================


Imports System.Collections.Immutable
Imports System.Linq

Namespace FAB
	Public Class Ship
		Public Location As Location

		Public ReadOnly Orientation As Orientations

		Public ReadOnly Name As String

		Public ReadOnly Size As Integer

		Public ReadOnly Hits As ImmutableHashSet(Of Location)

		Public Sub New(ShipName As String, ShipSize As Integer, hits__1 As ImmutableHashSet(Of Location), loc As Location, Optional orient As Orientations = 0)
			Name = ShipName
			Size = ShipSize
			Location = loc
			Orientation = orient
			Hits = hits__1
		End Sub

		Public Sub New(ShipName As String, ShipSize As Integer, loc As Location, Optional orient As Orientations = 0)
			Name = ShipName
			Size = ShipSize
			Location = loc
			Orientation = orient
			Hits = ImmutableHashSet(Of Location).Empty
		End Sub

		Public Sub New(ShipName As String, ShipSize As Integer)
			Name = ShipName
			Size = ShipSize
			Orientation = Orientations.Horizontal
			Hits = ImmutableHashSet(Of Location).Empty
		End Sub

	End Class
End Namespace

'=======================================================
'Service provided by Telerik (www.telerik.com)
'Conversion powered by NRefactory.
'Twitter: @telerik
'Facebook: facebook.com/telerik
'=======================================================

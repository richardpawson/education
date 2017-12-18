Imports System.Collections.Immutable

Namespace FAB.Model
    Public Enum Orientations
        Horizontal
        Vertical
    End Enum

    Public Enum SquareValues
        Empty
        Miss
        Hit
    End Enum

    Public Structure Location
        Public ReadOnly Col As Integer
        Public ReadOnly Row As Integer

        Public Sub New(col__1 As Integer, row__2 As Integer)
            Col = col__1
            Row = row__2
        End Sub
    End Structure

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

    Public Class GameBoard
        Public ReadOnly Size As Integer
        Public ReadOnly Misses As ImmutableList(Of Location)
        Public ReadOnly Ships As ImmutableArray(Of Ship)
        Public ReadOnly Messages As String

        Public Sub New(size__1 As Integer, ships__2 As ImmutableArray(Of Ship), messages__3 As String, misses__4 As ImmutableList(Of Location))
            Size = size__1
            Messages = messages__3
            Ships = ships__2
            Misses = misses__4
        End Sub
    End Class
End Namespace

'=======================================================
'Service provided by Telerik (www.telerik.com)
'Conversion powered by NRefactory.
'Twitter: @telerik
'Facebook: facebook.com/telerik
'=======================================================

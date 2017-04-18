Imports System.Collections.Immutable

Namespace FAB.Model
    Public Class Missile
        Public Shared Function fireMissile(loc As Location, board As GameBoard) As GameBoard
            Return board.checkSquareAndRecordOutcome(loc)
        End Function

        Public Shared Function fireBomb(loc As Location, board As GameBoard) As GameBoard
            Dim locs = GenerateLocationsToHit(loc.Col, loc.Row, board)
            Return board.checkSquaresAndRecordOutcome(locs)
        End Function

        Private Shared Function GenerateLocationsToHit(centreCol As Integer, centreRow As Integer, board As GameBoard) As ImmutableArray(Of Location)
            Dim colRange = Enumerable.Range(centreCol - 1, 3)
            Dim rowRange = Enumerable.Range(centreRow - 1, 3)
            Dim locations = colRange.SelectMany(Function(col) rowRange, Function(col, row) New Location(col, row))
            Return ImmutableArray.CreateRange(locations)
        End Function
    End Class
End Namespace



'=======================================================
'Service provided by Telerik (www.telerik.com)
'Conversion powered by NRefactory.
'Twitter: @telerik
'Facebook: facebook.com/telerik
'=======================================================

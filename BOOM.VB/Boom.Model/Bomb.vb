
Namespace Boom.Model
	'Fires nine shots covering the 3x3 grid of squares centred on the given row, column.
	Public Class Bomb
		Implements IWeapon
		Private blastRadius As Integer = 1

        Public Sub Fire(col As Integer, row As Integer, Board As GameBoard) Implements IWeapon.Fire
            For startCol As Integer = col - blastRadius To col + blastRadius
                For startRow As Integer = row - blastRadius To row + blastRadius
                    If True Then
                        If startCol >= 0 AndAlso startCol < 10 AndAlso startRow >= 0 AndAlso startRow < 10 Then
                            Board.CheckSquareAndRecordOutcome(startCol, startRow)
                        End If
                    End If
                Next
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

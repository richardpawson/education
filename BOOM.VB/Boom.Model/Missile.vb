Namespace Boom.Model
    Public Class Missile
        Implements IWeapon

        Public Sub Fire(col As Integer, row As Integer, Board As GameBoard) Implements IWeapon.Fire
            Board.CheckSquareAndRecordOutcome(col, row)
        End Sub
    End Class
End Namespace



'=======================================================
'Service provided by Telerik (www.telerik.com)
'Conversion powered by NRefactory.
'Twitter: @telerik
'Facebook: facebook.com/telerik
'=======================================================

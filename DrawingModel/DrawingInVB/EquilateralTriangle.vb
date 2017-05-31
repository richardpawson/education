

Namespace DrawingCSharp
	Public Class EquilateralTriangle
		Implements IShape
		Implements IRotatable
		Private side As Double = 0
		Private orientation As Double = 0

		Public Sub New(side As Double)
			Me.side = side
		End Sub

        Public Sub GrowBy(percent As Double) Implements IShape.GrowBy
            side = side * (1 + percent / 100)
        End Sub

        Public Function Summary() As String Implements IShape.Summary
            Return "Equilateral Triangle, side: " + side.ToString() + " orientation:" + orientation.ToString()
        End Function

        Public Sub RotateBy(degrees As Integer) Implements IRotatable.RotateBy
            orientation = (orientation + degrees) Mod 360
        End Sub

        Public Function DrawAsBitMap() As Byte() Implements IShape.DrawAsBitMap
            Throw New NotImplementedException()
        End Function
    End Class
End Namespace

'=======================================================
'Service provided by Telerik (www.telerik.com)
'Conversion powered by NRefactory.
'Twitter: @telerik
'Facebook: facebook.com/telerik
'=======================================================

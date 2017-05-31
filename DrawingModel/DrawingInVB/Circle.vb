

Namespace DrawingCSharp
	Public Class Circle
		Implements IShape
		Private radius As Double = 0
		Public Sub New(r As Double)
			radius = r
		End Sub

        Public Function DrawAsBitMap() As Byte() Implements IShape.DrawAsBitMap
            Throw New NotImplementedException()
        End Function

        Public Sub GrowBy(percent As Double) Implements IShape.GrowBy
            radius = radius * (1 + percent / 100)
        End Sub
        Public Function Summary() As String Implements IShape.Summary
            Return "Circle, radius: " + radius.ToString()
        End Function
    End Class

End Namespace

'=======================================================
'Service provided by Telerik (www.telerik.com)
'Conversion powered by NRefactory.
'Twitter: @telerik
'Facebook: facebook.com/telerik
'=======================================================



Namespace DrawingCSharp

	Public Class Rectangle
		Implements IRotatable
		Implements IShape
		Private height As Double = 0
		Private width As Double = 0
		Private orientation As Double = 0

		'Constructor
		Public Sub New(h As Double, w As Double)
			height = h
			width = w
		End Sub
        ' Provides a string representation of the object
        Public Function Summary() As String Implements IShape.Summary
            '... and we use self to access properties or other methods
            Return "Rectangle, H: " + height.ToString() + " W: " + width.ToString() + " orientation:" + orientation.ToString()
        End Function
        Public Sub GrowBy(percent As Double) Implements IShape.GrowBy
            height = height * (1 + percent / 100)
            width = width * (1 + percent / 100)
        End Sub

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

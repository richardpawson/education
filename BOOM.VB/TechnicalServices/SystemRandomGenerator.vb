

Namespace TechnicalServices
	'Implementation of IRandomGenerator that uses the System.Random functionality
	'to produce random numbers.
	Public Class SystemRandomGenerator
		Implements IRandomGenerator
		Private Shared Random As New Random()

        Public Function [Next](minValue As Integer, maxValue As Integer) As Integer Implements IRandomGenerator.Next
            Return Random.[Next](minValue, maxValue)
        End Function
    End Class
End Namespace

'=======================================================
'Service provided by Telerik (www.telerik.com)
'Conversion powered by NRefactory.
'Twitter: @telerik
'Facebook: facebook.com/telerik
'=======================================================

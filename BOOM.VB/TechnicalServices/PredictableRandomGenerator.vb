

Namespace TechnicalServices
	'This is a 'mock' implementation of IRandomGenerator, for use
	'in testing, when predictable results are needed.  You can call SetNextValues,
	'passing in as many values as needed (before the next time they are set).
	Public Class PredictableRandomGenerator
		Implements IRandomGenerator
		Private counter As Integer = 0
		Private values As Integer() = Nothing
        Public Function NextValue(minValue As Integer, maxValue As Integer) As Integer Implements IRandomGenerator.NextValue
            If counter >= values.Length Then
                Throw New Exception("Insufficient values set")
            End If
            Dim value As Integer = values(counter)
            If value < minValue OrElse value >= maxValue Then
                Throw New Exception("Value provided (" + value + ") is not within specified range")
            End If
            counter += 1
            Return value
        End Function

        Public Sub SetNextValues(ParamArray values As Integer())
			counter = 0
			Me.values = values
		End Sub
	End Class
End Namespace

'=======================================================
'Service provided by Telerik (www.telerik.com)
'Conversion powered by NRefactory.
'Twitter: @telerik
'Facebook: facebook.com/telerik
'=======================================================

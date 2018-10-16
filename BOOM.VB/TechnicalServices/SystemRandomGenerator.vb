

Namespace TechnicalServices
	'Implementation of IRandomGenerator that uses the System.Random functionality
	'to produce random numbers.
	Public Class SystemRandomGenerator
		Implements IRandomGenerator
		Private Shared Random As New Random()

        Public Function NextValue(minValue As Integer, maxValue As Integer) As Integer Implements IRandomGenerator.NextValue
            Return Random.Next(minValue, maxValue)
        End Function
    End Class
End Namespace


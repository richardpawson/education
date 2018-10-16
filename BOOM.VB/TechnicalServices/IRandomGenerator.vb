
Namespace TechnicalServices
    Public Interface IRandomGenerator
        'Generates next random number within specified range. Note that
        'minValue is inclusive; maxValue is exclusive.
        Function NextValue(minValue As Integer, maxValue As Integer) As Integer
    End Interface
End Namespace

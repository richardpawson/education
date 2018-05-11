Imports System.Text

Public Module Module1

    Sub Main(ByVal args As String())
        While True
            Console.Write("Enter the power of 2: ")
            Dim power As Integer = Convert.ToInt32(Console.ReadLine())
            Console.WriteLine(TwoToThePowerOf(power))
            Console.WriteLine()
        End While
    End Sub

    Public Function TwoToThePowerOf(ByVal power As Integer) As String
        Dim d = New List(Of Integer) From {1}
        For i As Integer = 0 To power - 1
            d = MultiplyByTwo(d)
        Next

        Dim builder = New StringBuilder()
        For Each digit As Integer In d
            builder.Append(digit)
        Next

        Return builder.ToString()
    End Function

    Function MultiplyByTwo(ByVal digits As List(Of Integer), ByVal Optional carryIn As Integer = 0) As List(Of Integer)
        If digits.Count = 0 Then
            Return digits
        Else
            Dim lowestDigit = digits.Last()
            Dim doubledValue = lowestDigit * 2 + carryIn
            Dim carry As Integer = Math.Floor(doubledValue / 10)
            Dim newLowestDigit = doubledValue Mod 10
            If carry > 0 AndAlso digits.Count = 1 Then
                Return New List(Of Integer) From {carry, newLowestDigit}
            Else
                Dim higherDigits = digits.Take(digits.Count - 1).ToList()
                Dim digitsDoubled = MultiplyByTwo(higherDigits, carry)
                digitsDoubled.Add(newLowestDigit)
                Return digitsDoubled
            End If
        End If
    End Function
End Module

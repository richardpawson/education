Module Convertor
    Function AsRomanNumeral(ByVal number As Integer) As String
        Dim values = New Integer() {1000, 900, 500, 400, 100, 90, 50, 40, 10, 9, 5, 4, 1}
        Dim symbols = New String() {"M", "CM", "D", "CD", "C", "XC", "L", "XL", "X", "IX", "V", "IV", "I"}
        Dim result = New StringBuilder()

        For i As Integer = 0 To values.Length - 1
            Dim value = values(i)

            While number >= value
                result.Append(symbols(i))
                number -= value
            End While
        Next

        Return result.ToString()
    End Function
End Module

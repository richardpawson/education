
Module Convertor
    Private symbols As Dictionary(Of Integer, String) = New Dictionary(Of Integer, String) From {
            {1000, "M"},
            {900, "CM"},
            {500, "D"},
            {400, "CD"},
            {100, "C"},
            {90, "XC"},
            {50, "L"},
            {40, "XL"},
            {10, "X"},
            {9, "IX"},
            {5, "V"},
            {4, "IV"},
            {1, "I"}
        }

    Function AsRomanNumeral(ByVal number As Integer) As String
            Dim result = New StringBuilder()

            For Each value As Integer In symbols.Keys

                While number >= value
                    result.Append(symbols(value))
                    number -= value
                End While
            Next

            Return result.ToString()
        End Function
    End Module


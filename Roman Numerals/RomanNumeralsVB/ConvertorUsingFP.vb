Module Convertor
    Private Function AsRomanNumeral(ByVal number As Integer, ByVal values As Integer(), ByVal symbols As String()) As String
        Return If(number >= values(0), symbols(0) & AsRomanNumeral(number - values(0), values, symbols), If(values.Skip(1).Count() = 0, "", AsRomanNumeral(number, values.Skip(1).ToArray(), symbols.Skip(1).ToArray())))
    End Function

    Function AsRomanNumeral(ByVal number As Integer) As String
        Return AsRomanNumeral(number, New Integer() {1000, 900, 500, 400, 100, 90, 50, 40, 10, 9, 5, 4, 1}, New String() {"M", "CM", "D", "CD", "C", "XC", "L", "XL", "X", "IX", "V", "IV", "I"})
    End Function
End Module
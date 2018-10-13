Module Convertor
    Function AsRomanNumeral(ByVal number As Integer, ByVal values As FList(Of Integer), ByVal symbols As FList(Of String)) As String
        Return If(number >= values.Head, symbols.Head & AsRomanNumeral(number - values.Head, values, symbols), If(values.Tail.IsEmpty, "", AsRomanNumeral(number, values.Tail, symbols.Tail)))
    End Function

    Function AsRomanNumeral(ByVal number As Integer) As String
        Return AsRomanNumeral(number, FList.Cons(Of Integer)(1000, 900, 500, 400, 100, 90, 50, 40, 10, 9, 5, 4, 1), FList.Cons(Of String)("M", "CM", "D", "CD", "C", "XC", "L", "XL", "X", "IX", "V", "IV", "I"))
    End Function
End Module

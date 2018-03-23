Imports System.Text

Public Class Core

    Private Tokens As List(Of Object) = New List(Of Object)()

    Public Sub Clear()
        Tokens = New List(Of Object)()
    End Sub

    Friend Sub AddSymbolAsToken(ByVal symbol As Char)
        Tokens.Add(symbol)
    End Sub

    Public Function AddNumberAsToken(ByVal numberAsText As String) As Double
        Dim number As Double = Convert.ToDouble(numberAsText)
        Tokens.Add(number)
        Return number
    End Function

    Public Function TokensAsString() As String
        Dim sb = New StringBuilder()
        For Each token In Tokens
            sb.Append(token.ToString()).Append(" ")
        Next

        Return sb.ToString()
    End Function

    Public Function EvaluateTokensAsRPN() As Double
        Return EvaluateAsRPN(Tokens)
    End Function

    Public Shared Function EvaluateAsRPN(ByVal Tokens As List(Of Object)) As Double
        Throw New NotImplementedException()
    End Function

    Public Function EvaluateTokensAsInfix() As Double
        Dim tokensAsRPN = ConvertInfixToPostfix(Tokens)
        Return EvaluateAsRPN(tokensAsRPN)
    End Function

    Public Shared Function ConvertInfixToPostfix(ByVal inputTokens As List(Of Object)) As List(Of Object)
        Throw New NotImplementedException()
    End Function

    Public Shared Function Priority(ByVal c As Char) As Integer
        Throw New NotImplementedException()
    End Function
End Class

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
        Dim result As Double = 0
        Dim stack = New Stack(Of Double)()
        For Each token As Object In Tokens
            If TypeOf token Is Double Then
                stack.Push(CType(token, Double))
            Else 'Assume it Is a Char
                Select Case CType(token, Char)  'CType is to ‘cast’ the token into a char
                    Case "+"c
                        stack.Push(stack.Pop() + stack.Pop())
                    Case "-"c
                        Dim b = stack.Pop()
                        Dim a = stack.Pop()
                        stack.Push(a - b)
                    Case "*"c
                        stack.Push(stack.Pop() * stack.Pop())
                    Case "/"c
                        Dim d = stack.Pop()
                        Dim c = stack.Pop()
                        stack.Push(c / d)
                End Select
            End If
        Next
        result = stack.Pop()
        Return result
    End Function

    Public Function EvaluateTokensAsInfix() As Double
        Dim tokensAsRPN = ConvertInfixToPostfix(Tokens)
        Return EvaluateAsRPN(tokensAsRPN)
    End Function

    Public Shared Function ConvertInfixToPostfix(ByVal inputTokens As List(Of Object)) As List(Of Object)
        Dim s = New Stack(Of Char)()
        Dim outputList = New List(Of Object)()
        For Each t In inputTokens
            If TypeOf t Is Double Then 'token is a value
                outputList.Add(t) 'send it straight to the output
            Else 'Is is an operator...
                Dim token As Char = CChar(t) '/... so cast it to a char
                If token = "("c Then
                    s.Push(token)
                ElseIf token = ")"c Then
                    Do While s.Count <> 0 AndAlso Not s.Peek().Equals("("c)
                        outputList.Add(s.Pop())
                    Loop
                    s.Pop()
                Else
                    Do While s.Count <> 0 AndAlso Priority(s.Peek()) >= Priority(token)
                        outputList.Add(s.Pop())
                    Loop
                    s.Push(token)
                End If
            End If
        Next t
        Do While s.Count <> 0 'Unload any remaining operators onto the stack
            outputList.Add(s.Pop())
        Loop
        Return outputList
    End Function

    Public Shared Function Priority(ByVal c As Char) As Integer
        If c = "*"c Or c = "/"c Then
            Return 2
        ElseIf c = "+"c Or c = "-" Then
            Return 1
        Else
            Return 0
        End If
    End Function
End Class

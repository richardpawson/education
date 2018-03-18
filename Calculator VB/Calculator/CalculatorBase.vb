Partial Public Class CalculatorBase
    Inherits Form

    Protected Calculator As Core

    Public Sub New()
        InitializeComponent()
        Calculator = New Core()
    End Sub

    Protected Sub TransferNumberToExpression()
        If numericDisplay.Text <> "" Then
            Calculator.AddNumberAsToken(numericDisplay.Text)
            UpdateExpressionDisplay()
            numericDisplay.Clear()
        End If
    End Sub

    Protected Sub UpdateExpressionDisplay()
        expression.Text = Calculator.TokensAsString()
    End Sub

    Protected Sub button0_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button0.Click
        numericDisplay.AppendText("0")
    End Sub

    Protected Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
        numericDisplay.AppendText("1")
    End Sub

    Protected Sub button2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button2.Click
        numericDisplay.AppendText("2")
    End Sub

    Protected Sub button3_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button3.Click
        numericDisplay.AppendText("3")
    End Sub

    Protected Sub button4_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button4.Click
        numericDisplay.AppendText("4")
    End Sub

    Protected Sub button5_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button5.Click
        numericDisplay.AppendText("5")
    End Sub

    Protected Sub button6_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button6.Click
        numericDisplay.AppendText("6")
    End Sub

    Protected Sub button7_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button7.Click
        numericDisplay.AppendText("7")
    End Sub

    Protected Sub button8_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button8.Click
        numericDisplay.AppendText("8")
    End Sub

    Protected Sub button9_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button9.Click
        numericDisplay.AppendText("9")
    End Sub

    Protected Sub decimalPoint_Click(ByVal sender As Object, ByVal e As EventArgs) Handles decimalPoint.Click
        If numericDisplay.Text = "" Then
            numericDisplay.AppendText("0.")
        Else
            numericDisplay.AppendText(".")
        End If
    End Sub

    Protected Sub plus_Click(ByVal sender As Object, ByVal e As EventArgs) Handles plus.Click
        AddOperator("+"c)
    End Sub

    Protected Sub minus_Click(ByVal sender As Object, ByVal e As EventArgs) Handles minus.Click
        AddOperator("-"c)
    End Sub

    Protected Sub times_Click(ByVal sender As Object, ByVal e As EventArgs) Handles times.Click
        AddOperator("*"c)
    End Sub

    Protected Sub divide_Click(ByVal sender As Object, ByVal e As EventArgs) Handles divide.Click
        AddOperator("/"c)
    End Sub

    Protected Sub AddOperator(ByVal op As Char)
        TransferNumberToExpression()
        Calculator.AddSymbolAsToken(op)
        UpdateExpressionDisplay()
    End Sub

    Protected Sub clear_Click(ByVal sender As Object, ByVal e As EventArgs) Handles clearAll.Click
        numericDisplay.Clear()
        Calculator.Clear()
        UpdateExpressionDisplay()
    End Sub

    Protected Sub clearEntry_Click(ByVal sender As Object, ByVal e As EventArgs) Handles clearEntry.Click
        numericDisplay.Clear()
    End Sub

    Protected Sub DisplayResult(ByVal result As Double)
        If result > 0 Then
            numericDisplay.Text = result.ToString()
        Else
            numericDisplay.Text = "- "
            numericDisplay.AppendText((-result).ToString())
        End If
    End Sub
End Class

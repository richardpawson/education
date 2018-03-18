
Partial Public Class CalculatorRPN
    Inherits CalculatorBase

    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub enter_Click(ByVal sender As Object, ByVal e As EventArgs) Handles enter.Click
        TransferNumberToExpression()
    End Sub

    Private Sub evaluate_Click(ByVal sender As Object, ByVal e As EventArgs) Handles evaluate.Click
        Try
            DisplayResult(Calculator.EvaluateTokensAsRPN())
        Catch __unusedException1__ As Exception
            numericDisplay.Text = "Error!"
        End Try
    End Sub
End Class

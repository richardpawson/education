
Imports System

Namespace Calculator

    Public Partial Class CalculatorRPN
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
End Namespace

'=======================================================
'Service provided by Telerik (www.telerik.com)
'Conversion powered by Refactoring Essentials.
'Twitter: @telerik
'Facebook: facebook.com/telerik
'=======================================================

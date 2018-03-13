
Imports System

Namespace Calculator

    Public Partial Class CalculatorInfix
        Inherits CalculatorBase

        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub equals_click(ByVal sender As Object, ByVal e As EventArgs) Handles equals.Click
            TransferNumberToExpression()
            Try
                DisplayResult(Calculator.EvaluateTokensAsInfix())
            Catch __unusedException1__ As Exception
                numericDisplay.Text = "Error!"
            End Try
        End Sub

        Private Sub openBracket_Click(ByVal sender As Object, ByVal e As EventArgs) Handles openBracket.Click
            AddOperator("("c)
        End Sub

        Private Sub closeBracket_Click(ByVal sender As Object, ByVal e As EventArgs) Handles closeBracket.Click
            AddOperator(")"c)
        End Sub
    End Class
End Namespace

'=======================================================
'Service provided by Telerik (www.telerik.com)
'Conversion powered by Refactoring Essentials.
'Twitter: @telerik
'Facebook: facebook.com/telerik
'=======================================================

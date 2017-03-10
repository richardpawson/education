
Imports Boom.DataFixture
Imports Boom.Model
Imports System.Drawing
Imports System.Windows.Forms
Imports TechnicalServices

Namespace Boom.WinFormsUI
    Partial Public Class Form1
        Inherits Form
        Private blackPen As New Pen(Color.Black)
        Private redBrush As Brush = New SolidBrush(Color.Red)
        Private blueBrush As Brush = New SolidBrush(Color.Blue)
        Private whiteBrush As Brush = New SolidBrush(Color.White)

        Private Board As GameBoard
        Private Logger As New ReadableLogger()

        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub InitializeGame(ships As Ship())
            Logger.StartLogging()
            Dim randomGenerator = New SystemRandomGenerator()
            Board = New GameBoard(10, ships, Logger, randomGenerator)
        End Sub

        Private Sub DrawBoard()
            Const squareSize As Integer = 30
            Dim g = pictureBox1.CreateGraphics()
            For col As Integer = 0 To Board.Size - 1
                For row As Integer = 0 To Board.Size - 1
                    Dim square = Board.ReadSquare(col, row)
                    Dim brush As Brush = Nothing
                    Select Case square
                        Case SquareValues.Empty
                            brush = whiteBrush
                            Exit Select
                        Case SquareValues.Miss
                            brush = blueBrush
                            Exit Select
                        Case SquareValues.Hit
                            brush = redBrush
                            Exit Select
                    End Select
                    If square = SquareValues.Hit Then
                        brush = redBrush
                    ElseIf square = SquareValues.Miss Then
                        brush = blueBrush
                    End If
                    DrawSquare(squareSize, g, row, col, brush)
                Next
            Next
        End Sub

        Private Sub DrawSquare(squareSide As Integer, g As Graphics, row As Integer, col As Integer, fill As Brush)
            g.DrawRectangle(blackPen, col * squareSide, row * squareSide, squareSide, squareSide)
            If fill IsNot Nothing Then
                g.FillRectangle(fill, col * squareSide + 1, row * squareSide + 1, squareSide - 1, squareSide - 1)
            End If
        End Sub
#Region "Button clicks"
        Private Sub button1_Click(sender As Object, e As EventArgs)
            Dim ships__1 = Ships.TrainingGame()
            InitializeGame(ships__1)
            DrawBoard()
        End Sub
        Private Sub button2_Click(sender As Object, e As EventArgs)
            FireWeapon(New Missile())
        End Sub
        Private Sub button3_Click(sender As Object, e As EventArgs)
            Dim ships__1 = Ships.UnplacedShips5()
            InitializeGame(ships__1)
            Board.RandomiseShipPlacement()
            DrawBoard()
        End Sub

        Private Sub button4_Click(sender As Object, e As EventArgs)
            FireWeapon(New Bomb())
        End Sub
#End Region

        Private Sub FireWeapon(weapon As IWeapon)
            Dim row = Convert.ToInt16(comboBox1.SelectedItem)
            Dim col = Convert.ToInt16(comboBox2.SelectedItem)
            weapon.Fire(col, row, Board)
            DrawBoard()
            richTextBox1.Text = Logger.ReadAndResetLog()
        End Sub

    End Class
End Namespace

'=======================================================
'Service provided by Telerik (www.telerik.com)
'Conversion powered by NRefactory.
'Twitter: @telerik
'Facebook: facebook.com/telerik
'=======================================================

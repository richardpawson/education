
Imports TechnicalServices
Imports Boom.Model
Imports Boom.DataFixture

Namespace Boom.ConsoleUI
    Public Class Program
        Public Shared Sub Main(args As String())
            Dim logger = New ConsoleLogger()
            logger.StartLogging()
            Dim randomGenerator = New SystemRandomGenerator()
            Dim Board As GameBoard = Nothing

            Dim MenuOption As Integer = 0
            While MenuOption <> 9
                DisplayMenu()
                MenuOption = GetMainMenuChoice()
                If MenuOption = 1 Then
                    Dim ships__1 = Ships.UnplacedShips5()
                    Board = New GameBoard(10, ships__1, logger, randomGenerator)
                    Board.RandomiseShipPlacement()
                End If
                If MenuOption = 2 Then
                    Dim ships__1 = Ships.TrainingGame()
                    Board = New GameBoard(10, ships__1, logger, randomGenerator)
                End If
                PlayGame(Board)
            End While
        End Sub

        Private Shared Sub DisplayMenu()
            Console.WriteLine("MAIN MENU")
            Console.WriteLine("")
            Console.WriteLine("1. Start new game")
            Console.WriteLine("2. Load training game")
            Console.WriteLine("9. Quit")
            Console.WriteLine()
        End Sub

        Private Shared Function GetMainMenuChoice() As Integer
            Dim Choice As Integer = 0
            Console.Write("Please enter your choice: ")
            Choice = Convert.ToInt32(Console.ReadLine())
            Console.WriteLine()
            Return Choice
        End Function

        Private Shared Sub PlayGame(Board As GameBoard)
            Dim GameWon As Boolean = False
            While Not GameWon
                PrintBoard(Board)
                Dim missile As IWeapon = Nothing
                Dim missileType = GetMissileType()
                Dim col = GetColumn()
                Dim row = GetRow()
                If missileType = "M" Then
                    missile = New Missile()
                End If
                If missileType = "B" Then
                    missile = New Bomb()
                End If
                missile.Fire(col, row, Board)
            End While
        End Sub

        Private Shared Function GetMissileType() As String
            Console.WriteLine()
            Console.Write("Please enter type (M) missile, (B) Bomb: ")
            Return Console.ReadLine().ToUpper()
        End Function

        Private Shared Function GetColumn() As Integer
            Console.Write("Please enter column: ")
            Return Convert.ToInt32(Console.ReadLine())
        End Function

        Private Shared Function GetRow() As Integer
            Console.Write("Please enter row: ")
            Dim row = Convert.ToInt32(Console.ReadLine())
            Console.WriteLine()
            Return row
        End Function

        Private Shared Sub PrintBoard(board As GameBoard)
            Dim boardSize As Integer = board.Size
            Console.WriteLine()
            Console.WriteLine("The board looks like this: ")
            Console.WriteLine()
            Console.Write(" ")
            For Column As Integer = 0 To boardSize - 1
                Console.Write(" " + Column.ToString() + "  ")
            Next
            Console.WriteLine()
            For row As Integer = 0 To boardSize - 1
                Console.Write(row.ToString() + " ")
                For col As Integer = 0 To boardSize - 1
                    Dim square As SquareValues = board.ReadSquare(col, row)
                    Select Case square
                        Case SquareValues.Empty
                            Console.Write(" "c)
                            Exit Select
                        Case SquareValues.Miss
                            Console.Write("m"c)
                            Exit Select
                        Case SquareValues.Hit
                            Console.Write("h"c)
                            Exit Select
                    End Select

                    If col <> boardSize - 1 Then
                        Console.Write(" | ")
                    End If
                Next
                Console.WriteLine()
            Next
        End Sub
    End Class
End Namespace

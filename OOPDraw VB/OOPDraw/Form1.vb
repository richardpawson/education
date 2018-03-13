Imports Nakov.TurtleGraphics

Public Class Form1

    Private shapes As List(Of Shape) = New List(Of Shape)()
    Private mostRecent As Shape

    Private Sub Form1_MouseClick(sender As Object, e As MouseEventArgs) Handles MyBase.MouseClick
        Dim turtleX As Single = CType(e.X - Width / 2 + 8, Single)
        Dim turtleY As Single = CType(Height / 2 - e.Y - 19, Single)
        Dim selectedItem As String = CType(ComboBox1.SelectedItem, String)
        If selectedItem = "Draw Triangle" Then 'We Then will add more options later
            Dim tri = New EquliateralTriangle(turtleX, turtleY, 50)
            shapes.Add(tri)
            mostRecent = tri
        ElseIf selectedItem = "Draw Rectangle" Then
            Dim rec = New Rectangle(turtleX, turtleY, 100, 50)
            shapes.Add(rec)
            mostRecent = rec
        ElseIf selectedItem = "Move Shape" Then
            mostRecent.MoveTo(turtleX, turtleY)
        End If
        DrawAll()
    End Sub

    Public Sub DrawAll()
        Turtle.Dispose()  'First clear all Turtle tracks To start afresh
        For Each shape In shapes
            shape.Draw()
        Next
    End Sub

End Class

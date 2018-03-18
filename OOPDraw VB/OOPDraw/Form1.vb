Imports Nakov.TurtleGraphics

Public Class Form1

    Private shapes As List(Of Shape) = New List(Of Shape)()

    Private Sub Form1_MouseClick(sender As Object, e As MouseEventArgs) Handles MyBase.MouseClick
        Dim turtleX As Single = CType(e.X - Width / 2 + 8, Single)
        Dim turtleY As Single = CType(Height / 2 - e.Y - 19, Single)
        Dim selectedItem As String = CType(ComboBox1.SelectedItem, String)
        If selectedItem = "Draw Triangle" Then 'We Then will add more options later
            AddShape(New EquliateralTriangle(turtleX, turtleY, 50))
        ElseIf selectedItem = "Draw Rectangle" Then
            AddShape(New Rectangle(turtleX, turtleY, 100, 50))
        ElseIf selectedItem = "Draw House" Then
            AddShape(New House(turtleX, turtleY, 100, 50))
        ElseIf selectedItem = "Move Shape" Then
            ActiveShape().MoveTo(turtleX, turtleY)
        ElseIf selectedItem = "Resize Shape" Then
            ActiveShape().ResizeAbsolute(turtleX, turtleY)
        End If
        DrawAll()
    End Sub

    'ActiveShape().Resize(turtleX, turtleY)

    Private Sub AddShape(shape As Shape)
        If shapes.Count > 0 Then
            ActiveShape().UnselectShape()
        End If
        shapes.Add(shape)
        activeShapeNumber = shapes.Count - 1  'i.e. the shape just added
        ActiveShape().SelectShape()
    End Sub

    Public Sub DrawAll()
        Turtle.Dispose()  'First clear all Turtle tracks To start afresh
        For Each shape In shapes
            shape.Draw()
        Next
    End Sub

    Private activeShapeNumber As Integer = 0

    Private Function ActiveShape() As Shape
        Return shapes(activeShapeNumber) 'List elements can be accessed Like an array
    End Function

    Private Sub NextShape_Click(sender As Object, e As EventArgs) Handles NextShape.Click
        ActiveShape().UnselectShape()
        activeShapeNumber = activeShapeNumber + 1
        If (activeShapeNumber >= shapes.Count) Then activeShapeNumber = 0
        ActiveShape().SelectShape()
        DrawAll()
    End Sub

    Private Sub PrevShape_Click(sender As Object, e As EventArgs) Handles PrevShape.Click
        ActiveShape().UnselectShape()
        activeShapeNumber = activeShapeNumber - 1
        If (activeShapeNumber < 0) Then activeShapeNumber = shapes.Count - 1
        ActiveShape().SelectShape()
        DrawAll()
    End Sub
End Class

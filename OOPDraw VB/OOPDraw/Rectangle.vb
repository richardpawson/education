Imports Nakov.TurtleGraphics

Public Class Rectangle
    Inherits Shape
    'Properties
    Private Property Width As Single
    Private Property Height As Single

    'The 'Constructor'
    Public Sub New(xOrigin As Single, yOrigin As Single, width As Single, height As Single)
        MyBase.New(xOrigin, yOrigin)
        Me.Width = width
        Me.Height = height
    End Sub

    Public Overrides Sub Draw()
        ResetTurtle()
        For i = 1 To 10
            Turtle.Forward(Height)
            Turtle.Rotate(90)
            Turtle.Forward(Width)
            Turtle.Rotate(90)
        Next
    End Sub

    Public Overrides Sub Resize(x As Single, y As Single)
        Width = x
        Height = y
    End Sub

End Class

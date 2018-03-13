Imports Nakov.TurtleGraphics

Public Class Rectangle
    Implements Shape
    'Properties
    Private Property XOrigin As Single
    Private Property YOrigin As Single
    Private Property Width As Single
    Private Property Height As Single

    'The 'Constructor'
    Public Sub New(xOrigin As Single, yOrigin As Single, width As Single, height As Single)
        Me.XOrigin = xOrigin
        Me.YOrigin = yOrigin
        Me.Width = width
        Me.Height = height
    End Sub

    Public Sub Draw() Implements Shape.Draw
        Turtle.ShowTurtle = False
        Turtle.PenSize = 2
        Turtle.Angle = 0  'Always start from North
        Turtle.X = XOrigin
        Turtle.Y = YOrigin
        For i = 1 To 10
            Turtle.Forward(Height)
            Turtle.Rotate(90)
            Turtle.Forward(Width)
            Turtle.Rotate(90)
        Next
    End Sub
End Class

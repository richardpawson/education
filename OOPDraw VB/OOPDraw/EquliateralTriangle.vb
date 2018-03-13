Imports Nakov.TurtleGraphics

Public Class EquliateralTriangle
    Implements Shape
    'Properties
    Private Property XOrigin As Single
    Private Property YOrigin As Single
    Private Property SideLength As Single

    'The 'Constructor'
    Public Sub New(xOrigin As Single, yOrigin As Single, sideLength As Single)
        Me.XOrigin = xOrigin
        Me.YOrigin = yOrigin
        Me.SideLength = sideLength
    End Sub

    Public Sub Draw() Implements Shape.Draw
        Turtle.ShowTurtle = False
        Turtle.PenSize = 2
        Turtle.Angle = 0  'Always start from North
        Turtle.X = XOrigin
        Turtle.Y = YOrigin
        Turtle.Rotate(30)
        For i = 1 To 3
            Turtle.Forward(SideLength)
            Turtle.Rotate(120)
        Next
    End Sub

    Public Sub MoveTo(x As Single, y As Single)
        XOrigin = x
        YOrigin = y
    End Sub

End Class

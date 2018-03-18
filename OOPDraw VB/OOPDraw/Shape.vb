Imports Nakov.TurtleGraphics

Public MustInherit Class Shape
    Protected Property XOrigin As Single
    Protected Property YOrigin As Single
    Private Property LineWidth As Single

    Public Sub New(xOrigin As Single, yOrigin As Single)
        Me.XOrigin = xOrigin
        Me.YOrigin = yOrigin
    End Sub

    Public Overridable Sub SelectShape()
        LineWidth = 4
    End Sub

    Public Overridable Sub UnselectShape()
        LineWidth = 2
    End Sub

    Public MustOverride Sub Draw()

    Public Overridable Sub MoveTo(x As Single, y As Single)
        XOrigin = x
        YOrigin = y
    End Sub

    Public Sub MoveBy(x As Single, y As Single)
        XOrigin += x
        YOrigin += y
    End Sub

    Public Sub ResizeAbsolute(turtleX As Single, turtleY As Single)
        Resize(Math.Abs(turtleX - XOrigin), Math.Abs(turtleY - YOrigin))
    End Sub

    Public MustOverride Sub Resize(x As Single, y As Single)

    Protected Sub ResetTurtle()
        Turtle.ShowTurtle = False
        Turtle.PenSize = LineWidth
        Turtle.Angle = 0 'Always start from North
        Turtle.X = XOrigin
        Turtle.Y = YOrigin
    End Sub
End Class

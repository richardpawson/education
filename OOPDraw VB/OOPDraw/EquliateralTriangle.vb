Imports Nakov.TurtleGraphics

Public Class EquliateralTriangle
    Inherits Shape
    'Properties
    Private Property SideLength As Single

    'The 'Constructor'
    Public Sub New(xOrigin As Single, yOrigin As Single, sideLength As Single)
        MyBase.New(xOrigin, yOrigin)
        Me.SideLength = sideLength
    End Sub

    Public Overrides Sub Draw()
        ResetTurtle()
        Turtle.Rotate(30)
        For i = 1 To 3
            Turtle.Forward(SideLength)
            Turtle.Rotate(120)
        Next
    End Sub

    Public Overrides Sub Resize(x As Single, y As Single)
        'Ignore y
        SideLength = x
    End Sub
End Class

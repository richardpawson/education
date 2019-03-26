Imports System.Drawing

Namespace Pathfinder
    Public Class Scenario
        Public Property Name As String
        Public Property Graph As GridGraph
        Public Property Start As Point
        Public Property Destination As Point

        Public Sub New(ByVal n As String, ByVal g As GridGraph, ByVal strt As Point, ByVal dest As Point)
            Name = n
            Graph = g
            Start = strt
            Destination = dest
        End Sub

        Public Overrides Function ToString() As String
            Return Name
        End Function
    End Class
End Namespace


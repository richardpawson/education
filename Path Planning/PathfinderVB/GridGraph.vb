Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Drawing

Namespace Pathfinder
    Public Class GridGraph
        Public Property GridSize As Integer
        Public Property Nodes As HashSet(Of Point)

        Public Sub New(ByVal gs As Integer)
            Nodes = New HashSet(Of Point)()
            GridSize = gs
            SetBlock(New Point(0, 0), New Point(GridSize - 1, GridSize - 1), True)
        End Sub

        Public Sub SetBlock(ByVal p1 As Point, ByVal p2 As Point, ByVal Optional add As Boolean = False)
            For x As Integer = p1.X To p2.X

                For y As Integer = p1.Y To p2.Y
                    Dim p As Point = New Point(x, y)

                    If add Then
                        Nodes.Add(p)
                    Else
                        Nodes.Remove(p)
                    End If
                Next
            Next
        End Sub

        Private Function NodeExists(ByVal p As Point) As Boolean
            Return Nodes.Contains(p)
        End Function

        Private Function EdgeExists(ByVal p1 As Point, ByVal p2 As Point) As Boolean
            Return NodeExists(p1) AndAlso NodeExists(p2) AndAlso Not p1.Equals(p2) AndAlso (PointsAreAdjacentOrthogonally(p1, p2) OrElse PointsAreAdjacentDiagonally(p1, p2))
        End Function

        Private Function PointsAreAdjacentDiagonally(ByVal p1 As Point, ByVal p2 As Point) As Boolean
            Return Math.Abs(p1.X - p2.X) = 1 AndAlso Math.Abs(p1.Y - p2.Y) = 1
        End Function

        Private Function PointsAreAdjacentOrthogonally(ByVal p1 As Point, ByVal p2 As Point) As Boolean
            Return Math.Abs(p1.X - p2.X) = 1 AndAlso (p1.Y = p2.Y) OrElse Math.Abs(p1.Y - p2.Y) = 1 AndAlso (p1.X = p2.X)
        End Function

        Public Function FindEdge(ByVal p1 As Point, ByVal p2 As Point) As Double?
            If EdgeExists(p1, p2) Then

                If PointsAreAdjacentDiagonally(p1, p2) Then
                    Return Math.Sqrt(2)
                Else
                    Return 1
                End If
            Else
                Return Nothing
            End If
        End Function

        Public Function Neighbours(ByVal p As Point) As List(Of Point)
            Dim list = New List(Of Point)() From {
                New Point(p.X, p.Y - 1),
                New Point(p.X + 1, p.Y - 1),
                New Point(p.X + 1, p.Y),
                New Point(p.X + 1, p.Y + 1),
                New Point(p.X, p.Y + 1),
                New Point(p.X - 1, p.Y + 1),
                New Point(p.X - 1, p.Y),
                New Point(p.X - 1, p.Y - 1)
            }
            Return list.Where(Function(n) NodeExists(n)).ToList()
        End Function

        Public Function ShortestPath(ByVal source As Point, ByVal destination As Point, ByVal alg As Algorithms) As List(Of Point)
            Dim visited As Dictionary(Of Point, Boolean) = NewDictionaryOfAllPointsReturningFalseValues()
            Dim costFromSource As Dictionary(Of Point, Double) = NewDictionaryOfAllPointsReturningDoublesSetToInfinity()
            Dim via As Dictionary(Of Point, Point?) = NewDictionaryOfAllPointsReturningNull()
            Dim currentNode = source
            costFromSource(currentNode) = 0

            While currentNode <> destination
                visited(currentNode) = True
                UpdateCostAndViaOfEachNeighbourIfApplicable(costFromSource, via, currentNode, destination)
                currentNode = NextNodeToVisit(currentNode, visited, costFromSource, destination, alg)

                If costFromSource(currentNode) = Double.PositiveInfinity Then
                    Throw New Exception("Cannot reach destination -  graph is 'disconnected'")
                End If
            End While

            Return RetraceRoute(destination, source, via)
        End Function

        Public Function NewDictionaryOfAllPointsReturningNull() As Dictionary(Of Point, Point?)
            Dim dict = New Dictionary(Of Point, Point?)()

            For Each p As Point In Nodes
                dict.Add(p, Nothing)
            Next

            Return dict
        End Function

        Public Function NewDictionaryOfAllPointsReturningDoublesSetToInfinity() As Dictionary(Of Point, Double)
            Dim dict = New Dictionary(Of Point, Double)()

            For Each p As Point In Nodes
                dict.Add(p, Double.PositiveInfinity)
            Next

            Return dict
        End Function

        Public Function NewDictionaryOfAllPointsReturningFalseValues() As Dictionary(Of Point, Boolean)
            Dim dict = New Dictionary(Of Point, Boolean)()

            For Each p As Point In Nodes
                dict.Add(p, False)
            Next

            Return dict
        End Function

        Public Sub UpdateCostAndViaOfEachNeighbourIfApplicable(ByVal costFromSource As Dictionary(Of Point, Double), ByVal via As Dictionary(Of Point, Point?), ByVal currentNode As Point, ByVal destination As Point)
            For Each neighbour In Neighbours(currentNode)
                Dim newCost As Double = costFromSource(currentNode) + FindEdge(currentNode, neighbour).Value

                If newCost < costFromSource(neighbour) Then
                    costFromSource(neighbour) = newCost
                    via(neighbour) = currentNode
                End If
            Next
        End Sub

        Public Function EstimatedCostToDestination(ByVal current As Point, ByVal destination As Point) As Double
            Return Math.Sqrt(Math.Pow(current.X - destination.X, 2) + Math.Pow(current.Y - destination.Y, 2))
        End Function

        Public Function NextNodeToVisit(ByVal currentNode As Point, ByVal visited As Dictionary(Of Point, Boolean), ByVal costFromSource As Dictionary(Of Point, Double), ByVal destination As Point, ByVal alg As Algorithms) As Point
            Dim lowestCostSoFar = Double.PositiveInfinity
            Dim lowestCostNode As Point = Nodes.First()
            Dim possibilities = Nodes.Where(Function(n) Not visited(n) AndAlso costFromSource(n) < Double.PositiveInfinity)

            If possibilities.Count() = 0 Then
                Throw New Exception("The graph is disconnected -  there are no routes from start to destination.")
            End If

            For Each p As Point In possibilities
                Dim cost As Double = 0

                Select Case alg
                    Case Algorithms.Dijkstra
                        cost = costFromSource(p)
                    Case Algorithms.Optimistic
                        cost = EstimatedCostToDestination(p, destination)
                    Case Algorithms.AStar
                        cost = costFromSource(p) + EstimatedCostToDestination(p, destination)
                    Case Else
                End Select

                If cost < lowestCostSoFar Then
                    lowestCostSoFar = cost
                    lowestCostNode = p
                End If
            Next

            Return lowestCostNode
        End Function

        Public Function RetraceRoute(ByVal destination As Point, ByVal source As Point, ByVal via As Dictionary(Of Point, Point?)) As List(Of Point)
            Dim result = New List(Of Point)() From {
                destination
            }
            Dim currentNode = destination

            While currentNode <> source
                Dim previous = via(currentNode)
                result.Insert(0, previous.Value)
                currentNode = previous.Value
            End While

            Return result
        End Function

        Public Function SumOfEdges(ByVal route As List(Of Point)) As Double
            Dim result As Double = 0
            Dim [step] As Integer = 0

            While [step] < route.Count - 1
                result += FindEdge(route([step]), route([step] + 1)).Value
                [step] += 1
            End While

            Return result
        End Function
    End Class
End Namespace

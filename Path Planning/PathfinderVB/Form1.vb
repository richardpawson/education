Imports System.Threading
Imports PathfinderVB.Pathfinder

Public Class Form1

    Private blackPen As Pen = New Pen(Color.Black)
    Private whiteBrush As Brush = New SolidBrush(Color.White)
    Const squareSize As Integer = 10
    Private graphics As Graphics
    Private redBrush As Brush = New SolidBrush(Color.Red)
    Private blueBrush As Brush = New SolidBrush(Color.Blue)
    Private scenario As Scenario

    Public Sub New()
        InitializeComponent()
        graphics = Grid.CreateGraphics()
        StartButton.Enabled = True
        scenario = Scenarios.AllScenarios().ElementAt(1)
        DrawScenario()
        ScenarioSelector.DataSource = Scenarios.AllScenarios()
        AlgorithmSelector.DataSource = System.Enum.GetValues(GetType(Algorithms)).Cast(Of Algorithms)()
    End Sub

    Private Function GridDrawSize() As Integer
        Return (scenario.Graph.GridSize) * squareSize
    End Function

    Private Sub ScenarioSelector_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ScenarioSelector.SelectedIndexChanged
        scenario = CType(ScenarioSelector.SelectedValue, Scenario)
        DrawScenario()
        StartButton.Enabled = True
    End Sub

    Private Sub DrawScenario()
        DrawGraph(scenario.Graph)
        DrawStartAndFinish()
    End Sub

    Private Sub DrawStartAndFinish()
        DrawSquare(scenario.Start, New SolidBrush(Color.Red))
        DrawSquare(scenario.Destination, New SolidBrush(Color.Green))
    End Sub

    Private Sub DrawGraph(ByVal graph As GridGraph)
        PaintBackGroundBlack()

        For Each node As Point In graph.Nodes
            DrawSquare(node, whiteBrush)
        Next

        DrawStartAndFinish()
    End Sub

    Private Sub PaintBackGroundBlack()
        Dim rect = New Rectangle(New Point(0, 0), New Size(GridDrawSize(), GridDrawSize()))
        graphics.FillRectangle(New SolidBrush(Color.Black), rect)
    End Sub

    Private Sub DrawSquare(ByVal square As Point, ByVal brush As Brush)
        Dim col As Integer = square.X
        Dim row As Integer = square.Y
        Dim pen = New Pen(Color.Black)
        graphics.DrawRectangle(pen, col * squareSize, row * squareSize, squareSize, squareSize)

        If brush IsNot Nothing Then
            graphics.FillRectangle(brush, col * squareSize + 1, row * squareSize + 1, squareSize - 1, squareSize - 1)
        End If
    End Sub

    Private Sub StartButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles StartButton.Click
        Dim route = ShortestPath(scenario)

        For Each p As Point In route
            DrawSquare(p, New SolidBrush(Color.Yellow))
        Next

        DrawStartAndFinish()
    End Sub

    Private Function ScenarioList() As List(Of Scenario)
        Return Scenarios.AllScenarios()
    End Function

    Private Function ShortestPath(ByVal s As Scenario) As List(Of Point)
        Dim source = s.Start
        Dim destination = s.Destination
        Dim graph = s.Graph
        Dim visited As Dictionary(Of Point, Boolean) = graph.NewDictionaryOfAllPointsReturningFalseValues()
        Dim costFromSource As Dictionary(Of Point, Double) = graph.NewDictionaryOfAllPointsReturningDoublesSetToInfinity()
        Dim via As Dictionary(Of Point, Point?) = graph.NewDictionaryOfAllPointsReturningNull()
        Dim count As Integer = 0
        Dim currentNode = source
        costFromSource(currentNode) = 0

        While currentNode <> destination
            visited(currentNode) = True
            count += 1
            graph.UpdateCostAndViaOfEachNeighbourIfApplicable(costFromSource, via, currentNode, destination)
            currentNode = graph.NextNodeToVisit(currentNode, visited, costFromSource, destination, CType(AlgorithmSelector.SelectedValue, Algorithms))
            DrawSquare(currentNode, New SolidBrush(Color.LightBlue))
            Thread.Sleep(CInt(Speed.Value))
        End While

        count += 1
        visitedCount.Text = count.ToString()
        Dim route = graph.RetraceRoute(destination, source, via)
        pathLength.Text = Math.Round(graph.SumOfEdges(route), 2).ToString()
        Return route
    End Function

    Private Sub ResetButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ResetButton.Click
        DrawScenario()
        visitedCount.Clear()
        pathLength.Clear()
    End Sub

    Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        TopMost = True
        WindowState = FormWindowState.Maximized
    End Sub

End Class


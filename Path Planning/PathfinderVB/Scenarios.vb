Namespace Pathfinder
    Module Scenarios
        Const GridSize As Integer = 40

        Function AllScenarios() As List(Of Scenario)
            Dim list = New List(Of Scenario)()
            list.Add(Empty())
            list.Add(Simple())
            list.Add(RockyField())
            list.Add(Fences())
            Return list
        End Function

        Private Function Empty() As Scenario
            Dim g = New GridGraph(GridSize)
            Dim s = New Scenario("Empty", g, New Point(0, 0), New Point(0, 0))
            Return s
        End Function

        Private Function Simple() As Scenario
            Dim g = New GridGraph(GridSize)
            g.SetBlock(New Point(10, 20), New Point(30, 20), False)
            g.SetBlock(New Point(20, 10), New Point(20, 30), False)
            Dim s = New Scenario("Simple", g, New Point(15, 15), New Point(25, 25))
            Return s
        End Function

        Private Function RockyField() As Scenario
            Dim start = New Point(0, 0)
            Dim destination = New Point(39, 39)
            Dim rng = New Random()
            Dim g = New GridGraph(GridSize)

            For i As Integer = 0 To 400 - 1
                Dim p = New Point(rng.[Next](GridSize), rng.[Next](GridSize))

                If p <> start AndAlso p <> destination Then
                    g.SetBlock(p, p, False)
                End If
            Next

            Dim s = New Scenario("Rocky field", g, start, destination)
            Return s
        End Function

        Private Function Fences() As Scenario
            Dim start = New Point(0, 0)
            Dim destination = New Point(39, 39)
            Dim rng = New Random()
            Dim g = New GridGraph(GridSize)

            For i As Integer = 0 To 20 - 1
                Dim x = rng.[Next](GridSize)
                Dim y = rng.[Next](GridSize)
                Dim begin = New Point(x, y)
                Dim orientation = rng.[Next](2)
                Dim [end] = New Point(0, 0)

                If orientation > 0 Then
                    [end] = New Point(x, y + rng.[Next](GridSize - y))
                Else
                    [end] = New Point(x + rng.[Next](GridSize - x), y)
                End If

                g.SetBlock(begin, [end], False)
            Next

            g.SetBlock(start, start, True)
            g.SetBlock(destination, destination, True)
            Dim s = New Scenario("Fences", g, start, destination)
            Return s
        End Function
    End Module
End Namespace

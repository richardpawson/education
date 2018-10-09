Module Module1

    Sub Main(ByVal args As String())
        Dim names = girls.OrderBy(Function(a) a.Length())

        For Each name In names
            Console.WriteLine(name)
        Next

        Console.ReadKey()
    End Sub


    Dim testScores As Integer() = {45, 87, 23, 66, 70, 52, 48, 32, 90}
    Dim girls As String() = {"Olivia", "Emma", "Ali", "Isabella", "Sophia", "Mia", "Charlotte", "Amelia", "Evelyn", "Abigail"}
    Dim boys As ArrayList = New ArrayList From {
        "Sebastian",
        "Noah",
        "Oliver",
        "James",
        "Adi",
        "Alexander",
        "Benjamin",
        "Zvi"
    }



End Module

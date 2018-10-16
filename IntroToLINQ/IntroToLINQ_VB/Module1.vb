Module Module1



    Sub Main(ByVal args As String())

        Dim collection = girls;

        For Each item In Collection
            Console.WriteLine(item)
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

#Region "Objects"
    Public Function CreateStudents() As List(Of Student)
        Dim list = New List(Of Student)()
        list.Add(New Student("Olivia", 345, YearGroup.U6, 9))
        list.Add(New Student("Noah", 744, YearGroup.U6, 7))
        list.Add(New Student("Emma", 219, YearGroup.L6, 8))
        list.Add(New Student("Adi", 700, YearGroup.U6, 6))
        list.Add(New Student("Charlotte", 345, YearGroup.L6, 6))
        list.Add(New Student("Sebastian", 118, YearGroup.U6, 8))
        list.Add(New Student("James", 219, YearGroup.L6, 5))
        list.Add(New Student("Mia", 700, YearGroup.U6, 7))
        Return list
    End Function
#End Region


End Module

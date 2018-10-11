Imports System
Imports System.Collections.Generic
Imports System.Linq

Namespace IntroToLINQ
    Class Program
        Private Shared Sub Main(ByVal args As String())
            Dim context = New MyDbContext("MyDb")

            For Each s As Student In CreateStudents()
                context.Students.Add(s)
            Next

            context.SaveChanges()
            Dim students = context.Students.Where(Function(s) s.GCSEGrade > 7).OrderBy(Function(s) s.FullName)

            For Each student In students
                Console.WriteLine(student.Summary())
            Next

            Console.ReadKey()
        End Sub

        Private Shared Function CreateStudents() As List(Of Student)
            Dim list = New List(Of Student)()
            list.Add(New Student("Olivia", 345, Sex.Female, 8))
            list.Add(New Student("Noah", 744, Sex.Male, 6))
            list.Add(New Student("Emma", 219, Sex.Female, 7))
            list.Add(New Student("Adi", 700, Sex.Male, 9))
            list.Add(New Student("Charlotte", 345, Sex.Female, 6))
            list.Add(New Student("Sebastian", 744, Sex.Male, 5))
            list.Add(New Student("James", 219, Sex.Male, 8))
            list.Add(New Student("Mia", 700, Sex.Female, 9))
            Return list
        End Function
    End Class
End Namespace

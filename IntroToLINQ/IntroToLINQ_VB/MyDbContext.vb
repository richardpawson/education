Imports System.Data.Entity
Imports ConsoleApp15

Public Class MyDbContext
    Inherits DbContext

    Public Sub New(ByVal name As String)
        MyBase.New(name)
        Database.SetInitializer(New MyDbInitialiser)
    End Sub

    Public Property Students As DbSet(Of Student)
End Class

Public Class MyDbInitialiser
    Inherits DropCreateDatabaseIfModelChanges(Of MyDbContext)

    Protected Overrides Sub Seed(context As MyDbContext)
        For Each st As Student In CreateStudents()
            context.Students.Add(st)
        Next
        context.SaveChanges()
    End Sub

End Class
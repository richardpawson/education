Imports System.Data.Entity

Public Class MyDbContext
        Inherits DbContext

        Public Sub New(ByVal name As String)
            MyBase.New(name)
            Database.SetInitializer(New DropCreateDatabaseIfModelChanges(Of MyDbContext)())
        End Sub

        Public Property Students As DbSet(Of Student)
End Class
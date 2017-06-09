Imports System.Data.Entity
Imports SalesOrder.Model

Public Class SalesOrderDbContext
    Inherits DbContext

    Public Sub New(dbName As String, initializer As IDatabaseInitializer(Of SalesOrderDbContext))
        MyBase.New(dbName)
        System.Data.Entity.Database.SetInitializer(initializer)
    End Sub

    Public Customers As DbSet(Of Customer)
    Public Orders As DbSet(Of Order)
    Public OrderLines As DbSet(Of OrderLine)
    Public Products As DbSet(Of Product)
    Public Addresses As DbSet(Of Address)

End Class

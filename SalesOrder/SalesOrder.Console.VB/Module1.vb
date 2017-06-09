Imports SalesOrder.DataBase.VB
Imports SalesOrder.SeedData.VB.SalesOrder.SeedData

Module Module1

    Sub Main()

        Dim context = New SalesOrderDbContext("SalesOrders", New SalesOrderDbInitilializer())
        While True
            System.Console.WriteLine("Enter match string")
            Dim match = System.Console.ReadLine()
            Dim results = context.Customers.Where(Function(c) c.Name.Contains(match)).ToList()
            For Each c In results
                System.Console.WriteLine(c.Name)
            Next
        End While
    End Sub

End Module

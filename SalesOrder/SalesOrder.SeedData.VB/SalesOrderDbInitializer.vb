Imports SalesOrder.DataBase
Imports SalesOrder.Model
Imports System
Imports System.Data.Entity
Imports SalesOrder.DataBase.VB

Namespace SalesOrder.SeedData

    Public Class SalesOrderDbInitilializer
        Inherits DropCreateDatabaseAlways(Of SalesOrderDbContext)

        Private context As SalesOrderDbContext

        Protected Overrides Sub Seed(dbContext As SalesOrderDbContext)

            context = dbContext
            Dim ad1 = AddNewAddress("The Cottage", "Lymeswold", "GL24 1XQ")
            Dim ad2 = AddNewAddress("13 Elm Street", "Woking", "GU17 9DD")

            Dim aa = AddNewCustomer("Alison Algol", ad1, ad2)
            Dim ff = AddNewCustomer("Forrest Fortran")
            Dim jj = AddNewCustomer("James Java")
            Dim ss = AddNewCustomer("Smilla Simula")

            Dim apple = AddNewProduct("Apple MacBook", 1595.0)
            Dim dell = AddNewProduct("Dell Inspiron", 1250.5)
            Dim yoga = AddNewProduct("Lenovo Yoga", 1370.95)

            Dim ord1 = AddNewOrder(aa, DateTime.Today, ad1)
            Dim l1 = AddNewOrderLine(ord1, apple, 3)
            Dim l2 = AddNewOrderLine(ord1, dell, 1)
        End Sub

        Private Function AddNewAddress(line1 As String, line2 As String, postCode As String) As Address

            Dim addr = New Address
            With addr
                .Line1 = line1
                .Line2 = line2
                .PostCode = postCode
            End With
            context.Addresses.Add(addr)
            context.SaveChanges()
            Return addr
        End Function

        Private Function AddNewCustomer(name As String, ParamArray addresses As Address()) As Customer

            Dim cus = New Customer()
            cus.Name = name
            context.Customers.Add(cus)
            For Each addr In addresses
                cus.Addresses.Add(addr)

            Next
            context.SaveChanges()
            Return cus
        End Function

        Private Function AddNewProduct(name As String, price As Decimal) As Product

            Dim prod = New Product
            prod.Name = name
            prod.Price = price
            context.Products.Add(prod)
            context.SaveChanges()
            Return prod
        End Function

        Private Function AddNewOrder(cus As Customer, d As DateTime, billing As Address) As Order

            Dim ord = New Order
            With ord
                .Customer = cus
                .OrderDate = d
                .BillingAddress = billing
            End With
            context.Orders.Add(ord)
            context.SaveChanges()
            Return ord
        End Function

        Private Function AddNewOrderLine(ord As Order, product As Product, quantity As Integer) As OrderLine

            Dim line = New OrderLine()
            With line
                .Product = product
                .Quantity = quantity
            End With
            context.OrderLines.Add(line)
            ord.Details.Add(line)
            context.SaveChanges()
            Return line
        End Function

    End Class
End Namespace



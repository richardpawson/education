Namespace SalesOrder.Model

    Public Class Order

        Public Overridable Property Id As Integer

        Public Overridable Property OrderDate As DateTime

        Public Overridable Property Customer As Customer

        Public Overridable Property ShippingAddress As Address

        Public Overridable Property BillingAddress As Address

        Public Overridable Property Details As ICollection(Of OrderLine) = New List(Of OrderLine)()

        Public Overridable Property TotalValue As Integer
    End Class
End Namespace
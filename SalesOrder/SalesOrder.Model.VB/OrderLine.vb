
Namespace SalesOrder.Model
    Public Class OrderLine
        Public Overridable Property Id() As Integer

        Public Overridable Property Product() As Product

        Public Overridable Property Quantity() As Integer
        Public Overridable Property SubTotal() As Integer

    End Class
End Namespace
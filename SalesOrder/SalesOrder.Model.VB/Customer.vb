Namespace SalesOrder.Model
    Public Class Customer

        Public Overridable Property Id As Integer

        Public Overridable Property Name As String

        Public Overridable Property Email As String

        Public Overridable Property Orders As ICollection(Of Order) = New List(Of Order)

        Public Overridable Property Addresses As ICollection(Of Address) = New List(Of Address)

    End Class
End Namespace

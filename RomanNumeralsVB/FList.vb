Public Class FList(Of T)
    Public Sub New()
        IsEmpty = True
    End Sub

    Public Sub New(ByVal head As T, ByVal tail As FList(Of T))
        IsEmpty = False
        Me.Head = head
        Me.Tail = tail
    End Sub

    Public Property IsEmpty As Boolean
    Public Property Head As T
    Public Property Tail As FList(Of T)

    Public Function Count() As Integer
        Return If(IsEmpty, 0, 1 + Tail.Count())
    End Function

    Public Function Skip(ByVal number As Integer) As FList(Of T)
        Return If(number <= 0, Me, If(number = 1, Tail, Tail.Skip(number - 1)))
    End Function

    Public Function Take(ByVal number As Integer) As FList(Of T)
        Return If(number <= 0, FList.Empty(Of T)(), If(number = 1, FList.Cons(Head), FList.Cons(Head, Tail.Take(number - 1))))
    End Function

    Public Overrides Function ToString() As String
        Return If(IsEmpty, "", If(Tail.IsEmpty, Head.ToString(), Head.ToString() + ", " + Tail.ToString()))
    End Function

    Public Overrides Function Equals(ByVal obj As Object) As Boolean
        Return If(Not (TypeOf obj Is FList(Of T)), False, (Me.IsEmpty AndAlso (TryCast(obj, FList(Of T))).IsEmpty) OrElse (Head.Equals((TryCast(obj, FList(Of T))).Head) AndAlso Tail.Equals((TryCast(obj, FList(Of T))).Tail)))
    End Function
End Class

Module FList
        Function Empty(Of T)() As FList(Of T)
            Return New FList(Of T)()
        End Function

        Function Cons(Of T)(ByVal head As T, ByVal tail As FList(Of T)) As FList(Of T)
            Return New FList(Of T)(head, tail)
        End Function

        Function Cons(Of T)(ByVal head As T) As FList(Of T)
            Return New FList(Of T)(head, Empty(Of T)())
        End Function

        Function Cons(Of T)(ParamArray items As T()) As FList(Of T)
            Return If(items.Length = 0, Empty(Of T)(), If(items.Length = 1, Cons(Of T)(items(0)), Cons(items(0), Cons(items.Skip(1).ToArray()))))
        End Function
End Module


Namespace FunctionalLibrary
    Public Module Sorting

        Function LeftHalf(Of T)(list As FList(Of T)) As FList(Of T)
            Return list.Skip(list.Count() / 2)
        End Function

        Function RightHalf(Of T)(list As FList(Of T)) As FList(Of T)
            Return list.Take(list.Count() / 2)
        End Function

        Function MergeSort(Of T)(list As FList(Of T), p As Func(Of T, T, Boolean)) As FList(Of T)
            Return If(list.Count() < 2,
                list,
                Merge(MergeSort(LeftHalf(list), p),
                    MergeSort(RightHalf(list), p),
                    p))
        End Function

        Function Merge(Of T)(a As FList(Of T), b As FList(Of T), p As Func(Of T, T, Boolean)) As FList(Of T)
            Return If(a.IsEmpty,
                b,
                If(b.IsEmpty,
                    a,
                    If(p(a.Head, b.Head),
                    New FList(Of T)(a.Head, Merge(a.Tail, b, p)),
                    New FList(Of T)(b.Head, Merge(a, b.Tail, p)))))
        End Function
    End Module
End Namespace

'=======================================================
'Service provided by Telerik (www.telerik.com)
'Conversion powered by NRefactory.
'Twitter: @telerik
'Facebook: facebook.com/telerik
'=======================================================

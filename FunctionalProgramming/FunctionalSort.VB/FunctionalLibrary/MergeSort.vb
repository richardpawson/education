

Namespace FunctionalLibrary
	Public NotInheritable Class MergeSort
		Private Sub New()
		End Sub
		Public Shared Function Sort(Of T)(list As FList(Of T), greaterThan As Func(Of T, T, Boolean)) As FList(Of T)
			If list.Count() < 2 Then
				Return list
			Else
				Dim half = list.Count() / 2
				Return Merge(Sort(list.Skip(half), greaterThan), Sort(list.Take(half), greaterThan), greaterThan)
			End If
		End Function

		Public Shared Function Merge(Of T)(a As FList(Of T), b As FList(Of T), greaterThan As Func(Of T, T, Boolean)) As FList(Of T)
			If a.IsEmpty Then
				Return b
			ElseIf b.IsEmpty Then
				Return a
			ElseIf greaterThan(a.Head, b.Head) Then
				Return FList.Cons(a.Head, Merge(a.Tail, b, greaterThan))
			Else
				Return FList.Cons(b.Head, Merge(a, b.Tail, greaterThan))
			End If
		End Function

		Public Shared Function Sort(list As FList(Of String), greaterThan As Func(Of String, String, Boolean)) As FList(Of String)
			If list.Count() < 2 Then
				Return list
			Else
				Dim half = list.Count() / 2
				Return Merge(Sort(list.Skip(half), greaterThan), Sort(list.Take(half), greaterThan), greaterThan)
			End If
		End Function

		Public Shared Function Merge(a As FList(Of String), b As FList(Of String), greaterThan As Func(Of String, String, Boolean)) As FList(Of String)
			If a.IsEmpty Then
				Return b
			ElseIf b.IsEmpty Then
				Return a
			ElseIf greaterThan(a.Head, b.Head) Then
				Return FList.Cons(a.Head, Merge(a.Tail, b, greaterThan))
			Else
				Return FList.Cons(b.Head, Merge(a, b.Tail, greaterThan))
			End If
		End Function

		Public Shared Function SortAlphabetical(list As FList(Of String)) As FList(Of String)
			If list.Count() < 2 Then
				Return list
			Else
				Dim half = list.Count() / 2
				Return MergeAlphabetical(SortAlphabetical(list.Skip(half)), SortAlphabetical(list.Take(half)))
			End If
		End Function

		Public Shared Function MergeAlphabetical(a As FList(Of String), b As FList(Of String)) As FList(Of String)
			If a.IsEmpty Then
				Return b
			ElseIf b.IsEmpty Then
				Return a
			ElseIf String.Compare(a.Head, b.Head) < 0 Then
				Return FList.Cons(a.Head, MergeAlphabetical(a.Tail, b))
			Else
				Return FList.Cons(b.Head, MergeAlphabetical(a, b.Tail))
			End If
		End Function
	End Class
End Namespace

'=======================================================
'Service provided by Telerik (www.telerik.com)
'Conversion powered by NRefactory.
'Twitter: @telerik
'Facebook: facebook.com/telerik
'=======================================================

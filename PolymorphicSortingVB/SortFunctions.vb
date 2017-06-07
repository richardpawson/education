
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks

Namespace PolymorphicSorting
	Public NotInheritable Class SortFunctions
		Private Sub New()
		End Sub
		Public Shared Function QuickSort(unsorted As List(Of Object)) As List(Of Object)
			Dim r As New Random()
			Dim less = New List(Of Object)()
			Dim greater = New List(Of Object)()
			If unsorted.Count <= 1 Then
				Return unsorted
			End If
			Dim pos = r.[Next](unsorted.Count)
			Dim pivot = unsorted(pos)
			unsorted.RemoveAt(pos)
            For Each item In unsorted
                If item.IsBefore(pivot) Then
                    less.Add(item)
                Else
                    greater.Add(item)
                End If
            Next
            Dim sorted = New List(Of Object)(less)
			sorted.Add(pivot)
			sorted.AddRange(greater)
			Return sorted
		End Function

		'pseudo-code dynamic language

		'def quickSort(unsorted)
		'    r = new Random
		'    less = new List
		'    greater = new List
		'    if a.Count <= 1 return unsorted
		'    pos = r.Next(unsorted.Count);
		'    pivot = a[pos];
		'    a.RemoveAt(pos);
		'    foreach (item in unsorted)
		'        if item.IsBefore(pivot) then
		'            less.Add(item)
		'        else
		'            greater.Add(item)
		'    }
		'    sorted = less.makeCopy
		'    sorted.Add(pivot)
		'    sorted.AddAll(greater)
		'    return sorted
	End Class
End Namespace

'=======================================================
'Service provided by Telerik (www.telerik.com)
'Conversion powered by NRefactory.
'Twitter: @telerik
'Facebook: facebook.com/telerik
'=======================================================

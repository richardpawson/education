
Imports FunctionalLibrary

Namespace ConsoleUI
	Class Program
        Public Shared Sub Main(args As String())
            Dim list = FList.Cons("Flag", "Nest", "Cup", "Burg", "Yacht", "Next")

            Dim iList = FList.Cons(4, 7, 12, 3, 88, 9,
                2, 7)
            Dim up = Sorting.MergeSort(iList, AddressOf greaterThan)
            Console.WriteLine(up.ToString())
            Dim down = Sorting.MergeSort(iList, AddressOf reverse)
            Console.WriteLine(down.ToString())

            Console.ReadKey()
        End Sub

        Private Shared Function alphabetical(s1 As String, s2 As String) As Boolean
			Return String.Compare(s2, s1) > 0
		End Function

		Private Shared Function reverse(s1 As String, s2 As String) As Boolean
			Return String.Compare(s2, s1) < 0
		End Function

		Private Shared Function length(s1 As String, s2 As String) As Boolean
			Return s2.Length > s1.Length
		End Function

        Private Shared Function greaterThan(i1 As Integer, i2 As Integer) As Boolean
            Return i2 > i1
        End Function

        Private Shared Function reverse(i1 As Integer, i2 As Integer) As Boolean
			Return i1 > i2
		End Function
	End Class
End Namespace

'=======================================================
'Service provided by Telerik (www.telerik.com)
'Conversion powered by NRefactory.
'Twitter: @telerik
'Facebook: facebook.com/telerik
'=======================================================

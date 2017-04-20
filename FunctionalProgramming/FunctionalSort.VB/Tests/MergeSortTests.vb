
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports FunctionalLibrary

Namespace Tests
	<TestClass> _
	Public Class MergeSortTests
		<TestMethod> _
		Public Sub TestSortAlphabeticalHappyCase()
			Dim list = FList.Cons("Flag", "Nest", "Cup", "Burg", "Yatch", "Next")
			Dim sorted = MergeSort.SortAlphabetical(list)
			Dim expected = FList.Cons("Burg", "Cup", "Flag", "Nest", "Next", "Yatch")
			Assert.AreEqual(expected, sorted)
		End Sub

		<TestMethod> _
		Public Sub TestSortAlphabeticalWithDuplicates()
			Dim list = FList.Cons("Flag", "Cup", "Cup", "Burg", "Cup", "Next")
			Dim sorted = MergeSort.SortAlphabetical(list)
			Dim expected = FList.Cons("Burg", "Cup", "Cup", "Cup", "Flag", "Next")
			Assert.AreEqual(expected, sorted)
		End Sub

		<TestMethod> _
		Public Sub TestSortAlphabeticalWithOne()
			Dim list = FList.Cons("Flag")
			Dim sorted = MergeSort.SortAlphabetical(list)
			Dim expected = FList.Cons("Flag")
			Assert.AreEqual(expected, sorted)
		End Sub

		<TestMethod> _
		Public Sub TestSortAlphabeticalEmpty()
			Dim list = FList.Empty(Of String)()
			Dim sorted = MergeSort.SortAlphabetical(list)
			Dim expected = FList.Empty(Of String)()
			Assert.AreEqual(expected, sorted)
		End Sub

		<TestMethod> _
		Public Sub TestSortWithAlphabeticalFunction()
			Dim list = FList.Cons("Flag", "Nest", "Cup", "Burg", "Yatch", "Next")
			Dim sorted = MergeSort.Sort(list, AddressOf alphabetical)
			Dim expected = FList.Cons("Burg", "Cup", "Flag", "Nest", "Next", "Yatch")
			Assert.AreEqual(expected, sorted)
		End Sub

		<TestMethod> _
		Public Sub TestSortWithReverseFunction()
			Dim list = FList.Cons("Flag", "Nest", "Cup", "Burg", "Yatch", "Next")
			Dim sorted = MergeSort.Sort(list, AddressOf reverse)
			Dim expected = FList.Cons("Yatch", "Next", "Nest", "Flag", "Cup", "Burg")
			Assert.AreEqual(expected, sorted)
		End Sub

		<TestMethod> _
		Public Sub TestSortByLengthDecreasing()
			Dim list = FList.Cons("Flag", "Nest", "Cup", "Burg", "Yatch", "Next")
			Dim sorted = MergeSort.Sort(list, AddressOf length)
			Dim expected = FList.Cons("Cup", "Flag", "Nest", "Burg", "Next", "Yatch")
			Assert.AreEqual(expected, sorted)
		End Sub


		<TestMethod> _
		Public Sub TestSortIntegers()
			Dim list = FList.Cons(4, 7, 12, 3, 88, 9, _
				2, 7)
			Dim sorted = MergeSort.Sort(list, AddressOf greaterThan)
			Dim expected = FList.Cons(2, 3, 4, 7, 7, 9, _
				12, 88)
			Assert.AreEqual(expected, sorted)
		End Sub

		<TestMethod> _
		Public Sub TestSortIntegersInReverse()
			Dim list = FList.Cons(4, 7, 12, 3, 88, 9, _
				2, 7)
			Dim sorted = MergeSort.Sort(list, AddressOf reverse)
			Dim expected = FList.Cons(88, 12, 9, 7, 7, 4, _
				3, 2)
			Assert.AreEqual(expected, sorted)
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

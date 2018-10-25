
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports FunctionalLibrary

Namespace Tests
	<TestClass> _
	Public Class MergeSortTests


        <TestMethod>
        Public Sub TestSortWithAlphabeticalFunction()
            Dim list = FList.Cons("Flag", "Nest", "Cup", "Burg", "Yacht", "Next")
            Dim sorted = Sorting.MergeSort(list, AddressOf alphabetical)
            Dim expected = FList.Cons("Burg", "Cup", "Flag", "Nest", "Next", "Yacht")
            Assert.AreEqual(expected, sorted)
        End Sub

        <TestMethod>
        Public Sub TestSortWithReverseFunction()
            Dim list = FList.Cons("Flag", "Nest", "Cup", "Burg", "Yacht", "Next")
            Dim sorted = Sorting.MergeSort(list, AddressOf reverse)
            Dim expected = FList.Cons("Yacht", "Next", "Nest", "Flag", "Cup", "Burg")
            Assert.AreEqual(expected, sorted)
        End Sub

        <TestMethod>
        Public Sub TestSortByLengthDecreasing()
            Dim list = FList.Cons("Flag", "Nest", "Cup", "Burg", "Yacht", "Next")
            Dim sorted = Sorting.MergeSort(list, AddressOf length)
            Dim expected = FList.Cons("Cup", "Flag", "Nest", "Burg", "Next", "Yacht")
            Assert.AreEqual(expected, sorted)
        End Sub

        <TestMethod>
        Public Sub TestSortByLengthDecreasingUsingLambda()

            Dim list = New List(Of String)() From {"Flag", "Nest", "Cup", "Burg", "Yacht", "Next"}
            Dim sorted = list.OrderBy(Function(s) s.Length)

        End Sub

        <TestMethod>
        Public Sub TestSortIntegers()
            Dim list = FList.Cons(4, 7, 12, 3, 88, 9, 2, 7)
            Dim sorted = Sorting.MergeSort(list, AddressOf greaterThan)
            Dim expected = FList.Cons(2, 3, 4, 7, 7, 9, 12, 88)
            Assert.AreEqual(expected, sorted)
        End Sub

        <TestMethod>
        Public Sub TestSortIntegersInReverse()
            Dim list = FList.Cons(4, 7, 12, 3, 88, 9, 2, 7)
            Dim sorted = Sorting.MergeSort(list, AddressOf reverse)
            Dim expected = FList.Cons(88, 12, 9, 7, 7, 4, 3, 2)
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

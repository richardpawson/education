
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks

Namespace PolymorphicSorting
	Class Program
        Public Shared Sub Main(args As String())
            Dim teams = New List(Of Object)() From {
                New SportsTeam("Newcastle", 4),
                New SportsTeam("Reading", 0),
                New SportsTeam("Cardiff", 1)
            }
            Dim sortedTeams = SortFunctions.QuickSort(teams)
            Print(sortedTeams)

            Dim students = New List(Of Object)() From {
                New Student("Charlotte"),
                New Student("Charlie")
            }
            Dim sortedStudents = SortFunctions.QuickSort(students)
            Print(sortedStudents)

            Console.ReadKey()
        End Sub

        Private Shared Sub Print(list As List(Of Object))
            For Each obj In list
                Console.WriteLine(obj.ToString())
            Next
            Console.WriteLine()
		End Sub

	End Class
End Namespace

'=======================================================
'Service provided by Telerik (www.telerik.com)
'Conversion powered by NRefactory.
'Twitter: @telerik
'Facebook: facebook.com/telerik
'=======================================================

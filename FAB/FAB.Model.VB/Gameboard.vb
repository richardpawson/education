
Imports System.Collections.Immutable

Namespace FAB
	Public Class GameBoard
		Public ReadOnly Size As Integer
		Public ReadOnly Misses As ImmutableList(Of Location)
		Public ReadOnly Ships As ImmutableArray(Of Ship)
		Public ReadOnly Messages As String

		Public Sub New(size__1 As Integer, ships__2 As ImmutableArray(Of Ship), messages__3 As String, misses__4 As ImmutableList(Of Location))
			Size = size__1
			Messages = messages__3
			Ships = ships__2
			Misses = misses__4
		End Sub
	End Class
End Namespace

'=======================================================
'Service provided by Telerik (www.telerik.com)
'Conversion powered by NRefactory.
'Twitter: @telerik
'Facebook: facebook.com/telerik
'=======================================================

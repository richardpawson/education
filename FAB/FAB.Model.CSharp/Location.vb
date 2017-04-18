
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks

Namespace FAB
	Public Structure Location
		Public ReadOnly Col As Integer
		Public ReadOnly Row As Integer

		Public Sub New(col__1 As Integer, row__2 As Integer)
			Col = col__1
			Row = row__2
		End Sub

		Public Function Add(colInc As Integer, rowInc As Integer) As Location
			Return New Location(Col + colInc, Row + rowInc)
		End Function

	End Structure
End Namespace

'=======================================================
'Service provided by Telerik (www.telerik.com)
'Conversion powered by NRefactory.
'Twitter: @telerik
'Facebook: facebook.com/telerik
'=======================================================

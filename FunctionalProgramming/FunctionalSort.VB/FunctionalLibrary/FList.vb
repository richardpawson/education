
Imports System.Linq

Namespace FunctionalLibrary
	Public Class FList(Of T)
		' Creates a new list that is empty
		Public Sub New()
			IsEmpty = True
		End Sub
		' Creates a new list containe value and a reference to tail
		Public Sub New(head__1 As T, tail__2 As FList(Of T))
			IsEmpty = False
			Head = head__1
			Tail = tail__2
		End Sub
		' Is the list empty?
		Public Property IsEmpty() As Boolean
			Get
				Return m_IsEmpty
			End Get
			Private Set
				m_IsEmpty = Value
			End Set
		End Property
		Private m_IsEmpty As Boolean
		' Properties valid for a non-empty list
		Public Property Head() As T
			Get
				Return m_Head
			End Get
			Private Set
				m_Head = Value
			End Set
		End Property
		Private m_Head As T
		Public Property Tail() As FList(Of T)
			Get
				Return m_Tail
			End Get
			Private Set
				m_Tail = Value
			End Set
		End Property
		Private m_Tail As FList(Of T)

		Public Function Count() As Integer
			Return If(IsEmpty, 0, 1 + Tail.Count())
		End Function

		Public Function Skip(number As Integer) As FList(Of T)
			If number <= 0 Then
				Return Me
			ElseIf number = 1 Then
				Return Tail
			Else
				Return Tail.Skip(number - 1)
			End If
		End Function

		Public Function Take(number As Integer) As FList(Of T)
			If number <= 0 Then
				Return FList.Empty(Of T)()
			ElseIf number = 1 Then
				Return FList.Cons(Head)
			Else
				Return FList.Cons(Head, Tail.Take(number - 1))
			End If
		End Function

		Public Overrides Function ToString() As String
			If IsEmpty Then
				Return ""
			ElseIf Tail.IsEmpty Then
				Return Head.ToString()
			Else
                Return Head.ToString() + ", " + Tail.ToString()
            End If
		End Function

		Public Overrides Function Equals(obj As Object) As Boolean
			If Not (TypeOf obj Is FList(Of T)) Then
				Return False
			Else
				Dim list = TryCast(obj, FList(Of T))
				Return (Me.IsEmpty AndAlso list.IsEmpty) OrElse (Head.Equals(list.Head) AndAlso Tail.Equals(list.Tail))
			End If
		End Function
	End Class

	' Static class that provides nicer syntax for creating lists
	Public NotInheritable Class FList
		Private Sub New()
		End Sub
		Public Shared Function Empty(Of T)() As FList(Of T)
			Return New FList(Of T)()
		End Function
		Public Shared Function Cons(Of T)(head As T, tail As FList(Of T)) As FList(Of T)
			Return New FList(Of T)(head, tail)
		End Function
		Public Shared Function Cons(Of T)(head As T) As FList(Of T)
			Return New FList(Of T)(head, Empty(Of T)())
		End Function

		Public Shared Function Cons(Of T)(ParamArray items As T()) As FList(Of T)
			If items.Length = 0 Then
				Return Empty(Of T)()
			ElseIf items.Length = 1 Then
				Return Cons(Of T)(items(0))
			Else
				Return Cons(items(0), Cons(items.Skip(1).ToArray()))
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


Namespace PolymorphicSorting
	Public Class Student
		Public Sub New(name__1 As String)
			Name = name__1
		End Sub

		Public Property Name() As String
			Get
				Return m_Name
			End Get
			Set
				m_Name = Value
			End Set
		End Property
		Private m_Name As String

		Public Overrides Function ToString() As String
			Return Name
		End Function
	End Class
End Namespace

'=======================================================
'Service provided by Telerik (www.telerik.com)
'Conversion powered by NRefactory.
'Twitter: @telerik
'Facebook: facebook.com/telerik
'=======================================================


Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks

Namespace PolymorphicSorting
	Public Class SportsTeam
		Public Sub New(name__1 As String, netWins As Integer)
			Name = name__1
			NetWinsThisSeason = netWins
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

		Public Property NetWinsThisSeason() As Integer
			Get
				Return m_NetWinsThisSeason
			End Get
			Set
				m_NetWinsThisSeason = Value
			End Set
		End Property
		Private m_NetWinsThisSeason As Integer

		Public Function IsBefore(other As SportsTeam) As Boolean
			Return Me.NetWinsThisSeason > other.NetWinsThisSeason
		End Function

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

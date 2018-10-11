Public Class Student
    Public Property StudentID As Integer
    Public Property FullName As String
    Public Property Sex As Sex
    Public Property GCSEGrade As Integer

    Public Sub New(ByVal name As String, ByVal id As Integer, ByVal sx As Sex, ByVal grade As Integer)
        StudentID = id
        FullName = name
        Sex = sx
        GCSEGrade = grade
    End Sub

    Public Sub New()
    End Sub

    Public Function Summary() As String
        Return StudentID & " " & FullName
    End Function
End Class

Public Enum Sex
    Male
    Female
End Enum

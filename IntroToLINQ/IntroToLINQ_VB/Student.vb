Public Class Student
    Public Property StudentID As Integer
    Public Property FullName As String
    Public Property Year As YearGroup
    Public Property GCSEGrade As Integer

    Public Sub New(ByVal name As String, ByVal id As Integer, ByVal yg As YearGroup, ByVal grade As Integer)
        StudentID = id
        FullName = name
        Year = yg
        GCSEGrade = grade
    End Sub

    Public Sub New()
    End Sub

    Public Overrides Function ToString() As String
        Return StudentID & " " & FullName
    End Function
End Class

Public Enum YearGroup
    U6
    L6
End Enum

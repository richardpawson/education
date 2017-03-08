
Imports System.Text

Namespace TechnicalServices
	'Implementation of ILogger with no actual UI. It captures the messages written, and allows
	'them to be read back programmatically via the ReadAndResetLog() method. Useful
	'for testing, or for use within another non-console UI.
	Public Class ReadableLogger
		Implements ILogger
		Private log As New StringBuilder()
		Private Logging As Boolean
		Public Sub New()
			StartLogging()
		End Sub

        Public Function ReadAndResetLog() As String
            Dim output = log.ToString()
            log = New StringBuilder()
            Return output
        End Function

        Public Sub Write(text As String) Implements ILogger.Write
            If Logging Then
                log.Append(text)
            End If
        End Sub
        Public Sub WriteLine(Optional text As String = Nothing) Implements ILogger.WriteLine
            If Logging Then
                log.Append(text)
            End If
        End Sub
        Public Sub PageBreak() Implements ILogger.PageBreak
            'does nothing at present
        End Sub

        Public Sub StartLogging() Implements ILogger.StartLogging
            Logging = True
        End Sub

        Public Sub StopLogging() Implements ILogger.StopLogging
            Logging = False
        End Sub
    End Class
End Namespace

'=======================================================
'Service provided by Telerik (www.telerik.com)
'Conversion powered by NRefactory.
'Twitter: @telerik
'Facebook: facebook.com/telerik
'=======================================================

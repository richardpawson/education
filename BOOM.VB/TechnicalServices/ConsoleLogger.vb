

Namespace TechnicalServices
	Public Class ConsoleLogger
		Implements ILogger
		Private Logging As Boolean

        Public Sub Write(text As String) Implements ILogger.Write
            If Logging Then
                Console.Write(text)
            End If
        End Sub
        Public Sub WriteLine(Optional text As String = Nothing) Implements ILogger.WriteLine
            If Logging Then
                Console.WriteLine(text)
            End If
        End Sub
        Public Sub PageBreak() Implements ILogger.PageBreak
            If Logging Then
                Console.ReadKey()
            End If
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

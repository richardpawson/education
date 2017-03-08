

Namespace TechnicalServices
	Public Interface ILogger
		Sub Write(text As String)

		Sub WriteLine(Optional text As String = Nothing)

		Sub PageBreak()

		Sub StartLogging()

		Sub StopLogging()
	End Interface
End Namespace

'=======================================================
'Service provided by Telerik (www.telerik.com)
'Conversion powered by NRefactory.
'Twitter: @telerik
'Facebook: facebook.com/telerik
'=======================================================

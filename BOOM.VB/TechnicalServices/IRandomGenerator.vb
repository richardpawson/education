
Namespace TechnicalServices
	Public Interface IRandomGenerator
		'Generates next random number within specified range. Note that
		'minValue is inclusive; maxValue is exclusive.
		Function [Next](minValue As Integer, maxValue As Integer) As Integer
	End Interface
End Namespace

'=======================================================
'Service provided by Telerik (www.telerik.com)
'Conversion powered by NRefactory.
'Twitter: @telerik
'Facebook: facebook.com/telerik
'=======================================================

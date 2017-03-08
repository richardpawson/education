
Imports System.Windows.Forms

Namespace Boom.WinFormsUI
	NotInheritable Class Program
		Private Sub New()
		End Sub
		''' <summary>
		''' The main entry point for the application.
		''' </summary>
		<STAThread> _
		Private Shared Sub Main()
			Application.EnableVisualStyles()
			Application.SetCompatibleTextRenderingDefault(False)
			Application.Run(New Form1())
		End Sub
	End Class
End Namespace

'=======================================================
'Service provided by Telerik (www.telerik.com)
'Conversion powered by NRefactory.
'Twitter: @telerik
'Facebook: facebook.com/telerik
'=======================================================

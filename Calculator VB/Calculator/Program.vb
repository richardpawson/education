
Imports System
Imports System.Windows.Forms

Namespace Calculator

    Module Program

        <STAThread>
        Private Sub Main()
            Application.EnableVisualStyles()
            Application.SetCompatibleTextRenderingDefault(False)
            Application.Run(New CalculatorRPN())
        End Sub
    End Module
End Namespace

'=======================================================
'Service provided by Telerik (www.telerik.com)
'Conversion powered by Refactoring Essentials.
'Twitter: @telerik
'Facebook: facebook.com/telerik
'=======================================================

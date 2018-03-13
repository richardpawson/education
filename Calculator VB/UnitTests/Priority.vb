
Imports Calculator
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports System

Namespace UnitTests

    <TestClass>
    Public Class Priority

        <TestMethod>
        Public Sub Plus()
            Assert.AreEqual(1, Core.Priority("+"c))
        End Sub

        <TestMethod>
        Public Sub Minus()
            Assert.AreEqual(1, Core.Priority("-"c))
        End Sub

        <TestMethod>
        Public Sub Times()
            Assert.AreEqual(2, Core.Priority("*"c))
        End Sub

        <TestMethod>
        Public Sub Divide()
            Assert.AreEqual(2, Core.Priority("/"c))
        End Sub

        <TestMethod>
        Public Sub Bracket()
            Assert.AreEqual(0, Core.Priority("("c))
        End Sub

        <TestMethod>
        Public Sub Unrecognised()
            Assert.AreEqual(0, Core.Priority("%"c))
        End Sub
    End Class
End Namespace

'=======================================================
'Service provided by Telerik (www.telerik.com)
'Conversion powered by Refactoring Essentials.
'Twitter: @telerik
'Facebook: facebook.com/telerik
'=======================================================

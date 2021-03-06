
Imports System
Imports System.Collections.Generic
Imports Calculator
Imports Microsoft.VisualStudio.TestTools.UnitTesting

Namespace UnitTests

    <TestClass>
    Public Class EvaluateAsRPN

        <TestMethod>
        Public Sub TestMethod1()
            Dim tokens = New List(Of Object)() From {3.1, 4.25, "+"c}
            Assert.AreEqual(7.35, Core.EvaluateAsRPN(tokens))
        End Sub

        <TestMethod>
        Public Sub TestMethod2()
            Dim tokens = New List(Of Object)() From {
            9.0R, 4.6, "-"c}
            Assert.AreEqual(4.4, Core.EvaluateAsRPN(tokens))
        End Sub

        <TestMethod>
        Public Sub TestMethod3()
            Dim tokens = New List(Of Object)() From {
            4.0R,
            9.0R, "-"c}
            Assert.AreEqual(-5.0R, Core.EvaluateAsRPN(tokens))
        End Sub

        <TestMethod>
        Public Sub TestMethod4()
            Dim tokens = New List(Of Object)() From {0.5, 0.25, "*"c}
            Assert.AreEqual(0.125, Core.EvaluateAsRPN(tokens))
        End Sub

        <TestMethod>
        Public Sub TestMethod5()
            Dim tokens = New List(Of Object)() From {
            3.0R,
            4.0R, "+"c,
            5.0R,
            6.0R, "+"c, "*"c}
            Assert.AreEqual(77.0R, Core.EvaluateAsRPN(tokens))
        End Sub

        <TestMethod>
        Public Sub TestMethod6()
            Dim tokens = New List(Of Object)() From {
            3.0R,
            4.0R, "+"c,
            5.0R,
            6.0R, "*"c, "+"c}
            Assert.AreEqual(37.0R, Core.EvaluateAsRPN(tokens))
        End Sub

        <TestMethod>
        Public Sub TestMethod7()
            Dim tokens = New List(Of Object)() From {3R, 4R, 5R, 6R, "-"c, "*"c, "/"c}
            Assert.AreEqual(-0.75, Core.EvaluateAsRPN(tokens))
        End Sub

        <TestMethod>
        Public Sub InvalidTokenIgnored()
            Dim tokens = New List(Of Object)() From {3R, 4R, "%"c}
            Assert.AreEqual(4.0R, Core.EvaluateAsRPN(tokens))
        End Sub

        <TestMethod>
        Public Sub TooManyOperators()
            Dim tokens = New List(Of Object)() From {
            3.0R,
            4.0R, "+"c, "+"c}
            Try
                Core.EvaluateAsRPN(tokens)
                Assert.Fail("Should not get to here")
            Catch e As Exception
                Assert.AreEqual("Stack empty.", e.Message)
            End Try
        End Sub
    End Class
End Namespace

'=======================================================
'Service provided by Telerik (www.telerik.com)
'Conversion powered by Refactoring Essentials.
'Twitter: @telerik
'Facebook: facebook.com/telerik
'=======================================================


Imports System
Imports System.Collections.Generic
Imports Calculator
Imports Microsoft.VisualStudio.TestTools.UnitTesting

Namespace UnitTests

    <TestClass>
    Public Class ConvertInfixToPostFix

        <TestMethod>
        Public Sub TestMethod1()
            Dim infix = New List(Of Object)() From {3.1, "+"c, 4.25}
            Dim postfix = New List(Of Object)() From {3.1, 4.25, "+"c}
            CollectionAssert.AreEqual(postfix, Core.ConvertInfixToPostfix(infix))
        End Sub

        <TestMethod>
        Public Sub TestMethod2()
            Dim infix = New List(Of Object)() From {9, "-"c, 4.6}
            Dim postfix = New List(Of Object)() From {9, 4.6, "-"c}
            CollectionAssert.AreEqual(postfix, Core.ConvertInfixToPostfix(infix))
        End Sub

        <TestMethod>
        Public Sub TestMethod3()
            Dim infix = New List(Of Object)() From {4, "-"c, 9}
            Dim postfix = New List(Of Object)() From {4, 9, "-"c}
            CollectionAssert.AreEqual(postfix, Core.ConvertInfixToPostfix(infix))
        End Sub

        <TestMethod>
        Public Sub TestMethod4()
            Dim infix = New List(Of Object)() From {0.5, "*"c, 0.25}
            Dim postfix = New List(Of Object)() From {0.5, 0.25, "*"c}
            CollectionAssert.AreEqual(postfix, Core.ConvertInfixToPostfix(infix))
        End Sub

        <TestMethod>
        Public Sub TestMethod5()
            Dim infix = New List(Of Object)() From {3, "+"c, 4, "*"c, 5}
            Dim postfix = New List(Of Object)() From {3, 4, 5, "*"c, "+"c}
            CollectionAssert.AreEqual(postfix, Core.ConvertInfixToPostfix(infix))
        End Sub

        <TestMethod>
        Public Sub TestMethod6()
            Dim infix = New List(Of Object)() From {3, "*"c, 4, "+"c, 5}
            Dim postfix = New List(Of Object)() From {3, 4, "*"c, 5, "+"c}
            CollectionAssert.AreEqual(postfix, Core.ConvertInfixToPostfix(infix))
        End Sub

        <TestMethod>
        Public Sub TestMethod7()
            Dim infix = New List(Of Object)() From {"("c, 3, "+"c, 4, ")"c, "*"c, 5}
            Dim postfix = New List(Of Object)() From {3, 4, "+"c, 5, "*"c}
            CollectionAssert.AreEqual(postfix, Core.ConvertInfixToPostfix(infix))
        End Sub

        <TestMethod>
        Public Sub TestMethod8()
            Dim infix = New List(Of Object)() From {"("c, 3, "+"c, 4, ")"c, "*"c, "("c, 5, "+"c, 6, ")"c}
            Dim postfix = New List(Of Object)() From {3, 4, "+"c, 5, 6, "+"c, "*"c}
            CollectionAssert.AreEqual(postfix, Core.ConvertInfixToPostfix(infix))
        End Sub

        <TestMethod>
        Public Sub TestMethod9()
            Dim infix = New List(Of Object)() From {3, "+"c, 4, "+"c, 5, "*"c, 6}
            Dim postfix = New List(Of Object)() From {3, 4, "+"c, 5, 6, "*"c, "+"c}
            CollectionAssert.AreEqual(postfix, Core.ConvertInfixToPostfix(infix))
        End Sub

        <TestMethod>
        Public Sub TestMethod10()
            Dim infix = New List(Of Object)() From {3, "/"c, 4, "*"c, "("c, 5, "-"c, 6, ")"c}
            Dim postfix = New List(Of Object)() From {3, 4, "/"c, 5, 6, "-"c, "*"c}
            CollectionAssert.AreEqual(postfix, Core.ConvertInfixToPostfix(infix))
        End Sub

        <TestMethod>
        Public Sub TestMethod11()
            Dim infix = New List(Of Object)() From {4, "*"c, "("c, 5, "-"c, 6, "*"c, 7, ")"c}
            Dim postfix = New List(Of Object)() From {4, 5, 6, 7, "*"c, "-"c, "*"c}
            CollectionAssert.AreEqual(postfix, Core.ConvertInfixToPostfix(infix))
        End Sub

        <TestMethod>
        Public Sub TestMethod12()
            Dim infix = New List(Of Object)() From {3, "+"c, 4, "*"c, "("c, 5, "-"c, 6, "*"c, 7, ")"c}
            Dim postfix = New List(Of Object)() From {3, 4, 5, 6, 7, "*"c, "-"c, "*"c, "+"c}
            CollectionAssert.AreEqual(postfix, Core.ConvertInfixToPostfix(infix))
        End Sub
    End Class
End Namespace

'=======================================================
'Service provided by Telerik (www.telerik.com)
'Conversion powered by Refactoring Essentials.
'Twitter: @telerik
'Facebook: facebook.com/telerik
'=======================================================

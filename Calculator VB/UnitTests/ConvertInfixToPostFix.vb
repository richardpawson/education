Imports Calculator

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
            Dim infix = New List(Of Object)() From {
            9.0R, "-"c, 4.6}
            Dim postfix = New List(Of Object)() From {9.0R, 4.6, "-"c}
            CollectionAssert.AreEqual(postfix, Core.ConvertInfixToPostfix(infix))
        End Sub

        <TestMethod>
        Public Sub TestMethod3()
            Dim infix = New List(Of Object)() From {
            4.0R, "-"c,
            9.0R
            }
            Dim postfix = New List(Of Object)() From {
            4.0R,
            9.0R, "-"c}
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
            Dim infix = New List(Of Object)() From {
            3.0R, "+"c,
            4.0R, "*"c,
            5.0R
            }
            Dim postfix = New List(Of Object)() From {
            3.0R,
            4.0R,
            5.0R, "*"c, "+"c}
            CollectionAssert.AreEqual(postfix, Core.ConvertInfixToPostfix(infix))
        End Sub

        <TestMethod>
        Public Sub TestMethod6()
            Dim infix = New List(Of Object)() From {
            3.0R, "*"c,
            4.0R, "+"c,
            5.0R
            }
            Dim postfix = New List(Of Object)() From {
            3.0R,
            4.0R, "*"c,
            5.0R, "+"c}
            CollectionAssert.AreEqual(postfix, Core.ConvertInfixToPostfix(infix))
        End Sub

        <TestMethod>
        Public Sub TestMethod7()
            Dim infix = New List(Of Object)() From {"("c,
            3.0R, "+"c,
            4.0R, ")"c, "*"c,
            5.0R
            }
            Dim postfix = New List(Of Object)() From {
            3.0R,
            4.0R, "+"c,
            5.0R, "*"c}
            CollectionAssert.AreEqual(postfix, Core.ConvertInfixToPostfix(infix))
        End Sub

        <TestMethod>
        Public Sub TestMethod8()
            Dim infix = New List(Of Object)() From {"("c,
            3.0R, "+"c,
            4.0R, ")"c, "*"c, "("c,
            5.0R, "+"c,
            6.0R, ")"c}
            Dim postfix = New List(Of Object)() From {
            3.0R,
            4.0R, "+"c,
            5.0R,
            6.0R, "+"c, "*"c}
            CollectionAssert.AreEqual(postfix, Core.ConvertInfixToPostfix(infix))
        End Sub

        <TestMethod>
        Public Sub TestMethod9()
            Dim infix = New List(Of Object)() From {
            3.0R, "+"c,
            4.0R, "+"c,
            5.0R, "*"c,
            6.0R
            }
            Dim postfix = New List(Of Object)() From {
            3.0R,
            4.0R, "+"c,
            5.0R,
            6.0R, "*"c, "+"c}
            CollectionAssert.AreEqual(postfix, Core.ConvertInfixToPostfix(infix))
        End Sub

        <TestMethod>
        Public Sub TestMethod10()
            Dim infix = New List(Of Object)() From {
            3.0R, "/"c,
            4.0R, "*"c, "("c,
            5.0R, "-"c,
            6.0R, ")"c}
            Dim postfix = New List(Of Object)() From {
            3.0R,
            4.0R, "/"c,
            5.0R,
            6.0R, "-"c, "*"c}
            CollectionAssert.AreEqual(postfix, Core.ConvertInfixToPostfix(infix))
        End Sub

        <TestMethod>
        Public Sub TestMethod11()
            Dim infix = New List(Of Object)() From {
            4.0R, "*"c, "("c,
            5.0R, "-"c,
            6.0R, "*"c,
            7.0R, ")"c}
            Dim postfix = New List(Of Object)() From {
            4.0R,
            5.0R,
            6.0R,
            7.0R, "*"c, "-"c, "*"c}
            CollectionAssert.AreEqual(postfix, Core.ConvertInfixToPostfix(infix))
        End Sub

        <TestMethod>
        Public Sub TestMethod12()
            Dim infix = New List(Of Object)() From {
            3.0R, "+"c,
            4.0R, "*"c, "("c,
            5.0R, "-"c,
            6.0R, "*"c,
            7.0R, ")"c}
            Dim postfix = New List(Of Object)() From {
            3.0R,
            4.0R,
            5.0R,
            6.0R,
            7.0R, "*"c, "-"c, "*"c, "+"c}
            CollectionAssert.AreEqual(postfix, Core.ConvertInfixToPostfix(infix))
        End Sub
    End Class
End Namespace
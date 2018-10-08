
<TestClass()> Public Class FListTests

    <TestMethod()>
    Public Sub Empty()
        Dim fl = New FList(Of Integer)()
        Assert.IsTrue(fl.IsEmpty())
    End Sub

    <TestMethod()>
    Public Sub Empty2()
        Dim fl = FList.Empty(Of Integer)()
        Assert.IsTrue(fl.IsEmpty())
    End Sub

    <TestMethod()>
    Public Sub OneElement()
        Dim fl = Cons(3)
        Assert.IsFalse(fl.IsEmpty())
        Assert.AreEqual(3, fl.Head)
        Assert.IsTrue(fl.Tail.IsEmpty())
    End Sub

    <TestMethod()>
    Public Sub TwoElements()
        Dim fl = Cons(3, 7)
        Assert.IsFalse(fl.IsEmpty())
        Assert.AreEqual(3, fl.Head)

        Dim t = fl.Tail
        Assert.IsFalse(t.IsEmpty())
        Assert.AreEqual(7, t.Head)
        Assert.IsTrue(t.Tail.IsEmpty())
    End Sub

End Class
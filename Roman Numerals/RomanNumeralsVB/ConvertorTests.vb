<TestClass>
Public Class Tests
    <TestMethod>
    Public Sub Test___1()
        Assert.AreEqual("I", Convertor.AsRomanNumeral(1))
    End Sub

    <TestMethod>
    Public Sub Test___2()
        Assert.AreEqual("II", Convertor.AsRomanNumeral(2))
    End Sub

    <TestMethod>
    Public Sub Test___3()
        Assert.AreEqual("III", Convertor.AsRomanNumeral(3))
    End Sub

    <TestMethod>
    Public Sub Test___4()
        Assert.AreEqual("IV", Convertor.AsRomanNumeral(4))
    End Sub

    <TestMethod>
    Public Sub Test___5()
        Assert.AreEqual("V", Convertor.AsRomanNumeral(5))
    End Sub

    <TestMethod>
    Public Sub Test___6()
        Assert.AreEqual("VI", Convertor.AsRomanNumeral(6))
    End Sub

    <TestMethod>
    Public Sub Test___7()
        Assert.AreEqual("VII", Convertor.AsRomanNumeral(7))
    End Sub

    <TestMethod>
    Public Sub Test___8()
        Assert.AreEqual("VIII", Convertor.AsRomanNumeral(8))
    End Sub

    <TestMethod>
    Public Sub Test___9()
        Assert.AreEqual("IX", Convertor.AsRomanNumeral(9))
    End Sub

    <TestMethod>
    Public Sub Test__10()
        Assert.AreEqual("X", Convertor.AsRomanNumeral(10))
    End Sub

    <TestMethod>
    Public Sub Test__11()
        Assert.AreEqual("XI", Convertor.AsRomanNumeral(11))
    End Sub

    <TestMethod>
    Public Sub Test__14()
        Assert.AreEqual("XIV", Convertor.AsRomanNumeral(14))
    End Sub

    <TestMethod>
    Public Sub Test__15()
        Assert.AreEqual("XV", Convertor.AsRomanNumeral(15))
    End Sub

    <TestMethod>
    Public Sub Test__17()
        Assert.AreEqual("XVII", Convertor.AsRomanNumeral(17))
    End Sub

    <TestMethod>
    Public Sub Test__19()
        Assert.AreEqual("XIX", Convertor.AsRomanNumeral(19))
    End Sub

    <TestMethod>
    Public Sub Test__20()
        Assert.AreEqual("XX", Convertor.AsRomanNumeral(20))
    End Sub

    <TestMethod>
    Public Sub Test__21()
        Assert.AreEqual("XXI", Convertor.AsRomanNumeral(21))
    End Sub

    <TestMethod>
    Public Sub Test__25()
        Assert.AreEqual("XXV", Convertor.AsRomanNumeral(25))
    End Sub

    <TestMethod>
    Public Sub Test__28()
        Assert.AreEqual("XXVIII", Convertor.AsRomanNumeral(28))
    End Sub

    <TestMethod>
    Public Sub Test__29()
        Assert.AreEqual("XXIX", Convertor.AsRomanNumeral(29))
    End Sub

    <TestMethod>
    Public Sub Test__30()
        Assert.AreEqual("XXX", Convertor.AsRomanNumeral(30))
    End Sub

    <TestMethod>
    Public Sub Test__37()
        Assert.AreEqual("XXXVII", Convertor.AsRomanNumeral(37))
    End Sub

    <TestMethod>
    Public Sub Test__41()
        Assert.AreEqual("XLI", Convertor.AsRomanNumeral(41))
    End Sub

    <TestMethod>
    Public Sub Test__50()
        Assert.AreEqual("L", Convertor.AsRomanNumeral(50))
    End Sub

    <TestMethod>
    Public Sub Test__54()
        Assert.AreEqual("LIV", Convertor.AsRomanNumeral(54))
    End Sub

    <TestMethod>
    Public Sub Test__79()
        Assert.AreEqual("LXXIX", Convertor.AsRomanNumeral(79))
    End Sub

    <TestMethod>
    Public Sub Test__95()
        Assert.AreEqual("XCV", Convertor.AsRomanNumeral(95))
    End Sub

    <TestMethod>
    Public Sub Test_333()
        Assert.AreEqual("CCCXXXIII", Convertor.AsRomanNumeral(333))
    End Sub

    <TestMethod>
    Public Sub Test_444()
        Assert.AreEqual("CDXLIV", Convertor.AsRomanNumeral(444))
    End Sub

    <TestMethod>
    Public Sub Test_555()
        Assert.AreEqual("DLV", Convertor.AsRomanNumeral(555))
    End Sub

    <TestMethod>
    Public Sub Test_666()
        Assert.AreEqual("DCLXVI", Convertor.AsRomanNumeral(666))
    End Sub

    <TestMethod>
    Public Sub Test_999()
        Assert.AreEqual("CMXCIX", Convertor.AsRomanNumeral(999))
    End Sub

    <TestMethod>
    Public Sub Test1066()
        Assert.AreEqual("MLXVI", Convertor.AsRomanNumeral(1066))
    End Sub

    <TestMethod>
    Public Sub Test1789()
        Assert.AreEqual("MDCCLXXXIX", Convertor.AsRomanNumeral(1789))
    End Sub

    <TestMethod>
    Public Sub Test1999()
        Assert.AreEqual("MCMXCIX", Convertor.AsRomanNumeral(1999))
    End Sub

    <TestMethod>
    Public Sub Test2017()
        Assert.AreEqual("MMXVII", Convertor.AsRomanNumeral(2017))
    End Sub
End Class

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CSharpRomanNumerals
{
    [TestClass]
    public class Tests
    {
        [TestMethod]
        public void Test___1()
        {
            Assert.AreEqual("I", Convertor.AsRomanNumeral(1));
        }

        [TestMethod]
        public void Test___2()
        {
            Assert.AreEqual("II", Convertor.AsRomanNumeral(2));
        }

        [TestMethod]
        public void Test___3()
        {
            Assert.AreEqual("III", Convertor.AsRomanNumeral(3));
        }

        [TestMethod]
        public void Test___4()
        {
            Assert.AreEqual("IV", Convertor.AsRomanNumeral(4));
        }

        [TestMethod]
        public void Test___5()
        {
            Assert.AreEqual("V", Convertor.AsRomanNumeral(5));
        }
        [TestMethod]
        public void Test___6()
        {
            Assert.AreEqual("VI", Convertor.AsRomanNumeral(6));
        }
        [TestMethod]
        public void Test___7()
        {
            Assert.AreEqual("VII", Convertor.AsRomanNumeral(7));
        }
        [TestMethod]
        public void Test___8()
        {
            Assert.AreEqual("VIII", Convertor.AsRomanNumeral(8));
        }
        [TestMethod]
        public void Test___9()
        {
            Assert.AreEqual("IX", Convertor.AsRomanNumeral(9));
        }

        [TestMethod]
        public void Test__10()
        {
            Assert.AreEqual("X", Convertor.AsRomanNumeral(10));
        }
        [TestMethod]
        public void Test__11()
        {
            Assert.AreEqual("XI", Convertor.AsRomanNumeral(11));
        }

        [TestMethod]
        public void Test__14()
        {
            Assert.AreEqual("XIV", Convertor.AsRomanNumeral(14));
        }

        [TestMethod]
        public void Test__15()
        {
            Assert.AreEqual("XV", Convertor.AsRomanNumeral(15));
        }

        [TestMethod]
        public void Test__17()
        {
            Assert.AreEqual("XVII", Convertor.AsRomanNumeral(17));
        }

        [TestMethod]
        public void Test__19()
        {
            Assert.AreEqual("XIX", Convertor.AsRomanNumeral(19));
        }

        [TestMethod]
        public void Test__20()
        {
            Assert.AreEqual("XX", Convertor.AsRomanNumeral(20));
        }

        [TestMethod]
        public void Test__21()
        {
            Assert.AreEqual("XXI", Convertor.AsRomanNumeral(21));
        }

        [TestMethod]
        public void Test__25()
        {
            Assert.AreEqual("XXV", Convertor.AsRomanNumeral(25));
        }

        [TestMethod]
        public void Test__28()
        {
            Assert.AreEqual("XXVIII", Convertor.AsRomanNumeral(28));
        }
        [TestMethod]
        public void Test__29()
        {
            Assert.AreEqual("XXIX", Convertor.AsRomanNumeral(29));
        }

        [TestMethod]
        public void Test__30()
        {
            Assert.AreEqual("XXX", Convertor.AsRomanNumeral(30));
        }

        [TestMethod]
        public void Test__37()
        {
            Assert.AreEqual("XXXVII", Convertor.AsRomanNumeral(37));
        }

        [TestMethod]
        public void Test__41()
        {
            Assert.AreEqual("XLI", Convertor.AsRomanNumeral(41));
        }

        [TestMethod]
        public void Test__50()
        {
            Assert.AreEqual("L", Convertor.AsRomanNumeral(50));
        }
        [TestMethod]
        public void Test__54()
        {
            Assert.AreEqual("LIV", Convertor.AsRomanNumeral(54));
        }
        [TestMethod]
        public void Test__79()
        {
            Assert.AreEqual("LXXIX", Convertor.AsRomanNumeral(79));
        }
        [TestMethod]
        public void Test__95()
        {
            Assert.AreEqual("XCV", Convertor.AsRomanNumeral(95));
        }
        [TestMethod]
        public void Test_333()
        {
            Assert.AreEqual("CCCXXXIII", Convertor.AsRomanNumeral(333));
        }
        [TestMethod]
        public void Test_444()
        {
            Assert.AreEqual("CDXLIV", Convertor.AsRomanNumeral(444));
        }
        [TestMethod]
        public void Test_555()
        {
            Assert.AreEqual("DLV", Convertor.AsRomanNumeral(555));
        }
        [TestMethod]
        public void Test_666()
        {
            Assert.AreEqual("DCLXVI", Convertor.AsRomanNumeral(666));
        }
        [TestMethod]
        public void Test_999()
        {
            Assert.AreEqual("CMXCIX", Convertor.AsRomanNumeral(999));
        }
        [TestMethod]
        public void Test1066()
        {
            Assert.AreEqual("MLXVI", Convertor.AsRomanNumeral(1066));
        }

        [TestMethod]
        public void Test1789()
        {
            Assert.AreEqual("MDCCLXXXIX", Convertor.AsRomanNumeral(1789));
        }

        [TestMethod]
        public void Test1999()
        {
            Assert.AreEqual("MCMXCIX", Convertor.AsRomanNumeral(1999));
        }

        [TestMethod]
        public void Test2017()
        {
            Assert.AreEqual("MMXVII", Convertor.AsRomanNumeral(2017));
        }
    }
}

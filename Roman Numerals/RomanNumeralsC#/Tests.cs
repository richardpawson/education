using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CSharpRomanNumerals
{
    [TestClass]
    public class Tests
    {
        [TestMethod]
        public void Test___0()
        {
            Assert.AreEqual("", Convertor.Roman(0));
        }

        [TestMethod]
        public void Test___1()
        {
            Assert.AreEqual("I", Convertor.Roman(1));
        }

        [TestMethod]
        public void Test___2()
        {
            Assert.AreEqual("II", Convertor.Roman(2));
        }

        [TestMethod]
        public void Test___3()
        {
            Assert.AreEqual("III", Convertor.Roman(3));
        }

        [TestMethod]
        public void Test___4()
        {
            Assert.AreEqual("IV", Convertor.Roman(4));
        }

        [TestMethod]
        public void Test___5()
        {
            Assert.AreEqual("V", Convertor.Roman(5));
        }
        [TestMethod]
        public void Test___6()
        {
            Assert.AreEqual("VI", Convertor.Roman(6));
        }
        [TestMethod]
        public void Test___7()
        {
            Assert.AreEqual("VII", Convertor.Roman(7));
        }
        [TestMethod]
        public void Test___8()
        {
            Assert.AreEqual("VIII", Convertor.Roman(8));
        }
        [TestMethod]
        public void Test___9()
        {
            Assert.AreEqual("IX", Convertor.Roman(9));
        }

        [TestMethod]
        public void Test__10()
        {
            Assert.AreEqual("X", Convertor.Roman(10));
        }
        [TestMethod]
        public void Test__11()
        {
            Assert.AreEqual("XI", Convertor.Roman(11));
        }

        [TestMethod]
        public void Test__14()
        {
            Assert.AreEqual("XIV", Convertor.Roman(14));
        }

        [TestMethod]
        public void Test__15()
        {
            Assert.AreEqual("XV", Convertor.Roman(15));
        }

        [TestMethod]
        public void Test__17()
        {
            Assert.AreEqual("XVII", Convertor.Roman(17));
        }

        [TestMethod]
        public void Test__19()
        {
            Assert.AreEqual("XIX", Convertor.Roman(19));
        }

        [TestMethod]
        public void Test__20()
        {
            Assert.AreEqual("XX", Convertor.Roman(20));
        }

        [TestMethod]
        public void Test__21()
        {
            Assert.AreEqual("XXI", Convertor.Roman(21));
        }

        [TestMethod]
        public void Test__25()
        {
            Assert.AreEqual("XXV", Convertor.Roman(25));
        }

        [TestMethod]
        public void Test__28()
        {
            Assert.AreEqual("XXVIII", Convertor.Roman(28));
        }
        [TestMethod]
        public void Test__29()
        {
            Assert.AreEqual("XXIX", Convertor.Roman(29));
        }

        [TestMethod]
        public void Test__30()
        {
            Assert.AreEqual("XXX", Convertor.Roman(30));
        }

        [TestMethod]
        public void Test__37()
        {
            Assert.AreEqual("XXXVII", Convertor.Roman(37));
        }

        [TestMethod]
        public void Test__41()
        {
            Assert.AreEqual("XLI", Convertor.Roman(41));
        }

        [TestMethod]
        public void Test__50()
        {
            Assert.AreEqual("L", Convertor.Roman(50));
        }
        [TestMethod]
        public void Test__54()
        {
            Assert.AreEqual("LIV", Convertor.Roman(54));
        }
        [TestMethod]
        public void Test__79()
        {
            Assert.AreEqual("LXXIX", Convertor.Roman(79));
        }
        [TestMethod]
        public void Test__95()
        {
            Assert.AreEqual("XCV", Convertor.Roman(95));
        }
        [TestMethod]
        public void Test_333()
        {
            Assert.AreEqual("CCCXXXIII", Convertor.Roman(333));
        }
        [TestMethod]
        public void Test_444()
        {
            Assert.AreEqual("CDXLIV", Convertor.Roman(444));
        }
        [TestMethod]
        public void Test_555()
        {
            Assert.AreEqual("DLV", Convertor.Roman(555));
        }
        [TestMethod]
        public void Test_666()
        {
            Assert.AreEqual("DCLXVI", Convertor.Roman(666));
        }
        [TestMethod]
        public void Test_999()
        {
            Assert.AreEqual("CMXCIX", Convertor.Roman(999));
        }
        [TestMethod]
        public void Test1066()
        {
            Assert.AreEqual("MLXVI", Convertor.Roman(1066));
        }

        [TestMethod]
        public void Test1789()
        {
            Assert.AreEqual("MDCCLXXXIX", Convertor.Roman(1789));
        }

        [TestMethod]
        public void Test1999()
        {
            Assert.AreEqual("MCMXCIX", Convertor.Roman(1999));
        }

        [TestMethod]
        public void Test2017()
        {
            Assert.AreEqual("MMXVII", Convertor.Roman(2017));
        }
    }
}

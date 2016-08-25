using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CSharpRomanNumerals
{
    [TestClass]
    public class Tests
    {
        [TestMethod]
        public void Test01()
        {
            Assert.AreEqual("I", Convertor.AsRomanNumeral(1));
        }

        [TestMethod]
        public void Test02()
        {
            Assert.AreEqual("II", Convertor.AsRomanNumeral(2));
        }

        [TestMethod]
        public void Test03()
        {
            Assert.AreEqual("III", Convertor.AsRomanNumeral(3));
        }

        [TestMethod]
        public void Test04()
        {
            Assert.AreEqual("IV", Convertor.AsRomanNumeral(4));
        }

        [TestMethod]
        public void Test5()
        {
            Assert.AreEqual("V", Convertor.AsRomanNumeral(5));
        }
        [TestMethod]
        public void Test6()
        {
            Assert.AreEqual("VI", Convertor.AsRomanNumeral(6));
        }
        [TestMethod]
        public void Test9()
        {
            Assert.AreEqual("IX", Convertor.AsRomanNumeral(9));
        }

        [TestMethod]
        public void Test10()
        {
            Assert.AreEqual("X", Convertor.AsRomanNumeral(10));
        }

        [TestMethod]
        public void Test14()
        {
            Assert.AreEqual("XIV", Convertor.AsRomanNumeral(14));
        }

        [TestMethod]
        public void Test15()
        {
            Assert.AreEqual("XV", Convertor.AsRomanNumeral(15));
        }

        [TestMethod]
        public void Test17()
        {
            Assert.AreEqual("XVII", Convertor.AsRomanNumeral(17));
        }

        [TestMethod]
        public void Test19()
        {
            Assert.AreEqual("XIX", Convertor.AsRomanNumeral(19));
        }

        [TestMethod]
        public void Test20()
        {
            Assert.AreEqual("XX", Convertor.AsRomanNumeral(20));
        }

        [TestMethod]
        public void Test21()
        {
            Assert.AreEqual("XXI", Convertor.AsRomanNumeral(21));
        }

        [TestMethod]
        public void Test25()
        {
            Assert.AreEqual("XXV", Convertor.AsRomanNumeral(25));
        }

        [TestMethod]
        public void Test28()
        {
            Assert.AreEqual("XXVIII", Convertor.AsRomanNumeral(28));
        }
        [TestMethod]
        public void Test29()
        {
            Assert.AreEqual("XXIX", Convertor.AsRomanNumeral(29));
        }

        [TestMethod]
        public void Test30()
        {
            Assert.AreEqual("XXX", Convertor.AsRomanNumeral(30));
        }

        [TestMethod]
        public void Test37()
        {
            Assert.AreEqual("XXXVII", Convertor.AsRomanNumeral(37));
        }

        [TestMethod]
        public void Test41()
        {
            Assert.AreEqual("XLI", Convertor.AsRomanNumeral(41));
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
        public void Test2016()
        {
            Assert.AreEqual("MMXVI", Convertor.AsRomanNumeral(2016));
        }
    }
}

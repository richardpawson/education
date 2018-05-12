using System;
using PowersOf2CS;
using PowersOf2VB;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestCS()
        {
            Assert.AreEqual("1", Program.TwoToThePowerOf(0));
            Assert.AreEqual("2", Program.TwoToThePowerOf(1));
            Assert.AreEqual("4", Program.TwoToThePowerOf(2));
            Assert.AreEqual("1024", Program.TwoToThePowerOf(10));
            Assert.AreEqual("65536", Program.TwoToThePowerOf(16));
            Assert.AreEqual("1267650600228229401496703205376", Program.TwoToThePowerOfMkI(100));
            
        }

        [TestMethod]
        public void TestVB()
        {
            Assert.AreEqual("1", Module1.TwoToThePowerOf(0));
            Assert.AreEqual("2", Module1.TwoToThePowerOf(1));
            Assert.AreEqual("4", Module1.TwoToThePowerOf(2));
            Assert.AreEqual("1024", Module1.TwoToThePowerOf(10));
            Assert.AreEqual("65536", Module1.TwoToThePowerOf(16));
            Assert.AreEqual("1267650600228229401496703205376", Module1.TwoToThePowerOf(100));
        }
    }
}

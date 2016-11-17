using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConsoleApplication;

namespace Test
{
    [TestClass]
    public class TestFactorial
    {
        [TestMethod]
        public void Test1()
        {
            Assert.AreEqual(1, Program.Factorial(1));
        }

        [TestMethod]
        public void Test2()
        {
            Assert.AreEqual(2, Program.Factorial(2));
        }
        [TestMethod]
        public void Test3()
        {
            Assert.AreEqual(6, Program.Factorial(3));
        }
        [TestMethod]
        public void Test4()
        {
            Assert.AreEqual(24, Program.Factorial(4));
        }
        [TestMethod]
        public void Test10()
        {
            Assert.AreEqual(3628800, Program.Factorial(10));
        }
        [TestMethod]
        public void Test0()
        {
            Assert.AreEqual(1, Program.Factorial(0));
        }
    }
}

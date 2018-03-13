using System;
using System.Collections.Generic;
using Calculator;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    [TestClass]
    public class EvaluateAsRPN
    {
        [TestMethod]
        public void TestMethod1()
        {
            var tokens = new List<object>() {3.1,4.25,'+' };
            Assert.AreEqual(7.35, Core.EvaluateAsRPN(tokens));
        }
        [TestMethod]
        public void TestMethod2()
        {
            var tokens = new List<object>() { 9.0, 4.6, '-' };
            Assert.AreEqual(4.4, Core.EvaluateAsRPN(tokens));
        }
        [TestMethod]
        public void TestMethod3()
        {
            var tokens = new List<object>() { 4.0, 9d, '-' };
            Assert.AreEqual(-5, Core.EvaluateAsRPN(tokens));
        }
        [TestMethod]
        public void TestMethod4()
        {
            var tokens = new List<object>() { 0.5, 0.25, '*' };
            Assert.AreEqual(0.125, Core.EvaluateAsRPN(tokens));
        }
        [TestMethod]
        public void TestMethod5()
        {
            var tokens = new List<object>() { 3d,4d, '+',5d,6d,'+','*' };
            Assert.AreEqual(77, Core.EvaluateAsRPN(tokens));
        }
        [TestMethod]
        public void TestMethod6()
        {
            var tokens = new List<object>() { 3d, 4d, '+', 5d, 6d, '*', '+' };
            Assert.AreEqual(37, Core.EvaluateAsRPN(tokens));
        }
        [TestMethod]
        public void TestMethod7()
        {
            var tokens = new List<object>() { 3d, 4d, 5d, 6d, '-', '*','/' };
            Assert.AreEqual(-0.75, Core.EvaluateAsRPN(tokens));
        }
        [TestMethod]
        public void InvalidTokenIgnored()
        {
            var tokens = new List<object>() { 3d, 4d, '%' };
            Assert.AreEqual(4, Core.EvaluateAsRPN(tokens));
        }
        [TestMethod]
        public void TooManyOperators()
        {
            var tokens = new List<object>() { 3d, 4d, '+','+' };
            try
            {
                Core.EvaluateAsRPN(tokens);
                Assert.Fail("Should not get to here");
            }
            catch (Exception e)
            {
                Assert.AreEqual("Stack empty.", e.Message);
            }
        }
    }
}

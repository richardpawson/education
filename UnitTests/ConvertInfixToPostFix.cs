using System;
using System.Collections.Generic;
using Calculator;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    [TestClass]
    public class ConvertInfixToPostFix
    {
        [TestMethod]
        public void TestMethod1()
        {
            var infix = new List<object>() { 3.1, '+', 4.25 }; ;
            var postfix = new List<object>() {3.1,4.25,'+' };
            CollectionAssert.AreEqual(postfix, Core.ConvertInfixToPostfix(infix));
        }
        [TestMethod]
        public void TestMethod2()
        {
            var infix = new List<object>() { 9.0, '-', 4.6 };
            var postfix = new List<object>() { 9.0, 4.6, '-' };
            CollectionAssert.AreEqual(postfix, Core.ConvertInfixToPostfix(infix));
        }
        [TestMethod]
        public void TestMethod3()
        {
            var infix = new List<object>() { 4.0, '-', 9d };
            var postfix = new List<object>() { 4.0, 9d, '-' };
            CollectionAssert.AreEqual(postfix, Core.ConvertInfixToPostfix(infix));
        }
        [TestMethod]
        public void TestMethod4()
        {
            var infix = new List<object>() { 0.5, '*', 0.25 };
            var postfix = new List<object>() { 0.5, 0.25, '*' };
            CollectionAssert.AreEqual(postfix, Core.ConvertInfixToPostfix(infix));
        }
        [TestMethod]
        public void TestMethod5()
        {
            var infix = new List<object>() { 3d, '+', 4d, '*', 5d };
            var postfix = new List<object>() { 3d, 4d, 5d, '*', '+' };
            CollectionAssert.AreEqual(postfix, Core.ConvertInfixToPostfix(infix));
        }
        [TestMethod]
        public void TestMethod6()
        {
            var infix = new List<object>() { 3d, '*', 4d, '+', 5d };
            var postfix = new List<object>() { 3d, 4d, '*', 5d, '+' };
            CollectionAssert.AreEqual(postfix, Core.ConvertInfixToPostfix(infix));
        }
        [TestMethod]
        public void TestMethod7()
        {
            var infix = new List<object>() { '(', 3d, '+', 4d, ')', '*',  5d };
            var postfix = new List<object>() { 3d, 4d, '+', 5d, '*' };
            CollectionAssert.AreEqual(postfix, Core.ConvertInfixToPostfix(infix));
        }
        [TestMethod]
        public void TestMethod8()
        {
            var infix = new List<object>() { '(', 3d, '+', 4d,')', '*', '(', 5d, '+', 6d, ')' };
            var postfix = new List<object>() { 3d,4d, '+',5d,6d,'+','*' };
            CollectionAssert.AreEqual(postfix, Core.ConvertInfixToPostfix(infix));
        }
        [TestMethod]
        public void TestMethod9()
        {
            var infix = new List<object>() { 3d, '+', 4d, '+', 5d, '*', 6d, };
            var postfix = new List<object>() { 3d, 4d, '+', 5d, 6d, '*', '+' };
            CollectionAssert.AreEqual(postfix, Core.ConvertInfixToPostfix(infix));
        }
        [TestMethod]
        public void TestMethod10()
        {
            var infix = new List<object>() { 3d, '/', 4d, '*', '(',5d, '-', 6d, ')' };
            var postfix = new List<object>() { 3d, 4d, '/', 5d, 6d, '-', '*' };
            CollectionAssert.AreEqual(postfix, Core.ConvertInfixToPostfix(infix));
        }
        [TestMethod]
        public void TestMethod11()
        {
            var infix = new List<object>() { 4d, '*', '(', 5d, '-', 6d,'*',7d, ')' };
            var postfix = new List<object>() { 4d, 5d, 6d,7d,'*','-','*' };
            CollectionAssert.AreEqual(postfix, Core.ConvertInfixToPostfix(infix));
        }
        [TestMethod]
        public void TestMethod12()
        {
            var infix = new List<object>() { 3d, '+',4d, '*', '(', 5d, '-', 6d, '*', 7d, ')' };
            var postfix = new List<object>() { 3d, 4d, 5d, 6d, 7d, '*', '-', '*','+' };
            CollectionAssert.AreEqual(postfix, Core.ConvertInfixToPostfix(infix));
        }
    }
}

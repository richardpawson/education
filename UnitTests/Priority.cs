using Calculator;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTests
{
    [TestClass]
    public class Priority
    {
        [TestMethod]
        public void Plus()
        {
            Assert.AreEqual(1, Core.Priority('+'));
        }
        [TestMethod]
        public void Minus()
        {
            Assert.AreEqual(1, Core.Priority('-'));
        }
        [TestMethod]
        public void Times()
        {
            Assert.AreEqual(2, Core.Priority('*'));
        }
        [TestMethod]
        public void Divide()
        {
            Assert.AreEqual(2, Core.Priority('/'));
        }
        [TestMethod]
        public void Bracket()
        {
            Assert.AreEqual(0, Core.Priority('('));
        }
        [TestMethod]
        public void Unrecognised()
        {
            Assert.AreEqual(0, Core.Priority('%'));
        }
    }
}

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Multiplication
{
    [TestClass]
    public class UnitTest1
    {

        public static int IntegerMultiply(int a, int b)
        {
            var table = new int[10][];

            foreach (char c  in a.ToString().ToCharArray())
            {
                int digit = Convert.ToInt32(c) - 48;

            }
           
        }

        public static double FloatingPointMultiply(double a, double b)
        {
            return a * b;
        }


        [TestMethod]
        public void TestSingleDigitMultiply()
        {
            Assert.AreEqual(56, IntegerMultiply(7, 8));
            Assert.AreEqual(56, IntegerMultiply(8, 7));
            Assert.AreEqual(81, IntegerMultiply(9, 9));
            Assert.AreEqual(0, IntegerMultiply(0, 4));
            Assert.AreEqual(3, IntegerMultiply(3, 1));
            Assert.AreEqual(16, IntegerMultiply(2, 8));
        }

        [TestMethod]
        public void TestMultiDigitMultiply()
        {
            Assert.AreEqual(2047, IntegerMultiply( 23, 89));
            Assert.AreEqual(2047, IntegerMultiply(89, 23));
            Assert.AreEqual(998001, IntegerMultiply(999, 999));
            Assert.AreEqual(121, IntegerMultiply(11, 11));
        }

        [TestMethod]
        public void TestFloatingPointMultiply()
        {
            AssertEqualFP(41144.3214, FloatingPointMultiply(45.22, 909.87));
            AssertEqualFP(0.0000003, FloatingPointMultiply(0.1, 0.000003));
            AssertEqualFP(.56, FloatingPointMultiply(.7, .8));
            AssertEqualFP(560, FloatingPointMultiply(8000, 0.07));
            AssertEqualFP(2047, FloatingPointMultiply(23, 89));
            AssertEqualFP(2047, FloatingPointMultiply(89, 23));
            AssertEqualFP(998001, FloatingPointMultiply(999, 999));
            AssertEqualFP(121, FloatingPointMultiply(11, 11));
        }

        private void AssertEqualFP(double a, double b)
        {
            Assert.AreEqual(a.ToString(), b.ToString());

        }
    }
}

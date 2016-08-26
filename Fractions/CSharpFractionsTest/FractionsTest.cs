using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CSharpFractions;

namespace CSharpFractionsTest
{
    [TestClass]
    public class FractionsTest
    {
        //First, without reduction//
        [TestMethod]
        public void test_1()
        {
            var a = new Fraction(2, 3); // 2/3
            var b = new Fraction(1, 4); // 1/4
            Assert.AreEqual("11/12", a.plus(b).ToString());
        }

        [TestMethod]
        public void test_2()
        {
            var a = new Fraction(2, 3);
            var b = new Fraction(1, 4);
            Assert.AreEqual("5/12", a.minus(b).ToString());
        }

        [TestMethod]
        public void test_3()
        {
            var a = new Fraction(2, 3);
            var b = new Fraction(1, 4);
            Assert.AreEqual("2/12",a.multiplyBy(b).ToString());
        }

        [TestMethod]
        public void test_4()
        {
            var a = new Fraction(2, 3);
            var b = new Fraction(1, 4);
            Assert.AreEqual("8/3", a.divideBy(b).ToString());
        }

        //Test your implementation with lots of other examples including complex fractions, negative numbers, zeros.//
        //Print out all the results//

        //Now add an internal function to reduce the answer (or any newly created fraction)
        //such that the third answer above comes out as 1/6 instead of 2/12.
        //Add more test examples and include tests and results in your submission//

        //Finally, change the __str__ function so that the fourth answer is presented as '2 & 2/3'
        //instead of '8/3'.  Test with other examples where the resulting fraction is > 1

    }
}

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text;
using TechnicalServices;

namespace Boom.Test
{
    [TestClass]
    public class RandomNumberTests
    {
        [TestMethod]
        public void TestSequenceFromSeededGenerator()
        {
            var gen1 = new Random(1);
            var sb = new StringBuilder();
            //range values correspond to realistic requests in app
            sb.Append(gen1.Next(0, 10)).Append(" ");
            sb.Append(gen1.Next(0, 10)).Append(" ");
            sb.Append(gen1.Next(0, 2)).Append(" ");
            sb.Append(gen1.Next(0, 10)).Append(" ");
            sb.Append(gen1.Next(0, 10)).Append(" ");
            sb.Append(gen1.Next(0, 2)).Append(" ");
            sb.Append(gen1.Next(0, 10)).Append(" ");
            sb.Append(gen1.Next(0, 10)).Append(" ");
            sb.Append(gen1.Next(0, 2)).Append(" ");
            sb.Append(gen1.Next(0, 10)).Append(" ");
            sb.Append(gen1.Next(0, 10)).Append(" ");
            sb.Append(gen1.Next(0, 2)).Append(" ");
            string gen1Results = sb.ToString();
            Assert.AreEqual("2 1 0 7 6 0 3 9 0 6 0 0 ", gen1Results);
        }

        [TestMethod]
        public void TestSequenceFromFunctionalImplementation() { 
            var gen2 = new Random(1);
            var result1 = RandomNumbers.Next(gen2, 0, 10);
            Assert.AreEqual(2, result1.Item1);
            var result2 = RandomNumbers.Next(result1.Item2, 0, 10);
            Assert.AreEqual(1, result2.Item1);
            var result3 = RandomNumbers.Next(result2.Item2, 0, 2);
            Assert.AreEqual(0, result3.Item1);
            var result4 = RandomNumbers.Next(result3.Item2, 0, 10);
            Assert.AreEqual(7, result4.Item1);

        }

        [TestMethod]
        public void TestFunctionRepeatability()
        {
            var gen = new Random(1);
            Assert.AreEqual(2, RandomNumbers.Next(gen, 0, 10).Item1);
            Assert.AreEqual(2, RandomNumbers.Next(gen, 0, 10).Item1);
            Assert.AreEqual(2, RandomNumbers.Next(gen, 0, 10).Item1);
        }       
    }
}

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text;
using FunctionalLibrary;

namespace FAB.Test
{
    [TestClass]
    public class RandomNumberTests
    {
        [TestMethod]
        public void TestSequenceFromSeededGenerator()
        {
            var random = new RandomResult(0, 521288629, 362436069);
            var sb = new StringBuilder();
            for (int i = 0; i < 10; i++)
            {
                random = random.Next(0, 10);
                sb.Append(random.Number).Append(" ");
            }
            string gen1Results = sb.ToString();
            Assert.AreEqual("5 1 2 2 8 0 2 7 9 0 ", gen1Results);
        }

        [TestMethod]
        public void TestSequenceFromFunctionalImplementation() { 
            var random0 = new RandomResult(1);
            var random1 = random0.Next(0, 10);
            Assert.AreEqual(5, random1.Number);
            var random2 = random1.Next(0, 10);
            Assert.AreEqual(2, random2.Number);
            var random3 = random2.Next(0, 2);
            Assert.AreEqual(1, random3.Number);
            var random4 = random3.Next(0, 10);
            Assert.AreEqual(9, random4.Number);

        }

        [TestMethod]
        public void TestFunctionRepeatability()
        {
            var random = new RandomResult(1);
            Assert.AreEqual(2, random.Next(0, 5).Number);
            Assert.AreEqual(2, random.Next(0, 5).Number);
            Assert.AreEqual(2, random.Next(0, 5).Number);
        }       
    }
}

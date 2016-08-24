using Microsoft.VisualStudio.TestTools.UnitTesting;
using CSharpApp;

namespace CSharpTest
{
    [TestClass]
    public class ConversionsTests
    {
        [TestMethod]
        public void test_room() {
            Assert.AreEqual(Conversions.ToCelcius(68), 20);
        }

        [TestMethod]
        public void test_boiling() {
            Assert.AreEqual(Conversions.ToCelcius(212), 100);
        }

        [TestMethod]
        public void test_freezing()
        {
            Assert.AreEqual(Conversions.ToCelcius(32), 0);
        }
    }
}

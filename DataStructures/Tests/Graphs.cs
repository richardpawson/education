using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataStructures
{
    [TestClass]
    public class GraphTests
    {
        private Graph<int, float> SetUpGraph()
        {
            var g = new Graph<int, float>();
            g.AddNode(1);
            g.AddNode(2);
            g.AddNode(3);
            g.AddNode(4);
            g.AddNode(5);
            g.AddEdge(1, 2, 0.3f);
            g.AddEdge(1, 3, 0.8f);
            g.AddEdge(2, 3, 0.3f);
            g.AddEdge(3, 2, 0.3f);
            g.AddEdge(2, 4, 0.45f);
            g.AddEdge(3, 5, 0.63f);
            g.AddEdge(4, 5, 0.27f);
            return g;
        }

        private string AsString(List<int> list)
        {
            var sb = new StringBuilder();
            foreach (int i in list)
            {
                sb.Append(i).Append(" ");
            }
            return sb.ToString();
        }

        #region Depth First
        [TestMethod]
        public void TestDepthFirstFrom1()
        {
            var g = SetUpGraph();
            var result = g.TraverseDepthFirst(1);
            Assert.AreEqual("1 2 3 5 4 ", AsString(result));
        }

        [TestMethod]
        public void TestDepthFirstFrom2()
        {
            var g = SetUpGraph();
            var result = g.TraverseDepthFirst(2);
            Assert.AreEqual("2 3 5 4 ", AsString(result));
        }

        [TestMethod]
        public void TestDepthFirstFrom4()
        {
            var g = SetUpGraph();
            var result = g.TraverseDepthFirst(4);
            Assert.AreEqual("4 5 ", AsString(result));
        }
        #endregion

        #region Depth First2
        [TestMethod]
        public void TestDepthFirst2From1()
        {
            var g = SetUpGraph();
            var result = g.TraverseDepthFirst2(1);
            Assert.AreEqual("1 2 3 5 4 ", AsString(result));
        }

        [TestMethod]
        public void TestDepthFirst2From2()
        {
            var g = SetUpGraph();
            var result = g.TraverseDepthFirst2(2);
            Assert.AreEqual("2 3 5 4 ", AsString(result));
        }

        [TestMethod]
        public void TestDepthFirst2From4()
        {
            var g = SetUpGraph();
            var result = g.TraverseDepthFirst2(4);
            Assert.AreEqual("4 5 ", AsString(result));
        }
        #endregion

        #region Breadth First
        [TestMethod]
        public void TestBreadthFirstFrom1()
        {
            var g = SetUpGraph();
            var result = g.TraverseBreadthFirst(1);
            Assert.AreEqual("1 2 3 4 5 ", AsString(result));
        }

        [TestMethod]
        public void TestBreadthFirstFrom3()
        {
            var g = SetUpGraph();
            var result = g.TraverseBreadthFirst(3);
            Assert.AreEqual("3 2 5 4 ", AsString(result));
        }

        [TestMethod]
        public void TestBreadthFirstFrom4()
        {
            var g = SetUpGraph();
            var result = g.TraverseBreadthFirst(4);
            Assert.AreEqual("4 5 ", AsString(result));
        }
        #endregion
    }
}

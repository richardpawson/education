using System;
using System.Collections.Generic;
using System.Linq;

namespace DataStructures
{
    public class Graph<TNode, TEdge> where TNode : IEquatable<TNode>
    {
        private Dictionary<TNode, List<Tuple<TNode, TEdge>>> edges = new Dictionary<TNode, List<Tuple<TNode, TEdge>>>();

        public void AddNode(TNode node)
        {
            edges.Add(node, new List<Tuple<TNode, TEdge>>());
        }

        public void AddEdge(TNode fromNode, TNode toNode, TEdge weight)
        {
            var list = edges[fromNode];
            list.Add(Tuple.Create(toNode, weight));
        }

        public List<TNode> ConnectedNodes(TNode fromNode)
        {
            return edges[fromNode].Select(link => link.Item1).ToList();
        }

        public TEdge GetWeight(TNode fromNode, TNode toNode)
        {
            return edges[fromNode].Where(l => l.Item1.Equals(toNode)).Select(l => l.Item2).First();
        }

        #region TraverseDepthFirst
        /// <summary>
        /// This method adopts the simplest approach to depth-first traversal.  It does not have an explicit Stack
        /// of nodes to be returned to: instead the stack is implicit in the use of recursion.
        /// </summary>
        /// <param name="startingAt">The node from which the traversal is to start</param>
        /// <param name="visited">List of nodes visited -  recursively. For the initial call this may be set to null.</param>
        /// <returns>List of Nodes in the order that they were visted, from the startNode</returns>
        public List<TNode> TraverseDepthFirst(TNode startingAt)
        {
            var visited = new List<TNode>();
            return TraverseDepthFirst(startingAt, visited);
        }

        private List<TNode> TraverseDepthFirst(TNode currentNode, List<TNode> visited)
        {
            visited.Add(currentNode);
            foreach (var node in ConnectedNodes(currentNode))
            {
                if (!visited.Contains(node))
                {
                    TraverseDepthFirst(node, visited);
                }
            }
            return visited;
        }
        #endregion

        #region TraverseDepthFirst2
        /// <summary>
        /// This alternative implementation still uses recursion but has an explicit stack of nodes to
        /// be returned to -  so works more like the diagrams, but is more complex
        /// </summary>
        /// <param name="startingAt">The node from which the traversal is to start</param>
        /// <param name="visited">List of nodes visited -  recursively. For the initial call this may be set to null.</param>
        /// <param name="nodesToReturnTo">A stack, representing nodes that must be returned to.  For the initial call this may be set to null. </param>
        /// <returns>List of Nodes in the order that they were visted, from the startNode</returns>
        public List<TNode> TraverseDepthFirst2(TNode startingAt)
        {
            var visited = new List<TNode>();
            var nodesToReturnTo = new Stack<TNode>();
            return TraverseDepthFirst2(startingAt, visited, nodesToReturnTo);
        }

        private List<TNode> TraverseDepthFirst2(TNode currentNode, List<TNode> visited, Stack<TNode> nodesToReturnTo)
        {
            while (true)
            {
                if (!visited.Contains(currentNode))
                {
                    visited.Add(currentNode);
                };
                var ongoingNodes = ConnectedNodes(currentNode).Where(n => !visited.Contains(n) && !nodesToReturnTo.Contains(n));
                TNode next;
                if (ongoingNodes.Count() > 0)
                {
                    nodesToReturnTo.Push(currentNode);
                    next = ongoingNodes.First();
                }
                else
                {
                    if (nodesToReturnTo.Count == 0)
                    {
                        break;
                    }
                    else
                    {
                        next = nodesToReturnTo.Pop();
                    }
                }
                TraverseDepthFirst2(next, visited, nodesToReturnTo);
            }
            return visited;
        }
        #endregion

        public List<TNode> TraverseBreadthFirst(TNode startNode)
        {
            var visited = new List<TNode>();
            var toBeVisited = new Queue<TNode>();

            toBeVisited.Enqueue(startNode);
            while (toBeVisited.Count > 0)
            {
                var currentNode = toBeVisited.Dequeue();
                visited.Add(currentNode);
                foreach (var neighbour in ConnectedNodes(currentNode))
                {
                    if (!visited.Contains(neighbour) && !toBeVisited.Contains(neighbour))
                    {
                        toBeVisited.Enqueue(neighbour);
                    }
                }
            }
            return visited;
        }
    }
}

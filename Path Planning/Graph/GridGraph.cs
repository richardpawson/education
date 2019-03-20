using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;

//Below is a Graph class that has several methods implemented, but two unimplemented ones:
// -  ShortestPath
// -  LowestCostUnvisitedNode (a private helper method to be called by the first)
// - 
//Your task is to implement both methods until all three of the unit tests pass.
//The algorithm has been specified in some detail in comments.
//Don't delete the comments!  Write code in-front or beneath them as appropriate

//If your tests don't pass:  DEBUG them until they do! i.e. trace them through
//Note that the unit tests set up a standard test graph that is identical to the 
//map of US cities that you used for your paper tests. The node numbers can be checked
//against the Cities enum below i.e. Chicago = 0, SanDiego = 7. 

namespace Graph {

    public class GridGraph
    {
        public int GridSize { get; private set; }
        public HashSet<Point> Nodes { get; private set; }

        public GridGraph(int gridSize)
        {
            Nodes = new HashSet<Point>();
            GridSize = gridSize;
            SetBlock(new Point(0, 0), new Point(gridSize - 1, gridSize - 1), true);
        }

        public void SetBlock(Point p1, Point p2, bool add = false)
        {
            //TODO: check that p1, p2 are in right order!
            for (int x = p1.X; x <= p2.X; x++)
            {
                for (int y = p1.Y; y <= p2.Y; y++)
                {
                    Point p = new Point(x, y);
                    if (add)
                    {
                        Nodes.Add(p);
                    } else
                    {
                        Nodes.Remove(p);
                    }
                }
            }
        }


        private bool NodeExists(Point p)
        {
            return Nodes.Contains(p);
        }

        private bool EdgeExists(Point p1, Point p2)
        {
            return NodeExists(p1) && NodeExists(p2) && !p1.Equals(p2) && Math.Abs(p1.X - p2.X) <= 1 && Math.Abs(p1.Y - p2.Y) <= 1;
        }

        public double? FindEdge(Point p1, Point p2)
        {
            if (EdgeExists(p1, p2))
            {
                return 1;
            } else
            {
                return null;
            }
        }

        //Returns a list of nodes that can be reached from the specified node
        public List<Point> Neighbours(Point p)
        {
            var list = new List<Point>() { new Point(p.X - 1, p.Y), new Point(p.X, p.Y - 1), new Point(p.X + 1, p.Y), new Point(p.X, p.Y + 1) };
            return list.Where(n => NodeExists(n)).ToList();
        }

        //Returns a list of nodes, from source to destination, representing the shortest path, using Dijkstra's algorithm
        //You may make use of existing methods such a s Neignbours, or FindEdge.
        public List<Point> ShortestPath(Point source, Point destination, Algorithms alg)
        {
            //Initialise the 'table' with three 'columns' - one 'row' per node
            Dictionary<Point, bool> visited = NewDictionaryOfAllPointsReturningFalseValues();
            Dictionary<Point, double> costFromSource = NewDictionaryOfAllPointsReturningDoublesSetToInfinity();
            Dictionary<Point, Point?> via = NewDictionaryOfAllPointsReturningNull();
            //Set start
            var currentNode = source;
            costFromSource[currentNode] = 0;
            //Iterate until shortest path found
            while (currentNode != destination)
            {
                visited[currentNode] = true;
                UpdateCostAndViaOfEachNeighbourIfApplicable(costFromSource, via, currentNode, destination, alg);
                currentNode = LowestCostUnvisitedNode(visited, costFromSource);
                if (costFromSource[currentNode] == double.PositiveInfinity)
                {
                    throw new Exception("Cannot reach destination -  graph is 'disconnected'");
                }
            }
            return RetraceRoute(destination, source, via);
        }

        public Dictionary<Point, Point?> NewDictionaryOfAllPointsReturningNull()
        {
            var dict = new Dictionary<Point, Point?>();
            foreach (Point p in Nodes)
            {
                dict.Add(p, null);
            }
            return dict;
        }

        public Dictionary<Point, double> NewDictionaryOfAllPointsReturningDoublesSetToInfinity()
        {
            var dict = new Dictionary<Point, double>();
            foreach (Point p in Nodes)
            {
                dict.Add(p, double.PositiveInfinity);
            }
            return dict;
        }

        public Dictionary<Point, bool> NewDictionaryOfAllPointsReturningFalseValues()
        {
            var dict = new Dictionary<Point, bool>();
            foreach (Point p in Nodes)
            {
                dict.Add(p, false);
            }
            return dict;
        }

        public void UpdateCostAndViaOfEachNeighbourIfApplicable(Dictionary<Point, double> costFromSource, Dictionary<Point, Point?> via, Point currentNode, Point destination, Algorithms alg)
        {
            foreach (var neighbour in Neighbours(currentNode))
            {
                double newCost = 0;
                switch (alg)
                {
                    case Algorithms.Dijkstra:
                        newCost = costFromSource[currentNode] + FindEdge(currentNode, neighbour).Value;
                        break;
                    case Algorithms.Optimistic:
                        newCost = EstimatedCostToDestination(neighbour, destination);
                        break;
                    case Algorithms.AStar:
                        newCost = costFromSource[currentNode] + FindEdge(currentNode, neighbour).Value + EstimatedCostToDestination(neighbour, destination);
                        break;
                    default:
                        break;
                }
                if (newCost < costFromSource[neighbour])
                {
                    costFromSource[neighbour] = newCost;
                    via[neighbour] = currentNode;
                }
            }
        }

        public double EstimatedCostToDestination(Point current, Point destination)
        {
            return Math.Sqrt(Math.Pow(current.X - destination.X, 2) + Math.Pow(current.Y - destination.Y, 2));
        }

        public Point LowestCostUnvisitedNode(Dictionary<Point, bool> visited, Dictionary<Point, double> cost)
        {
            double? lowestCostSoFar = null;
            Point lowestCostNode = Nodes.First();
            foreach (Point p in Nodes)
            {
                if (!visited[p] && (lowestCostSoFar == null || cost[p] < lowestCostSoFar))
                {
                    lowestCostSoFar = cost[p];
                    lowestCostNode = p;
                }
            }
            return lowestCostNode;
        }

        public List<Point> RetraceRoute(Point destination, Point source, Dictionary<Point, Point?> via)
        {
            var result = new List<Point>() { destination };
            var currentNode = destination;
            while (currentNode != source)
            {
                var previous = via[currentNode];
                result.Insert(0, previous.Value);
                currentNode = previous.Value;
            }
            return result;
        }

        //Calculates total cost of specified route of nodes visited, by adding values of the edges.
        //Assume the route provided is valid (i.e. an edge exists between each pair of nodes).
        //So if it is not a valid route an error may occur.
        public double TotalCostOfRoute(List<int> nodesFollowed)
        {
            throw new NotImplementedException();
            //double result = 0;
            //for (int i = 0; i < nodesFollowed.Count() - 1; i++)
            //{
            //    result += FindEdge(nodesFollowed[i], nodesFollowed[i + 1]).Value;
            //}
            //return result;
        }
    }
}
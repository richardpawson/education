using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;

namespace Pathfinder
{

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
                    }
                    else
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
            return NodeExists(p1) && NodeExists(p2) && !p1.Equals(p2) && (PointsAreAdjacentOrthogonally(p1, p2) || PointsAreAdjacentDiagonally(p1, p2));
        }

        private bool PointsAreAdjacentDiagonally(Point p1, Point p2)
        {
            return Math.Abs(p1.X - p2.X) == 1 && Math.Abs(p1.Y - p2.Y) == 1;
        }

        private bool PointsAreAdjacentOrthogonally(Point p1, Point p2)
        {
            return Math.Abs(p1.X - p2.X) == 1 && (p1.Y == p2.Y) || Math.Abs(p1.Y - p2.Y) == 1 && (p1.X == p2.X);
        }

        public double? FindEdge(Point p1, Point p2)
        {
            if (EdgeExists(p1, p2))
            {
                if (PointsAreAdjacentDiagonally(p1, p2))
                {
                    return Math.Sqrt(2);
                }
                else
                {
                    return 1;
                }

            }
            else
            {
                return null;
            }
        }

        //Returns a list of nodes that can be reached from the specified node
        public List<Point> Neighbours(Point p)
        {
            var list = new List<Point>() {
                new Point(p.X, p.Y-1),
                new Point(p.X+1, p.Y-1),
                new Point(p.X+1, p.Y),
                new Point(p.X+1, p.Y+1),
                new Point(p.X, p.Y+1),
                new Point(p.X-1, p.Y+1),
                new Point(p.X-1, p.Y),
                new Point(p.X-1, p.Y-1) };
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
                UpdateCostAndViaOfEachNeighbourIfApplicable(costFromSource, via, currentNode, destination);
                currentNode = NextNodeToVisit(currentNode, visited, costFromSource, destination, alg);
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

        public void UpdateCostAndViaOfEachNeighbourIfApplicable(Dictionary<Point, double> costFromSource, Dictionary<Point, Point?> via, Point currentNode, Point destination)
        {
            foreach (var neighbour in Neighbours(currentNode))
            {
                double newCost = costFromSource[currentNode] + FindEdge(currentNode, neighbour).Value;

                if (newCost < costFromSource[neighbour])
                {
                    costFromSource[neighbour] = newCost; //Wrong -  don't update cost to estimate -  update to actual. Use estimate to choose the lowest cost unvisited node only. 
                    via[neighbour] = currentNode;
                }
            }
        }

        public double EstimatedCostToDestination(Point current, Point destination)
        {
            return Math.Sqrt(Math.Pow(current.X - destination.X, 2) + Math.Pow(current.Y - destination.Y, 2));
        }

        public Point NextNodeToVisit(Point currentNode, Dictionary<Point, bool> visited, Dictionary<Point, double> costFromSource, Point destination, Algorithms alg)
        {
            var lowestCostSoFar = double.PositiveInfinity;
            Point lowestCostNode = Nodes.First();
            var possibilities = Nodes.Where(n => !visited[n] && costFromSource[n] < double.PositiveInfinity);
            if (possibilities.Count() ==0)
            {
                throw new Exception("The graph is disconnected -  there are no routes from start to destination.");
            }
            foreach (Point p in possibilities)
            {
                double cost = 0;
                switch (alg)
                {
                    case Algorithms.Dijkstra:
                        cost = costFromSource[p];
                        break;
                    case Algorithms.Optimistic:
                        cost = EstimatedCostToDestination(p, destination);
                        break;
                    case Algorithms.AStar:
                        cost = costFromSource[p] + EstimatedCostToDestination(p, destination);
                        break;
                    default:
                        break;
                }
                if (cost < lowestCostSoFar)
                {
                    lowestCostSoFar = cost;
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

        public double SumOfEdges(List<Point> route)
        {
            double result = 0;
            int step = 0;
            while (step < route.Count - 1)
            {
                result += FindEdge(route[step], route[step + 1]).Value;
                step++;
            }
            return result;
        }
    }
}
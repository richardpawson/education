using System;
using System.Collections.Generic;
using System.Drawing;

namespace Graph
{
    public static class Scenarios
    {
        const int GridSize = 40;
        public static List<Scenario> AllScenarios()
        {
            var list = new List<Scenario>();
            list.Add(Empty());
            list.Add(Simple());
            list.Add(RockyField());
            list.Add(Fences());
            return list;
        }

        private static Scenario Empty()
        {
            var g = new GridGraph(GridSize);
            var s = new Scenario("Empty", g, new Point(0, 0), new Point(0,0));
            return s;
        }


        private static Scenario Simple()
        {
            var g = new GridGraph(GridSize);
            g.SetBlock(new Point(10,20), new Point(30, 20), false);
            g.SetBlock(new Point(20, 10), new Point(20,30), false);
            var s = new Scenario("Simple", g, new Point(15, 15), new Point(25, 25));
            return s;
        }


        private static Scenario RockyField()
        {
            var start = new Point(0, 0);
            var destination = new Point(39, 39);
            var rng = new Random();
            var g = new GridGraph(GridSize);
            for (int i = 0; i < 400; i++)
            {
                var p = new Point(rng.Next(GridSize),rng.Next(GridSize));
                if (p != start && p != destination)
                {
                    g.SetBlock(p, p, false);
                }
            }
            var s = new Scenario("Rocky field", g, start, destination);
            return s;
        }


        private static Scenario Fences()
        {
            var start = new Point(0, 0);
            var destination = new Point(39, 39);
            var rng = new Random();
            var g = new GridGraph(GridSize);
            for (int i = 0; i < 20; i++)
            {
                var x = rng.Next(GridSize);
                var y = rng.Next(GridSize);
                var begin = new Point(x, y);
                var orientation = rng.Next(2);
                var end = new Point(0, 0);
                if (orientation > 0)
                {
                    end = new Point(x, y+rng.Next(GridSize - y));
                } else
                {
                    end = new Point(x+rng.Next(GridSize - x),y);
                }
                    g.SetBlock(begin, end, false);
            }
            g.SetBlock(start, start, true);
            g.SetBlock(destination, destination, true);
            var s = new Scenario("Fences", g, start, destination);
            return s;
        }

    }
}

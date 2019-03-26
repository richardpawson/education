using System.Drawing;

namespace Pathfinder
{
    /// <summary>
    /// Holds a specific graph, with start and destination, and with a scenario name.
    /// </summary>
    public class Scenario
    {
        public string Name { get; private set; }
        public GridGraph Graph { get; private set; }
        public Point Start { get; private set; }
        public Point Destination { get; set; }
        public Scenario(string name, GridGraph g, Point start, Point destination)
        {
            Name = name;
            Graph = g;
            Start = start;
            Destination = destination;
        }
        public override string ToString()
        {
            return Name;
        }
    }
}

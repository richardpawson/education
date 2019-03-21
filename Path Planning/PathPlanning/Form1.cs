
using Graph;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace PathPlanning
{
    public partial class Form1 : Form
    {
        private Pen blackPen = new Pen(Color.Black);
        private Brush whiteBrush = new SolidBrush(Color.White);
        const int squareSize = 10;
        Graphics graphics;
        private Brush redBrush = new SolidBrush(Color.Red);
        private Brush blueBrush = new SolidBrush(Color.Blue);

        private Scenario scenario;

        public Form1()
        {
            InitializeComponent();
                 graphics = Grid.CreateGraphics();
            StartButton.Enabled = false;
            ScenarioSelector.DataSource = Scenarios.AllScenarios();
            // algorithmSelector.DataSource = new Algorithms[] {Algorithms.Dijkstra, Algorithms.Optimistic, Algorithms.AStar};
            algorithmSelector.DataSource = Enum.GetValues(typeof(Algorithms)).Cast<Algorithms>();

        }

        private int GridDrawSize()
        {
            return (scenario.Graph.GridSize) * squareSize;
        }

        private void ScenarioSelector_SelectedIndexChanged(object sender, EventArgs e)
        {
            scenario = (Scenario) ScenarioSelector.SelectedValue;
            DrawScenario();
            StartButton.Enabled = true;
        }

        private void DrawScenario()
        {
            DrawGraph(scenario.Graph);
            DrawStartAndFinish();
        }

        private void DrawStartAndFinish()
        {
            DrawSquare(scenario.Start, new SolidBrush(Color.Red));
            DrawSquare(scenario.Destination, new SolidBrush(Color.Green));
        }

        private void DrawGraph(GridGraph graph)
        {
            PaintBackGroundBlack();
            foreach (Point node in graph.Nodes)
            {
                DrawSquare(node, whiteBrush);
            }
            DrawStartAndFinish();
        }

        private void PaintBackGroundBlack()
        {

            var rect = new Rectangle(new Point(0,0),new Size(GridDrawSize(), GridDrawSize()));
            graphics.FillRectangle(new SolidBrush(Color.Black), rect);
        }

        private void DrawSquare(Point square, Brush brush)
        {
            int col = square.X;
            int row = square.Y;
            var pen = new Pen(Color.Black);
            graphics.DrawRectangle(pen, col * squareSize, row * squareSize, squareSize, squareSize);
            if (brush != null)
            {
                graphics.FillRectangle(brush, col * squareSize + 1, row * squareSize + 1, squareSize - 1, squareSize - 1);
            }
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            var route = ShortestPath(scenario);
            foreach (Point p  in route)
            {
                DrawSquare(p, new SolidBrush(Color.Yellow));
            }
            DrawStartAndFinish();
            pathLength.Text = route.Count.ToString();
        }

        private List<Scenario> ScenarioList()
        {
            return Scenarios.AllScenarios();
        }

        private List<Point> ShortestPath(Scenario s)
        {
            var source = s.Start;
            var destination = s.Destination;
            var graph = s.Graph;
            //Initialise the 'table' with three 'columns' - one 'row' per node
            Dictionary<Point, bool> visited = graph.NewDictionaryOfAllPointsReturningFalseValues();
            Dictionary<Point, double> costFromSource = graph.NewDictionaryOfAllPointsReturningDoublesSetToInfinity();
            Dictionary<Point, Point?> via = graph.NewDictionaryOfAllPointsReturningNull();
            int count = 0;
            //Set start
            var currentNode = source;
            costFromSource[currentNode] = 0;
            //Iterate until shortest path found
            while (currentNode != destination)
            {
                visited[currentNode] = true;
                count++;
                graph.UpdateCostAndViaOfEachNeighbourIfApplicable(costFromSource, via, currentNode, destination, (Algorithms)algorithmSelector.SelectedValue);
                currentNode = graph.LowestCostUnvisitedNode(visited, costFromSource);
                DrawSquare(currentNode, new SolidBrush(Color.LightBlue));
                Thread.Sleep((int)Speed.Value);
            }
            count++; //For the destination
            visitedCount.Text = count.ToString(); ;
            return graph.RetraceRoute(destination, source, via);
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            DrawScenario();
            visitedCount.Clear();
            pathLength.Clear();
        }
    }
}

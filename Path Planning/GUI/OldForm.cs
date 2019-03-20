using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace GUI
{
    public partial class OldForm : Form
    {
        private Pen blackPen = new Pen(Color.Black);
        private Brush whiteBrush = new SolidBrush(Color.White);
        const int squareSize = 30;
        const int boardSize = 10;
        Graphics g;
        private GridGraph Graph;
        private Brush redBrush = new SolidBrush(Color.Red);
        private Brush blueBrush = new SolidBrush(Color.Blue);

        public OldForm()
        {
            InitializeComponent();
            g = Grid.CreateGraphics();
        }


        private void InitializeSimulation()
        {
            Graph = new GridGraph(40, 40);
            Graph.SetBlock(new Point(3, 4), new Point(7, 8), false);
        }

        private void DrawGraph()
        {
            foreach (Point node in Graph.ReadNodes())
            {
                DrawSquare(node, whiteBrush);
            }
        }

        private void DrawSquare(Point square, Brush brush)
        {
            int col = square.X;
            int row = square.Y;
            var pen = blackPen;
            g.DrawRectangle(pen, col * squareSize, row * squareSize, squareSize, squareSize);
            if (brush != null)
            {
                g.FillRectangle(brush, col * squareSize + 1, row * squareSize + 1, squareSize - 1, squareSize - 1);
            }
        }

    }
}




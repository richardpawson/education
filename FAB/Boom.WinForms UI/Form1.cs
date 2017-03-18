using Boom.DataFixture;
using Boom.Model;
using System;
using System.Drawing;
using System.Windows.Forms;
using TechnicalServices;

namespace Boom.WinFormsUI
{
    public partial class Form1 : Form
    {
        private Pen blackPen = new Pen(Color.Black);
        private Brush redBrush = new SolidBrush(Color.Red);
        private Brush blueBrush = new SolidBrush(Color.Blue);
        private Brush whiteBrush = new SolidBrush(Color.White);

        private GameBoard Board;
        private ReadableLogger Logger = new ReadableLogger();

        public Form1()
        {
            InitializeComponent();
        }

        private void InitializeGame(Ship[] ships)
        {
            Logger.StartLogging();
            var randomGenerator = new SystemRandomGenerator();
            Board = new GameBoard(10, ships, Logger, randomGenerator);
        }

        private void DrawBoard()
        {
            const int squareSize = 30;
            var g = pictureBox1.CreateGraphics();
            for (int col = 0; col < Board.Size; col++)
            {
                for (int row = 0; row < Board.Size; row++)
                {
                    var square = GameBoard.ReadSquare(Board, col, row);
                    Brush brush = null;
                    switch (square)
                    {
                        case SquareValues.Empty:
                            brush = whiteBrush;
                            break;
                        case SquareValues.Miss:
                            brush = blueBrush;
                            break;
                        case SquareValues.Hit:
                            brush = redBrush;
                            break;
                    }
                    if (square == SquareValues.Hit)
                    {
                        brush = redBrush;
                    }
                    else if (square == SquareValues.Miss)
                    {
                        brush = blueBrush;
                    }
                    DrawSquare(squareSize, g, col, row, brush);
                }
            }
        }

        private void DrawSquare(int squareSide, Graphics g, int col, int row, Brush fill)
        {
            g.DrawRectangle(blackPen, col * squareSide, row * squareSide, squareSide, squareSide);
            if (fill != null)
            {
                g.FillRectangle(fill, col * squareSide + 1, row * squareSide + 1, squareSide - 1, squareSide - 1);
            }
        }
        #region Button clicks
        private void button1_Click(object sender, EventArgs e)
        {
            var ships = Ships.TrainingGame();
            InitializeGame(ships);
            DrawBoard();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            var row = Convert.ToInt16(comboBox1.SelectedItem);
            var col = Convert.ToInt16(comboBox2.SelectedItem);
            Missile.Fire(col, row, Board);
            DrawBoard();
            richTextBox1.Text = Logger.ReadAndResetLog();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            var ships = Ships.UnplacedShips5();
            InitializeGame(ships);
            GameBoard.RandomiseShipPlacement(Board);
            DrawBoard();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var row = Convert.ToInt16(comboBox1.SelectedItem);
            var col = Convert.ToInt16(comboBox2.SelectedItem);
            Bomb.Fire(col, row, Board);
            DrawBoard();
            richTextBox1.Text = Logger.ReadAndResetLog();
        }
        #endregion

    }
}

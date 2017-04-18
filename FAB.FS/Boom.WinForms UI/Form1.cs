using Boom.DataFixture;
using FAB.Types;
using System;
using System.Collections.Immutable;
using System.Drawing;
using System.Windows.Forms;

namespace Boom.WinFormsUI
{
    public partial class Form1 : Form
    {
        private const int boardSize = 10;
        const int squareSize = 30;

        private Pen blackPen = new Pen(Color.Black);
        private Brush redBrush = new SolidBrush(Color.Red);
        private Brush blueBrush = new SolidBrush(Color.Blue);
        private Brush whiteBrush = new SolidBrush(Color.White);

        private GameBoard Board;
        private ImmutableList<Location>  noMisses = ImmutableList<Location>.Empty;

        public Form1()
        {
            InitializeComponent();
        }

        private void DrawBoard()
        {
            var g = pictureBox1.CreateGraphics();
            for (int col = 0; col < Board.Size; col++)
            {
                for (int row = 0; row < Board.Size; row++)
                {
                    var loc = new Location(col, row);
                    var square = GameBoardFunctions.readSquare(Board, loc);
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

            Board = new GameBoard(boardSize, ships, "", ImmutableList<Location>.Empty);
            DrawBoard();
        }


        private void button2_Click(object sender, EventArgs e)
        {
            var row = Convert.ToInt16(comboBox1.SelectedItem);
            var col = Convert.ToInt16(comboBox2.SelectedItem);
            var loc = new Location(col, row);
            Board = Missile.fireMissile(loc, Board);
            DrawBoard();
            richTextBox1.Text = Board.Messages;
        }
        private void button3_Click(object sender, EventArgs e)
        {
            var ships = Ships.UnplacedShips5();
            Board = GameBoardFunctions.createBoardWithShipsPlacedRandomly(Board.Size, ships, new Random());
            DrawBoard();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var row = Convert.ToInt16(comboBox1.SelectedItem);
            var col = Convert.ToInt16(comboBox2.SelectedItem);
            var loc = new Location(col, row);
            Board = Missile.fireBomb(loc, Board);
            DrawBoard();
            richTextBox1.Text = Board.Messages;
        }
        #endregion

    }
}

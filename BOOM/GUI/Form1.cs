using Boom.DataFixture;
using Boom.Model;
using System;
using System.Drawing;
using System.Windows.Forms;
using TechnicalServices;

namespace GUI
{
    public partial class Form1 : Form
    {
        private Pen blackPen = new Pen(Color.Black);
        private Brush whiteBrush = new SolidBrush(Color.White);
        const int squareSize = 30;
        const int boardSize = 10;
        Graphics g;
        private GameBoard Board;
        private ReadableLogger Logger = new ReadableLogger();
        private Brush redBrush = new SolidBrush(Color.Red);
        private Brush blueBrush = new SolidBrush(Color.Blue);

        public Form1()
        {
            InitializeComponent();
            g = Grid.CreateGraphics();
        }

        private void NewTrainingGame_Click(object sender, EventArgs e)
        {
            var ships = Ships.TrainingGame();
            InitializeGame(ships);
            DrawBoard();
        }

        private void InitializeGame(Ship[] ships)
        {
            Logger.StartLogging();
            var randomGenerator = new SystemRandomGenerator();
            Board = new GameBoard(10, ships, Logger, randomGenerator);
        }

        private void DrawBoard()
        {
            for (int col = 0; col < boardSize; col++)
            {
                for (int row = 0; row < boardSize; row++)
                {
                    var square = Board.ReadSquare(col, row);
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
                    DrawSquare(col, row, blackPen, brush);
                }
            }
        }

        private void DrawSquare(int col, int row, Pen pen, Brush fill)
        {
            g.DrawRectangle(pen, col * squareSize, row * squareSize, squareSize, squareSize);
            if (fill != null)
            {
                g.FillRectangle(fill, col * squareSize + 1, row * squareSize + 1, squareSize - 1, squareSize - 1);
            }
        }

        private void FireMissile_Click(object sender, EventArgs e)
        {
            FireWeapon(new Missile());
        }

        private void FireWeapon(IWeapon weapon)
        {
            var row = Convert.ToInt16(Row.SelectedItem);
            var col = Convert.ToInt16(Column.SelectedItem);
            weapon.Fire(col, row, Board);
            DrawBoard();
            Messages.Text = Logger.ReadAndResetLog();
        }
    }
}




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
        Pen blackPen = new Pen(Color.Black);
        private GameBoard Board;
        private ReadableLogger Logger = new ReadableLogger();

        public Form1()
        {
            InitializeComponent();
            InitializeGame();
        }

        private void InitializeGame()
        {
            var ships = Ships.TrainingGame();

            Logger.StartLogging();
            var randomGenerator = new SystemRandomGenerator();
            Board = new GameBoard(10, ships, Logger, randomGenerator);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DrawBoard();
        }


        private void DrawBoard()
        {
            const int squareSize = 30;
            var g = pictureBox1.CreateGraphics();
            for (int row = 0; row < Board.Size; row++)
            {
                for (int col = 0; col < Board.Size; col++)
                {
                    var square = Board.ReadSquare(row, col);
                    Brush brush = null;
                    if (square == GameBoard.Hit)
                    {
                        brush = new SolidBrush(Color.Red);
                    }
                    else if (square == GameBoard.Miss)
                    {
                        brush = new SolidBrush(Color.Green);
                    }
                    DrawSquare(squareSize, g, row, col, brush);
                }
            }
        }

        private void DrawSquare(int squareSide, Graphics g, int row, int col, Brush fill)
        {
            g.DrawRectangle(blackPen, col * squareSide, row * squareSide, squareSide, squareSide);
            if (fill != null)
            {
                g.FillRectangle(fill, col * squareSide + 1, row * squareSide + 1, squareSide - 1, squareSide - 1);
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            var missile = new Missile();
            var row = Convert.ToInt16(comboBox1.SelectedItem);
            var col = Convert.ToInt16(comboBox2.SelectedItem);
            missile.Fire(row, col, Board);
            DrawBoard();
            richTextBox1.Text = Logger.ReadAndResetLog();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}

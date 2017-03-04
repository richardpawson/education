using Boom.DataFixture;
using Boom.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TechnicalServices;

namespace Boom.WinFormsUI
{
    public partial class Form1 : Form
    {
        private Pen bluePen = new Pen(Color.Blue, 2F);
        private Brush redBrush = new SolidBrush(Color.Red);
        private Brush greenBrush = new SolidBrush(Color.Green);
        private GameBoard Board;
        public Form1()
        {
            InitializeComponent();
            var ships = Ships.TrainingGame();
            var logger = new ConsoleLogger();
            logger.StartLogging();
            var randomGenerator = new SystemRandomGenerator();
            Board = new GameBoard(10, ships, logger, randomGenerator);
            var missile = new Missile();
            missile.Fire(1, 8, Board);
            missile.Fire(1, 9, Board);
            missile.Fire(2, 8, Board);
        }

        private void button1_Click(object sender, EventArgs e)
        {

            DrawBoard();
        }

        
        private void DrawBoard()
        {
            const int squareSide = 30;
            var g = pictureBox1.CreateGraphics();
            for (int row = 0; row < Board.Size; row++)
            {
                for (int col = 0; col < Board.Size; col++)
                {
                    var sqChar = Board.ReadSquare(row, col);
                    Brush brush = null;
                    if (sqChar == GameBoard.Hit)
                    {
                        brush = redBrush;
                    }           
                    else if (sqChar == GameBoard.Miss)
                    {
                        brush = greenBrush;
                    }
                    DrawSquare(squareSide, g, row, col, brush);
                }
            }
        }

        private void DrawSquare(int squareSide, Graphics g, int row, int col,Brush fill)
        {
            g.DrawRectangle(bluePen, col * squareSide, row * squareSide, squareSide, squareSide);
            if (fill != null)
            {
                g.FillRectangle(fill, col * squareSide + 1, row * squareSide + 1, squareSide - 2, squareSide - 2);
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }
    }
}

using PredatorPrey.DataFixture;
using PredatorPrey.Model;
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

namespace PredatorPrey.WinFormsUI
{
    public partial class Form1 : Form
    {
        private ReadableLogger Logger = new ReadableLogger();
        private IRandomGenerator RandomGenerator = new SystemRandomGenerator();
        Simulation Sim = null;
        private Pen BlackPen = new Pen(Color.Black);
        private Brush BlackBrush = new SolidBrush(Color.Black);
        private Brush WhiteBrush = new SolidBrush(Color.White);
        private Graphics Graphics;
        private Font MyFont = new Font(FontFamily.GenericSansSerif, 10);

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var landscape = new SquareLandscape(15, RandomGenerator);
            int variability = 0;
            var setUp = new FixedLocationSetUp(landscape, variability, Logger, RandomGenerator);
            Sim = new Simulation(setUp, Logger, RandomGenerator);
            Graphics = pictureBox1.CreateGraphics();
            DrawSquareLandscape();
            OutputLoggerToScreen();
        }
        private void DrawSquareLandscape()
        {
            var land = (SquareLandscape)Sim.Landscape; //Down-cast is OK as this method is explicly for Square Landscapes only
            for (int col = 0; col < land.Size; col++)
            {
                for (int row = 0; row < land.Size; row++)
                {

                    var loc = land.GetLocation(row, col);
                    DrawCellWithContents(loc, Sim);
                }
            }
        }

        private void DrawCellWithContents(Location loc, Simulation sim)
        {
            const int gridSize = 20;
            int x = loc.X * gridSize;
            int y = loc.Y * gridSize;
            var rect = new Rectangle(x, y, gridSize, gridSize);
            Graphics.FillRectangle(WhiteBrush, rect);
            Graphics.DrawRectangle(BlackPen, rect);

            var warren = sim.GetWarren(loc);
            string s = "";
            if (warren != null)
            {
                s = warren.RabbitCount.ToString();
            }
            if (sim.GetFox(loc) != null)
            {
                s = "F";
            }
            Graphics.DrawString(s, MyFont, BlackBrush, x, y);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Sim.AdvanceTimePeriod();
            DrawSquareLandscape();
            textBox1.Text = Sim.TimePeriod.ToString();
            OutputLoggerToScreen();
        }

        private void OutputLoggerToScreen()
        {
            richTextBox1.Text = Logger.ReadAndResetLog();
        }

    }
}

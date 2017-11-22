using Nakov.TurtleGraphics;
using System;
using System.Windows.Forms;

namespace TurtleGraphics
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Turtle.Reset();
            int size = (int)numericUpDown1.Value;
            int level = (int)numericUpDown2.Value;
            SnowFlake.Draw(size, level);
        }

       




    }
}

using Nakov.TurtleGraphics;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Trees
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Regular_Click(object sender, EventArgs e)
        {
            Turtle.Reset();
            var tree = new RegularTree((int)branch_min.Value, (int) angle_min.Value);
            tree.Draw((int)size.Value, (int) level.Value);
        }

        private void Variable_Click(object sender, EventArgs e)
        {
            Turtle.Reset();
            new RealisticTree((int)size.Value, (int)branch_min.Value, (int)branch_max.Value, (int)angle_min.Value, (int)angle_max.Value, (int)level.Value);
        }

        private void numericUpDown4_ValueChanged(object sender, EventArgs e)
        {

        }

        private void numericUpDown5_ValueChanged(object sender, EventArgs e)
        {

        }

        private void branchMin(object sender, EventArgs e)
        {

        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {

        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}

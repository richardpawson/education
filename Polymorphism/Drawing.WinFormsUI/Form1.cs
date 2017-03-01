using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Drawing.WinFormsUI
{
    public partial class Form1 : Form
    {
        private System.Drawing.Pen pen1 = new System.Drawing.Pen(Color.Blue, 2F);

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           var g = pictureBox1.CreateGraphics();
            //g.DrawRectangle(pen1, 30, 30, 50, 60);
            var rect = new Drawing.Model.Rectangle(30, 30, 50, 60);
            var x = rect.Draw();
        }


    }
}

using System;

using System.Windows.Forms;

namespace OOPDraw
{
    public partial class Form1 : Form
    {
        private Drawing drawing;

        public Form1()
        {
            InitializeComponent();
            drawing = new Drawing();
        }

        private void Next_Click(object sender, EventArgs e)
        {
                drawing.UnselectAll();
            drawing.SelectNextShape();
            drawing.DrawAll();
        }

        private void Previous_click(object sender, EventArgs e)
        {
                drawing.UnselectAll();
            drawing.SelectPreviousShape();
            drawing.DrawAll();
        }

        private void Circle_Click(object sender, EventArgs e)
        {
            drawing.AddShape(new Circle(0,0,20));
            drawing.DrawAll();
        }
        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            //Map between window & Turtle coordinates
            int x = e.X - Width / 2 + 8; 
            int y = Height / 2 - e.Y -19;
            string function = (string) Function.SelectedItem;
            if (function == "New Rectangle")
            {
                drawing.AddShape(new Rectangle(x, y, 100, 50));
                drawing.DrawAll();
            }
            else if (function == "New Circle")
            {
                drawing.AddShape(new Circle(x, y, 20));
                drawing.DrawAll();
            }
            else if (function == "New Triangle")
            {
                drawing.AddShape(new EquliateralTriangle(x, y, 100));
                drawing.DrawAll();
            }
            else if (function == "New House")
            {
                drawing.AddShape(new House(x, y, 100, 70));
                drawing.DrawAll();
            }
            else if (function == "Move")
            {
                drawing.MoveActiveShape(x, y);
            }
            else if (function == "Resize")
            {
                drawing.ResizeActiveShape(x, y);
            }
            drawing.DrawAll();
        }

        private void Clear_Click(object sender, EventArgs e)
        {
            drawing.Clear();
            drawing.DrawAll();
        }
    }
}

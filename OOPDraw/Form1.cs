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
            if (Form.ModifierKeys != Keys.Control)
            {
                drawing.UnselectAll();
            }
            drawing.SelectNextShape();
            drawing.DrawAll();
        }

        private void Previous_click(object sender, EventArgs e)
        {
            if (Form.ModifierKeys != Keys.Control)
            {
                drawing.UnselectAll();
            }
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
            string selected = (string) Modify.SelectedItem;
            if (selected == "Move")
            {
                drawing.MoveActiveShape(x, y);
            }
            else if (selected == "Resize")
            {
                drawing.ResizeActiveShape(x, y);
            }
            drawing.DrawAll();
        }

        private void Rectangle_Click(object sender, EventArgs e)
        {
            drawing.AddShape(new Rectangle(0,0,100, 50));
            drawing.DrawAll();
        }

        private void Triangle_Click(object sender, EventArgs e)
        {
            drawing.AddShape(new EquliateralTriangle(0,0, 100));
            drawing.DrawAll();
        }

        private void House_Click(object sender, EventArgs e)
        {
            drawing.AddShape(new House(0,0,100, 70));
            drawing.DrawAll();
        }

        private void Clear_Click(object sender, EventArgs e)
        {
            drawing.Clear();
            drawing.DrawAll();
        }
    }
}

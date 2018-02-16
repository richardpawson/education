using Nakov.TurtleGraphics;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace OOPDraw
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private List<Shape> shapes = new List<Shape>();

        private Shape mostRecent;

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            //Transform windows coordinates to Turtle coordinates
            float turtleX = e.X - Width / 2 + 8;
            float turtleY = Height / 2 - e.Y - 19;
            string selectedItem = (string)comboBox1.SelectedItem;
            if (selectedItem == "Draw Triangle") //We will add more options later
            {
                AddShape(new EquilateralTriangle(turtleX, turtleY, 50));
            }
            else if (selectedItem == "Draw Rectangle")
            {
                AddShape(new Rectangle(turtleX, turtleY, 100, 50));
            }
            else if (selectedItem == "Draw House")
            {
                AddShape(new House(turtleX, turtleY, 100, 50));
            }
            else if (selectedItem == "Move Shape")
            {
                ActiveShape().MoveTo(turtleX, turtleY);
            }
            else if (selectedItem == "Resize Shape")
            {
               ActiveShape().ResizeAbsolute(turtleX, turtleY);
            }
            DrawAll();
        }

        private void AddShape(Shape shape)
        {
            if (shapes.Count > 0) //i.e. this isn't the first shape
            {
                ActiveShape().Unselect();
            }
            shapes.Add(shape);
            activeShapeNumber = shapes.Count - 1; //i.e. the shape just added
            ActiveShape().Select();
        }

        public void DrawAll()
        {
            Turtle.Dispose();  //First clear all Turtle tracks to start afresh
            foreach (var shape in shapes)
            {
                shape.Draw();
            }
        }

        private int activeShapeNumber = 0;

        private Shape ActiveShape()
        {
            return shapes[activeShapeNumber]; //List elements can be accessed like an array
        }

        private void Next_Click(object sender, System.EventArgs e)
        {
            ActiveShape().Unselect();
            activeShapeNumber = activeShapeNumber + 1;
            if (activeShapeNumber >= shapes.Count) activeShapeNumber = 0;
            ActiveShape().Select();
            DrawAll();
        }

        private void Prev_Click(object sender, System.EventArgs e)
        {
            ActiveShape().Unselect();
            activeShapeNumber = activeShapeNumber - 1;
            if (activeShapeNumber < 0) activeShapeNumber = shapes.Count - 1;
            ActiveShape().Select();
            DrawAll();
        }
    }
}

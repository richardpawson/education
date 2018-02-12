using Nakov.TurtleGraphics;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace OOPDraw
{
    public class Drawing
    {
        private List<Shape> Shapes
            = new List<Shape>();

        private int activeShapeNumber = 0;

        public Shape ActiveShape()
        {
            return Shapes.ElementAt(activeShapeNumber);
        }

        public void SelectNextShape()
        {
            activeShapeNumber = activeShapeNumber + 1;
            if (activeShapeNumber >= Shapes.Count) activeShapeNumber = 0;
            ActiveShape().Select();
        }

        public void SelectPreviousShape()
        {
            activeShapeNumber = activeShapeNumber - 1;
            if (activeShapeNumber < 0) activeShapeNumber = Shapes.Count - 1;
            ActiveShape().Select();
        }

        internal void UnselectAll()
        {
            foreach(var shape in Shapes)
            {
                shape.Unselect();
            }
        }
        public  void DrawAll()
        {
            Turtle.Dispose();
            Turtle.ShowTurtle = false;
            foreach (var shape in Shapes)
            {
                shape.Draw();
            }
        }

        public void Clear()
        {
            Shapes = new List<Shape>();         
        }

        public void MoveActiveShape(int x, int y)
        {
            ActiveShape().MoveTo(x, y);
        }

        public void ResizeActiveShape(int x, int y)
        {
            ActiveShape().ResizeTo(x, y);
        }

        public void AddShape(Shape shape)
        {
            UnselectAll();
            Shapes.Add(shape);
            activeShapeNumber = Shapes.Count - 1; //i.e. the shape just added
            shape.Select();
            DrawAll();
        }
    }
}

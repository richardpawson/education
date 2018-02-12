using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace OOPDraw
{
    public class House : Shape
    {
        public Rectangle Walls { get; set; }
        public Triangle Roof { get; set; }

        public House(): base()
        {
            Walls = new Rectangle();
            Roof = new Triangle();
            Roof.CentreY = Walls.Height / 2;
        }

        public override void Draw()
        {
            Walls.Draw();
            Roof.Draw();
        }

        public override void ResizeBy(float x, float y)
        {
            Roof.ResizeBy(x, y * 2);
            Roof.MoveBy(0, y - Walls.Height / 2); //TODO: make equivalent to group
            Walls.ResizeBy(x, y);
        }

        public override void MoveTo(float x, float y)
        {
            base.MoveTo(x, y);
            Walls.MoveTo(x, y);
            Roof.MoveTo(x, y + Walls.Height / 2);
        }

        public override void Select()
        {
            Walls.Select();
            Roof.Select();
        }
        public override void Unselect()
        {
            Walls.Unselect();
            Roof.Unselect();
        }
    }
}

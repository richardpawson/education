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

        public override void Resize(float x, float y)
        {
            Walls.Resize(x, y);
            Roof.Base = Walls.Width;
            Roof.Height = Walls.Height;
            Roof.CentreY = Walls.CentreY + Walls.Height / 2;
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

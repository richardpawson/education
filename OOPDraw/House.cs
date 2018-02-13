using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace OOPDraw
{
    public class House : Shape
    {
        public float Width { get; set; }
        public float WallHeight { get; set; }
        public Rectangle Walls { get; set; }
        public EquliateralTriangle Roof { get; set; }

        public House(float originX, float originY, float width, float wallHeight) : base(originX, originY)
        {
            Width = width;
            WallHeight = wallHeight;
            Walls = new Rectangle(originX, originY, width, wallHeight);
            Roof = new EquliateralTriangle(originX, wallHeight, width);
        }

        public override void Draw()
        {
            Walls.Draw();
            Roof.Draw();
        }

        public override void Resize(float x, float y)
        {
            Width = x;
            var yDiff = y - WallHeight;
            WallHeight = y;
            Walls.Resize(x, y);
            Roof.Resize(x, 0);
            Roof.MoveBy(0, yDiff);
        }

        public override void MoveTo(float x, float y)
        {
            base.MoveTo(x, y);
            Walls.MoveTo(x, y);
            Roof.MoveTo(x, y + WallHeight);
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

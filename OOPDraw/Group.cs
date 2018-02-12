using System;
using System.Collections.Generic;
using System.Linq;

namespace OOPDraw
{
    public class Group : Shape
    {
        public List<Shape> Members = new List<Shape>();

        public Group(List<Shape> members)
        {
            Members = members;
        }

        public override void Draw()
        {
            foreach(Shape member in Members)
            {
                member.Draw();
            }
        }

        public override void Select()
        {
            foreach (Shape member in Members)
            {
                member.Select();
            }
        }

        public override void Unselect()
        {
            foreach (Shape member in Members)
            {
                member.Unselect();
            }
        }

        public override void Resize(float x, float y)
        {
            throw new NotImplementedException();
        }

        public override void MoveTo(float x, float y)
        {
            float xDiff = x - CentreX;
            float yDiff = y - CentreY;
            base.MoveTo(x, y);
            foreach (Shape member in Members)
            {
                member.MoveBy(xDiff, yDiff);
            }
        }
    }
}

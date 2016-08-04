using System;
using System.Collections.Generic;
namespace Polymorphism
{
    public class Rectangle : Shape
    {
        public Rectangle(int x, int y, int width, int height) : base(x, y, width, height) { }

        public override void Draw()
        {
            //logic to draw the rectangle on a canvas
        } 
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polymorphism
{
    public class Trapezoid : Shape
    {
        private int angle;
        public Trapezoid(int x, int y, int width, int height, int angle) : base(x, y, width, height) {
            this.angle = angle;
        }

        public override void Draw()
        {
            //logic to draw the Trapezoid on a canvas
        }
    }
}

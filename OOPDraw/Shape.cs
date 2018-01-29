using System.Drawing;

namespace OOPDraw
{
    public abstract class Shape
    {
        //Properties
        public float CentreX { get; set; }
        public float CentreY { get; set; }
        public Color LineColor { get; set; }

        //Abstract methods -  to be implemeted in sub-types
        public abstract void Draw();
        public abstract void GrowBy(float factor);

        //Concrete methods
        public void MoveCentreBy(float xDiff, float yDiff)
        {
            CentreX += xDiff;
            CentreY += yDiff;
        }
    }
}

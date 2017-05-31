namespace Drawing2CSharp
{
    public abstract class Shape
    {

        public virtual int XPosition { get; set; }

        public virtual int YPosition { get; set; }


        public void MoveTo(int newX, int newY)
        {
            XPosition = newX;
            YPosition = newY;
        }

        public void MoveBy(int incX, int incY)
        {
            XPosition = XPosition+incX;
            YPosition = YPosition+incY;
        }

        public abstract byte[] DrawAsBitMap();
        public abstract string Summary();
        public abstract void GrowBy(double percent);
    }
}

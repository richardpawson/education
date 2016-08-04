using System;

namespace Polymorphism
{
    public abstract class Shape :  IHasSize
    {    
        protected int x;
        protected int y;
        protected int width;
        protected int height;

        public Shape(int x, int y, int width, int height)
        {
            this.x = x;
            this.y = y;
            this.width = width;
            this.height = height;
        } 

        public void MoveBy(int x, int y)
        {
            this.x += x;
            this.y += y;
        }

        public void StretchWidth(int percent)
        {
            width = width * (1 + percent / 100);
        }


        public abstract void Draw(); 

        public bool IsLargerThan(IHasSize other)
        {
            var otherShape = other as Shape;
            if (otherShape == null) return false;
            return this.width > otherShape.width || this.height > otherShape.height;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InheritanceInCSharp
{
    public abstract class BaseShape
    {
        private int positionX = 0;
        private int positionY = 0;
        //These 'concrete' methods provide implementations
        public void MoveTo(int newX, int newY)
        {
            positionX = newX;
            positionY = newY;
        }
        public void MoveBy(int deltaX, int deltaY)
        {
            positionX += deltaX;
            positionY = deltaY;
        }
        //These 'abstract' methods must be implemented in concrete sub-classes
        public abstract string Summary();
        public abstract void GrowBy(double percent);
    }
}

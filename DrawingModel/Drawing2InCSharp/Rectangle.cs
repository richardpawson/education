﻿using System;

namespace Drawing2CSharp
{

    public class Rectangle :  Shape, IRotatable
    {
        double height = 0;
        double width = 0;
        double orientation = 0;

        //Constructor
        public Rectangle(double h, double w)
        {
            height = h;
            width = w;
        }
        // Provides a string representation of the object
        public override string Summary()
        {
            //... and we use self to access properties or other methods
            return "Rectangle, H: " + height + " W: " + width + " orientation:" + orientation;
        }
        public override void GrowBy(double percent)
        {
            height = height * (1 + percent / 100);
            width = width * (1 + percent / 100);
        }

        public override byte[] DrawAsBitMap()
        {
            throw new NotImplementedException();
        }

        public void RotateBy(int degrees)
        {
            orientation = (orientation + degrees) % 360;
        }
    }

}

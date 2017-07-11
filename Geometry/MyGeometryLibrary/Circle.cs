
using System;

namespace MyGeometryLibrary
{
    public static class Circle
    {
        public static double CircumferenceOfCircle(double radius)
        {
            return 2 * Math.PI * radius;
        }

        public static double AreaOfCircle(double radius)
        {
            return Math.PI * radius * radius;
        }
    }
}

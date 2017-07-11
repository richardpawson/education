using System;
using System.Collections.Generic;
using System.Text;

namespace MyGeometryLibrary
{
    public static class Triangle
    {
        /// <summary>
        /// Calculates the size of the hypotenuse using Pythagoras' Theorem
        /// </summary>
        /// <param name="b">(Double) one of the two sides of the triangle</param>
        /// <param name="c">(Double) the other input side</param>
        /// <returns>Double representing the size of the Hypoteneuse</returns>
        public static double Pythagoras(double b, double c)
        {
            return Math.Sqrt(b * b + c * c);
        }
    }
}

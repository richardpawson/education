using System;

namespace PredatorPrey
{
    public class Location
    {
        public int X { get; private set; }
        public int Y { get; private set; }

        public Location(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public double DistanceFrom(Location other)
        {
            return Math.Sqrt(Math.Pow(X - other.X, 2) + Math.Pow(Y - other.Y, 2));
        }
    }
}

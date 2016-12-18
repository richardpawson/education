using System.Collections.Generic;
using System.Linq;
using TechnicalServices;

namespace PredatorPrey.Model
{
   public abstract class Landscape
    {
        protected List<Location> Locations = new List<Location>();
        protected IRandomGenerator RandomGenerator;

        public Landscape(IRandomGenerator randomGenerator)
        {
            RandomGenerator = randomGenerator;
        }

        public Location RandomLocation()
        {
            int r = RandomGenerator.Next(0, Locations.Count);
            return Locations[r];
        }

        public Location GetLocation(int x, int y)
        {
            return Locations.FirstOrDefault(loc => loc.X == x && loc.Y == y);
        }
    }

   public class SquareLandscape : Landscape
    {
        public int Size { get; private set; }

        public SquareLandscape(int size, IRandomGenerator randomGenerator) : base(randomGenerator)
        {
            this.Size = size;
            for (int x = 0; x < size; x++)
            {
                for (int y = 0; y < size; y++)
                {
                   Locations.Add(new Location(x, y));
                }
            }
        }
    }
}

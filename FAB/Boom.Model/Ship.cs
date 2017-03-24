using System;
using System.Collections.Immutable;
using System.Linq;

namespace Boom.Model
{
    public class Ship
    {
        public Location Location;

        public readonly Orientations Orientation;

        public readonly string Name;

        public readonly int Size;

        public readonly ImmutableHashSet<Location> Hits;

        public Ship(string ShipName, int ShipSize, ImmutableHashSet<Location> hits, Location loc, Orientations orient = 0)
        {
            Name = ShipName;
            Size = ShipSize;
            Location = loc;
            Orientation = orient;
            Hits = hits;
        }

        public Ship(string ShipName, int ShipSize)
        {
            Name = ShipName;
            Size = ShipSize;
            Orientation = Orientations.Horizontal;
            Hits = ImmutableHashSet<Location>.Empty;
        }

    }
}
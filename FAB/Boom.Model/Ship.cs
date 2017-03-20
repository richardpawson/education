using System;
using System.Collections.Immutable;
using System.Linq;

namespace Boom.Model
{
    public class Ship
    { 
        public readonly int startRow;

        public readonly int startCol;

        public readonly Orientations Orientation;

        public readonly string Name;

        public readonly int Size;

        public readonly ImmutableHashSet<Tuple<int,int>> Hits;

        public Ship(string ShipName, int ShipSize, ImmutableHashSet<Tuple<int, int>> hits, int col = 0, int row = 0, Orientations orient = 0)
        {
            Name = ShipName;
            Size = ShipSize;
            startCol = col;
            startRow = row;
            Orientation = orient;
            Hits = hits;
        }

    }
}
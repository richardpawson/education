using System.Collections.Immutable;

namespace FAB.Model
{ 
    public enum Orientations
    {
        Horizontal, Vertical
    }

    public enum SquareValues
    {
        Empty, Miss, Hit
    }

    public struct Location
    {
        public readonly int Col;
        public readonly int Row;

        public Location(int col, int row)
        {
            Col = col;
            Row = row;
        }

        public Location Add(int colInc, int rowInc)
        {
            return new Location(Col + colInc, Row + rowInc);
        }

    }

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

        public Ship(string ShipName, int ShipSize, Location loc, Orientations orient = 0)
        {
            Name = ShipName;
            Size = ShipSize;
            Location = loc;
            Orientation = orient;
            Hits = ImmutableHashSet<Location>.Empty;
        }

        public Ship(string ShipName, int ShipSize)
        {
            Name = ShipName;
            Size = ShipSize;
            Orientation = Orientations.Horizontal;
            Hits = ImmutableHashSet<Location>.Empty;
        }

    }

    public class GameBoard
    {
        public readonly int Size;
        public readonly ImmutableList<Location> Misses;
        public readonly ImmutableArray<Ship> Ships;
        public readonly string Messages;

        public GameBoard(int size, ImmutableArray<Ship> ships, string messages, ImmutableList<Location> misses)
        {
            Size = size;
            Messages = messages;
            Ships = ships;
            Misses = misses;
        }
    }
}

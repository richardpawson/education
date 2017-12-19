using FunctionalLibrary;
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

    public class Location
    {
        //All properties are readonly ...
        public readonly int Col;
        public readonly int Row;

        //...set in the constructor and never changed
        public Location(int col, int row)
        {
            Col = col;
            Row = row;
        }

        public override string ToString()
        {
            return string.Format("{0}, {1}",Col, Row);
        }
    }

    public class Ship
    {
        public readonly Location Location;

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

        public int HeadCol
        {
            get { return Location.Col; }
        }
        public int HeadRow
        {
            get { return Location.Row; }
        }
    }

    public class GameBoard
    {
        public readonly int Size;
        public readonly FList<Location> Misses; //Use only immutable collections (library)
        public readonly FList<Ship> Ships;
        public readonly string Messages;

        public GameBoard(int size, FList<Ship> ships, string messages, FList<Location> misses)
        {
            Size = size;
            Messages = messages;
            Ships = ships;
            Misses = misses;
        }
    }
}

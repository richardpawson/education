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

        #region Ship-related functions
        public Ship(string ShipName, int ShipSize, ImmutableHashSet<Tuple<int, int>> hits, int col=0, int row = 0, Orientations orient = 0)
        {
            Name = ShipName;
            Size = ShipSize;
            startCol = col;
            startRow = row;
            Orientation = orient;
            Hits = hits;
        }

        public static Ship SetPosition(Ship ship, int col, int row, Orientations orient)
        {
            return new Ship(ship.Name, ship.Size, ship.Hits, col, row, orient); 
        }

        //Calculated based on the size and the orientation of the ship
        public static bool ShipOccupiesLocation(Ship ship, int col, int row)
        {
            if (ship.Orientation == Orientations.Horizontal)
            {
                return ship.startRow == row &&
                    col >= ship.startCol && col < ship.startCol + ship.Size;
            }
            else
            {
                return ship.startCol == col &&
                    row >= ship.startRow && row < ship.startRow + ship.Size;
            }
        }

        public static bool ShipIsHitInLocation(Ship ship, int col, int row)
        {
            return ship.Hits.Contains(Tuple.Create(col, row));
        }

        private static int PositionOnShip(Ship ship, int col, int row)
        {
            if (ship.Orientation == Orientations.Horizontal)
            {
                return col - ship.startCol;
            }
            else
            {
                return row - ship.startRow;
            }
        }

        public static Ship Hit(Ship ship, int col, int row)
        {
            var newHits = ship.Hits.Add(Tuple.Create(col, row));
            return new Ship(ship.Name, ship.Size, newHits, ship.startCol, ship.startRow, ship.Orientation);
        }

        public static int HitCount(Ship ship)
        {
            return ship.Hits.Count;
        }

        //Returns true if the Hit count matches the size of the ship
        public static bool IsSunk(Ship ship)
        {
            return HitCount(ship) >= ship.Size;
        }
        #endregion
    }
}
using System;
using System.Collections.Generic;
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

        //Corresponds to the length of the ship to know which squares
        //have already been hit and prevent double-counting hits on same position
        public readonly HashSet<Tuple<int,int>> Hits = new HashSet<Tuple<int, int>>();

        #region Ship-related functions
        public Ship(string ShipName, int ShipSize, int col=0, int row = 0, Orientations orient = 0)
        {
            Name = ShipName;
            Size = ShipSize;
            this.startCol = col;
            this.startRow = row;
            this.Orientation = orient;
        }

        public static Ship SetPosition(Ship ship, int col, int row, Orientations orient)
        {
            return new Ship(ship.Name, ship.Size, col, row, orient); 
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

        //Increments the hit count
        public static void Hit(Ship ship, int col, int row)
        {
            ship.Hits.Add(Tuple.Create(col, row));
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
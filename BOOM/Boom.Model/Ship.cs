using System;
using System.Collections.Generic;
using System.Linq;

namespace Boom.Model
{
    public class Ship
    { 
        private int startRow;

        private int startCol;

        private Orientations Orientation;

        public string Name { get; private set; }

        public int Size { get; private set; }

        //Corresponds to the length of the ship to know which squares
        //have already been hit and prevent double-counting hits on same position
        private HashSet<Tuple<int,int>> Hits = new HashSet<Tuple<int, int>>();

        public Ship(string ShipName, int ShipSize, int col =0, int row = 0, Orientations orient = 0)
        {
            Name = ShipName;
            Size = ShipSize;
            SetPosition(col, row, orient);
        }

        public void SetPosition(int col, int row, Orientations orient)
        {
            startCol = col;
            startRow = row;
            Orientation = orient;
        }

        //Calculated based on the size and the orientation of the ship
        public bool ShipOccupiesLocation(int col, int row)
        {
            if (Orientation == Orientations.Horizontal)
            {
                return startRow == row &&
                    col >= startCol && col < startCol + Size;
            }
            else
            {
                return this.startCol == col &&
                    row >= startRow && row < startRow + Size;
            }
        }

        public bool ShipIsHitInLocation(int col, int row)
        {
            return Hits.Contains(Tuple.Create(col, row));
        }

        private int PositionOnShip(int col, int row)
        {
            if (Orientation == Orientations.Horizontal)
            {
                return col - startCol;
            }
            else
            {
                return row - startRow;
            }
        }

        //Increments the hit count
        public void Hit(int col, int row)
        {
            Hits.Add(Tuple.Create(col, row));
        }

        public int HitCount()
        {
            return Hits.Count;
        }

        //Returns true if the Hit count matches the size of the ship
        public bool IsSunk()
        {
            return HitCount() >= Size;
        }
    }
}
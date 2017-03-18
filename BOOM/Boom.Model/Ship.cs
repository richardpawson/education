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
        private bool[] Hits = null;

        public Ship(string ShipName, int ShipSize, int col =0, int row = 0, Orientations orient = 0)
        {
            Name = ShipName;
            Size = ShipSize;
            Hits = new bool[ShipSize];
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
            if (ShipOccupiesLocation(col, row))
            {
                int pos = PositionOnShip(col, row);
                return Hits[pos];
            }
            else
            { return false; }
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
            int positionOnShip = PositionOnShip(col, row);
            Hits[positionOnShip] = true;
        }

        public int HitCount()
        {
            return Hits.Count(h => h); //i.e. returns count of 'true' values
        }

        //Returns true if the Hit count matches the size of the ship
        public bool IsSunk()
        {
            return HitCount() >= Size;
        }
    }
}
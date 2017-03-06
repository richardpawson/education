namespace Boom.Model
{
    public class Ship
    { 
        private int startRow;

        private int startCol;

        private Orientations Orientation;

        public string Name { get; private set; }

        public int Size { get; private set; }

        public int Hits { get; private set; }

        public Ship(string ShipName, int ShipSize, int row =0, int col =0, Orientations orient = 0)
        {
            Name = ShipName;
            Size = ShipSize;
            Hits = 0;
            SetPosition(row, col, orient);
        }

        public void SetPosition(int row, int col, Orientations orient)
        {
            startRow = row;
            startCol = col;
            Orientation = orient;
        }

        //Calculated based on the size and the orientation of the ship
        public bool ShipOccupiesLocation(int row, int col)
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

        //Increments the hit count
        public void Hit()
        {
            Hits += 1;
        }

        //Returns true if the Hit count matches the size of the ship
        public bool IsSunk()
        {
            return Hits >= Size;
        }
    }
}
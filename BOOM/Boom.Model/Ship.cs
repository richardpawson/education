namespace Boom.Model
{
    public class Ship
    {
        public string Name { get; private set; }

        public int Size { get; private set; }

        public int Hits { get; private set; }

        private int startRow;

        private int startCol;

        private Orientations Orientation;


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

        public bool IsSunk()
        {
            return Hits >= Size;
        }

        public void Hit()
        {
            Hits += 1;
        }

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
    }
}
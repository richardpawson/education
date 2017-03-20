using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boom.Model
{
    public static class ShipFunctions
    {
        #region Ship-related functions

        public static Ship SetPosition(this Ship ship, int col, int row, Orientations orient)
        {
            return new Ship(ship.Name, ship.Size, ship.Hits, col, row, orient);
        }

        //Calculated based on the size and the orientation of the ship
        public static bool ShipOccupiesLocation(this Ship ship, int col, int row)
        {
            return ship.Orientation == Orientations.Horizontal ?
                 ship.startRow == row &&
                    col >= ship.startCol && col < ship.startCol + ship.Size :
                 ship.startCol == col &&
                    row >= ship.startRow && row < ship.startRow + ship.Size;
        }

        public static bool IsHitInLocation(this Ship ship, int col, int row)
        {
            return ship.Hits.Contains(Tuple.Create(col, row));
        }

        public static Ship Hit(this Ship ship, int col, int row)
        {
            var newHits = ship.Hits.Add(Tuple.Create(col, row));
            return new Ship(ship.Name, ship.Size, newHits, ship.startCol, ship.startRow, ship.Orientation);
        }

        public static bool IsSunk(this Ship ship)
        {
            return ship.Hits.Count >= ship.Size;
        }
        #endregion

    }
}

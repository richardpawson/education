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

        public static Tuple<Ship, bool, String> FireAt(this Ship ship, int col, int row)
        {
            if (ship.ShipOccupiesLocation(col, row))
            {
                var newHits = ship.Hits.Add(Tuple.Create(col, row));
                var newShip = new Ship(ship.Name, ship.Size, newHits, ship.startCol, ship.startRow, ship.Orientation);
                var message = IsSunk(newShip) ? newShip.Name + " sunk!" : "Hit a " + newShip.Name + " at (" + col + "," + row + ").";
                return Tuple.Create(newShip, true, message);
            }
            else
            {
                return Tuple.Create(ship, false, "");
            }
        }

        public static bool IsSunk(this Ship ship)
        {
            return ship.Hits.Count >= ship.Size;
        }
        #endregion

    }
}
